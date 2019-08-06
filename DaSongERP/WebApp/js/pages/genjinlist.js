define(['jquery', 'mustache', 'kyle_toolkit_repeater', 'kyle_toolkit_model', 'kyle_toolkit_validation', 'clipboard'], function ($, mustache, repeater, model, validation, ClipBoardJS) {
    let btnSearch_click = function (event) {
        repeater.dataBind(true);
    };

    let chk拆包超时_click = function () {
        if ($(this).prop('checked') === true) {
            $('#Ddl跟进状态').val('false');
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
                url: '/Order/AGenJinList',
                currentSortPaging: vm.currentSortPaging,
                onDataBound: function (dat) {
                    new ClipBoardJS('.btn-copy-clipboard');
                }
            }, true);

            //$('#Chk拆包超时').click(chk拆包超时_click);
            $('#BtnSearch').click(btnSearch_click).click();
        }
    };
});