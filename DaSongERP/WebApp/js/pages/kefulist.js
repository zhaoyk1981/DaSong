define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let btnSearch_click = function () {
        let m = model.createModel();
        let p = model.captureParams(m);
        let url = '/Order/KeFuList?Search=true&' + p;
        window.location = url;
    };

    return {
        ready: function () {
            $('#BtnSearch').click(btnSearch_click);
        }
    };
});