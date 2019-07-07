define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let btnSearch_click = function () {
        let s = encodeURI($.trim($('#TxtSearch').val()));
        let url = '/Order?search=' + s;
        //let shouhou = $('.shouhou-filters');
        //if (shouhou.length === 1) {
        //    var f = $('#Chk已售后但未完结').prop('checked') ? 'true' : 'false';
        //    var m = $('#Chk只看我的').prop('checked') ? 'true' : 'false';

        //}

        window.location = url;
    };

    return {
        ready: function () {
            $('#BtnSearch').click(btnSearch_click);
        }
    };
});