define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let btnSearch_click = function () {
        var s = encodeURI($.trim($('#TxtSearch').val()));
        window.location = '/Order?search=' + s;
    };

    return {
        ready: function () {
            $('#BtnSearch').click(btnSearch_click);
        }
    };
});