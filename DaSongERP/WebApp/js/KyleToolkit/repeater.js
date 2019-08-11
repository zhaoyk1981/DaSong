define(['jquery', 'mustache'], function ($, mustache) {
    // #region input output
    let _options = {
        id: 'ID',
        target: null,
        pageNumStart: -2,
        pageNumEnd: 2,
        tmplItem: null,
        newFilters: function () { return {}; },
        url: null,
        tmplPageButton: "<li class='page-num page-item'><a href='javascript:void(0)' class='btn-page-num page-link' page-index='{{pageIndex}}'>{{{text}}}</a></li>",
        tmplActivePage: "<li class='active page-num page-item'><a href='javascript:void(0)' class='page-link'>{{{text}}}</a></li>",
        onDataBound: function (data) { },
        selectedIDs: [],
        allIDs: [],
        currentSortPaging: null,
        storedCondition: null
    };

    let output = {
        init: function (opt, refreshSortPaging, autoBind) {
            _options = $.extend(_options, opt);
            _storedCondition(_options.newFilters());
            $(_options.target).delegate('.btn-sort', 'click', btnSort_click);
            $(_options.target).delegate('.btn-previous-page', 'click', btnPreviousPage_click);
            $(_options.target).delegate('.btn-next-page', 'click', btnNextPage_click);
            $(_options.target).delegate('.btn-page-num', 'click', btnPageNum_click);
            $(_options.target).delegate('.btn-first-page', 'click', btnFirstPage_click);
            $(_options.target).delegate('.btn-last-page', 'click', btnLastPage_click);

            if (autoBind === true) {
                sendRequest();
            }
            else if (refreshSortPaging === true) {
                _dataBound();
            }


            $(_options.target).find('.select-all').on('click', selectAll_click);
            $(_options.target).delegate('.row-select', 'click', selectItem_click);
        },
        dataBind: function (withNewFilters, pageById) {
            let sp = currentSortPaging();
            _options.pageById = pageById;
            if (withNewFilters === true) {
                _storedCondition(_options.newFilters());
                sp.PageIndex = 0;
                _options.selectedIDs = [];
            }

            currentSortPaging(sp);
            sendRequest();
        },
        bindSortPaging: function () {
            _dataBound();
        },
        selectedIDs: function () {
            if ($(_options.target).find('.select-all').prop('checked') === true) {
                return _options.allIDs;
            }

            for (let i = _options.selectedIDs.length - 1; i >= 0; i--) {
                if (_options.allIDs.indexOf(_options.selectedIDs[i]) < 0) {
                    _options.selectedIDs.splice(i);
                }
            }

            return _options.selectedIDs;
        }
    };
    // #endregion input output

    // #region AJAX
    let timeStamp = 0;
    let sendRequest = function () {
        let d = $.extend(currentSortPaging(), _storedCondition());
        timeStamp = new Date().getUTCMilliseconds();
        d.TimeStamp = timeStamp;
        d.PageById = _options.pageById;
        _options.pageById = null;
        if (d.PageById == null) {
            delete d.PageById;
        }

        $.ajax({
            url: _options.url,
            type: 'POST',
            dataType: 'json',
            data: d,
            success: function (data, textStatus, jqXHR) {
                if (data == null) {
                    window.location = window.location.href;
                    return;
                }

                if (data.location != null) {
                    window.location = data.location;
                    return;
                }

                if (data.TimeStamp < timeStamp) {
                    return;
                }

                if (data.DataSource == null) {
                    window.location = window.location.href;
                    return;
                }

                _dataBinding(data);
                _dataBind(data);
                _dataBound(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                // 通常 textStatus 和 errorThrown 之中
                // 只有一个会包含信息
                //this; // 调用本次AJAX请求时传递的options参数
                window.location = window.location.href;
            }
        });
    };
    // #endregion AJAX

    // #region DataBind
    let _bindSort = function () {
        let c = currentSortPaging();
        if (c == null) {
            return;
        }

        $(_options.target).find('.btn-sort').removeAttr('sort-desc');
        $(_options.target).find('.btn-sort[sort="' + c.OrderBy + '"]').attr('sort-desc', c.OrderByDesc);
    };

    let _bindPagingButtons = function () {
        let result = currentSortPaging();
        if (result == null) {
            return;
        }

        let start = _options.pageNumStart;
        let end = _options.pageNumEnd;
        let firstNum = result.PageIndex + start;
        let offset = firstNum < 0 ? -firstNum : 0;
        if (offset == 0 && result.PagesCount > Math.abs(start) + end + 1) {
            let lastNum = result.PageIndex + end;
            offset = lastNum >= result.PagesCount ? result.PagesCount - lastNum - 1 : 0;
        }

        $(_options.target).find('.pagination > .page-num').remove();
        for (let i = start; i <= end; i++) {
            let idx = result.PageIndex + i + offset;
            if (idx < 0 || idx >= result.PagesCount) {
                continue;
            }

            let btnPage = {
                pageIndex: idx,
                text: (idx + 1).toString()
            };

            $(_options.target).find('.pagination').each(function () {
                let row = $(mustache.render(idx === result.PageIndex ? _options.tmplActivePage : _options.tmplPageButton, btnPage));
                $(this).children('*:last').before(row);
            });
        }

        $(_options.target).find('.btn-previous-page, .btn-first-page').closest('li').toggleClass('disabled', result.PageIndex <= 0);
        $(_options.target).find('.btn-next-page, .btn-last-page').closest('li').toggleClass('disabled', result.PageIndex >= result.PagesCount - 1);

        $(_options.target).find('.lbl-records-count').text(result.RecordsCount.toString());
        $(_options.target).find('.lbl-page-size').text(result.PageSize.toString());
        $(_options.target).find('.lbl-pages-count').text(result.PagesCount.toString());
        $(_options.target).find('.lbl-current-page-number').text(((result.PageIndex < 0 ? 0 : result.PageIndex) + 1).toString());
        $(_options.target).find('.lbl-current-page-records-count').text(result.DataSourceCount.toString());
        $(_options.target).find('.lbl-current-page-record-start').text(result.RecordNumberStart.toString());
        $(_options.target).find('.lbl-current-page-record-end').text(result.RecordNumberEnd.toString());
    };

    let _dataBinding = function (result) {
        currentSortPaging({
            PageSize: result.PageSize,
            PageIndex: result.PageIndex,
            PagesCount: result.PagesCount,
            OrderBy: result.OrderBy,
            OrderByDesc: result.OrderByDesc,
            RecordsCount: result.RecordsCount,
            RecordNumberStart: result.RecordNumberStart,
            RecordNumberEnd: result.RecordNumberEnd,
            DataSourceCount: result.DataSourceCount
        });
    };

    let _dataBind = function (result) {
        let rptItems = $(_options.target).find('.repeat-items');
        rptItems.empty();
        _options.allIDs = result.IDList;
        for (let i = 0; i < result.DataSource.length; i++) {
            let item = $(mustache.render(_options.tmplItem, result.DataSource[i]));
            if (result.DataSource[i][_options.id] === result.PageById) {
                $(item).toggleClass('focus-item', true);
            }

            item.find('.row-select').prop('checked', $('.select-all').prop('checked') === true || _options.selectedIDs.indexOf(result.DataSource[i][_options.id].toString().toLowerCase()) >= 0);

            rptItems.append(item);
        }
    };

    let selectAll_click = function (event) {
        if ($(this).prop('checked') === true) {
            $(_options.target).find('.row-select').prop('checked', true);
        }
        else {
            $(_options.target).find('.row-select').prop('checked', false);
            _options.selectedIDs = [];
        }
    };

    let selectItem_click = function (event) {
        let id = $(this).closest("[data-id]").attr("data-id").toLowerCase();
        let index = _options.selectedIDs.indexOf(id);
        if ($(this).prop('checked') === true) {
            if (index < 0) {
                _options.selectedIDs.push(id);
            }
        }
        else {
            $(_options.target).find('.select-all').prop('checked', false);
            if (index >= 0) {
                _options.selectedIDs.splice(index, 1);
            }
        }
    };

    let _dataBound = function (data) {
        _bindPagingButtons();
        _bindSort();
        if (data != null && typeof (_options.onDataBound) === 'function') {
            _options.onDataBound(data);
        }
    };
    // #endregion DataBind

    // #region backStorage
    let _storedCondition = function (value) {
        if (arguments.length == 0) {
            return _options.storedCondition;
        }

        _options.storedCondition = value;
        return value;
    };

    let currentSortPaging = function (value) {
        if (arguments.length == 0) {
            return _options.currentSortPaging;
        }

        _options.currentSortPaging = value;
        return value;
    };
    // #endregion backStorage

    let btnSort_click = function (event) {
        let sortCtrl = $(this).is('[sort]') ? $(this) : $(this).closest('[sort]');
        let noToggle = sortCtrl.hasClass('no-sort-toggle');
        let currentSort = currentSortPaging();
        let newSort = {
            OrderBy: sortCtrl.attr('sort')
        };

        newSort.OrderByDesc = ($(sortCtrl).attr('sort-desc-dflt') || '').toLowerCase() === 'true';
        if (currentSort.OrderBy === newSort.OrderBy && !noToggle) {
            newSort.OrderByDesc = !currentSort.OrderByDesc;
        }
        let c = $.extend(currentSortPaging(), newSort);
        currentSortPaging(c);
        sendRequest();
    };

    // #region Paging events
    let btnFirstPage_click = function (event) {
        let c = currentSortPaging();
        c.PageIndex = 0;
        currentSortPaging(c);
        sendRequest();
    };

    let btnLastPage_click = function (event) {
        let c = currentSortPaging();
        c.PageIndex = -1;
        currentSortPaging(c);
        sendRequest();
    };

    let btnPreviousPage_click = function (event) {
        let c = currentSortPaging();
        c.PageIndex--;
        if (c.PageIndex < 0) {
            c.PageIndex = 0;
        }

        currentSortPaging(c);
        sendRequest();
    };

    let btnNextPage_click = function (event) {
        let c = currentSortPaging();
        c.PageIndex++;
        if (c.PageIndex < 0) {
            c.PageIndex = 0;
        }

        currentSortPaging(c);
        sendRequest();
    };

    let btnPageNum_click = function (event) {
        let c = currentSortPaging();
        c.PageIndex = parseInt($(this).attr('page-index'));
        if (c.PageIndex < 0) {
            c.PageIndex = 0;
        }

        currentSortPaging(c);
        sendRequest();
    };
    // #endregion Paging events

    return output;
});