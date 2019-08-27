define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model'], function ($, enhance, model) {
    let btnByDay_click = function () {
        let m = model.createModel();
        let json = model.captureJSON(m);

        let formData = new FormData();
        formData.append("formJson", enhance.HTMLEncode(json));

        $.ajax({
            url: '/TongJi/AChaiBaoByDay',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                $('.by-employees').html(data.By员工);
                $('.by-status').html(data.By状态);
            }
        });
    };

    let btnByMonth_click = function () {
        let m = model.createModel();
        let json = model.captureJSON(m);

        let formData = new FormData();
        formData.append("formJson", enhance.HTMLEncode(json));

        $.ajax({
            url: '/TongJi/AChaiBaoByMonth',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                $('.by-employees').html(data.By员工);
                $('.by-status').html(data.By状态);
            }
        });
    };

    return {
        ready: function () {
            $('.btn-by-day').click(btnByDay_click).click();
            $('.btn-by-month').click(btnByMonth_click);
        }
    };
});