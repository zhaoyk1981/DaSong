define(['jquery', 'mustache', 'kyle_toolkit_repeater', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, mustache, repeater, model, validation) {
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
                    if ($('#Chk拆包超时').prop('checked')) {
                        newCondition.拆包超时 = parseInt($('#Ddl拆包超时').val());
                    }
                    return newCondition;
                },
                url: '/Order/AGenJinList',
                currentSortPaging: vm.currentSortPaging
            }, true);

            $('#BtnSearch').click(btnSearch_click);
        }
    };
});