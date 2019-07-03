define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model'], function ($, enhance, model) {
    let btnSubmit_click = function () {
        var m = model.createModel();
        var formData = model.capture(m);
        var json = JSON.stringify(formData);

        $.ajax({
            url: '/SignIn/AValidateUser',
            type: 'POST',
            dataType: 'JSON',
            data: {
                FormJson: json
            },
            success: function (data) {
                if (!data.Success) {
                    alert('登录失败');
                    return;
                }

                window.location = data.ReturnUrl;
            }
        })
    };

    return {
        ready: function () {
            $('#BtnSubmit').click(btnSubmit_click);
        }
    };
});