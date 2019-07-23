define(['jquery', 'mustache', 'kyle_toolkit_repeater', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, mustache, repeater, enhance, model, validation) {
    let btnSearch_click = function () {
        repeater.dataBind(true);
    };

    let btnChaiBao_click = function () {
        let 来快递单号 = $.trim($('#Txt来快递单号').val());
        if (来快递单号 === '') {
            btnSearch_click();
            return false;
        }

        $.ajax({
            url: '/Order/AGetOrderID',
            type: 'POST',
            dataType: 'JSON',
            data: {
                来快递单号: 来快递单号
            },
            success: function (data) {
                if (data.ID !== '') {
                    window.open('/Order/ChaiBao/' + data.ID);
                    return;
                }

                btnSearch_click();
            }
        });
    };

    let chk拆包超时_click = function () {
        if ($(this).prop('checked') === true) {
            $('#Ddl跟进状态').val('true');
        }

        return true;
    };

    return {
        ready: function (vm) {
            repeater.init({
                target: $('.repeater'),
                tmplItem: $('#tmplRow').html(),
                newFilters: function () {
                    let m = model.createModel();
                    let newCondition = model.capture(m);
                    if ($('#Chk拆包超时').prop('checked')) {
                        newCondition.拆包超时 = parseInt($('#Ddl拆包超时').val());
                    }
                    return newCondition;
                },
                url: '/Order/AChaiBaoList',
                currentSortPaging: vm.currentSortPaging
            }, true);

            $('#Chk拆包超时').click(chk拆包超时_click);
            $('#BtnChaiBao').click(btnChaiBao_click);
            $('#BtnSearch').click(btnSearch_click).click();
            $('#TxtSearch').focus();
        }
    };
});