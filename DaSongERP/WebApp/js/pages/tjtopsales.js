define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation', 'mustache', 'kyle_toolkit_repeater'], function ($, enhance, model, validation, mustache, repeater) {
    let validate = function () {
        let validationResult = validation.validate(['submit']);
        if (validationResult !== true) {
            $('.btn-submit').prop('disabled', false);
        }

        return validationResult;
    };

    let btnSubmit_click = function () {
        if (!validate()) {
            return;
        }

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
                url: '/TongJi/ATopSales',
                currentSortPaging: vm.currentSortPaging
            }, true);

            $('.btn-submit').click(btnSubmit_click).click();
        }
    };
});