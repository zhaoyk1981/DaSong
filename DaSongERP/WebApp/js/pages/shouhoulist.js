define(['jquery', 'mustache', 'kyle_toolkit_repeater', 'kyle_toolkit_model', 'kyle_toolkit_validation', 'clipboard'], function ($, mustache, repeater, model, validation, ClipBoardJS) {
    let btnSearch_click = function (event) {
        repeater.dataBind(true);
    };

    return {
        ready: function (vm) {
            repeater.init({
                target: $('.repeater'),
                tmplItem: $('#tmplRow').html(),
                newFilters: function () {
                    let m = model.createModel();
                    let newCondition = model.capture(m);
                    return newCondition;
                },
                url: '/Order/AShouHouList',
                currentSortPaging: vm.currentSortPaging,
                onDataBound: function (dat) {
                    new ClipBoardJS('.btn-copy-clipboard');
                }
            }, true);

            $('#BtnSearch').click(btnSearch_click).click();
        }
    };
});