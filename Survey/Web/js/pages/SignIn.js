define(['jquery', 'kyle_toolkit_model'], function ($, model) {
    let btnValidateUser_click = function () {
        let m = model.createModel();
        let formData = model.capture(m);
        let json = JSON.stringify(formData);
        console.log(json);
        $.ajax({
            url: '/SignIn',
            type: 'POST',
            dataType: 'JSON',
            data: {
                ModelJson: json
            },
            success: function (data) {

            }
        });
    };

    let docReady = function () {
        //console.log('signin docReady');
        $('#BtnSubmit').click(btnValidateUser_click);
    };

    return {
        ready: docReady
    };
});