define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model'], function ($, enhance, model) {
    let btnSubmit_click = function () {
        let m = model.createModel();
        let formData = model.capture(m);
        let json = JSON.stringify(formData);

        $.ajax({
            url: '/SignIn/AValidateUser',
            type: 'POST',
            dataType: 'JSON',
            data: {
                FormJson: enhance.HTMLEncode(json)
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