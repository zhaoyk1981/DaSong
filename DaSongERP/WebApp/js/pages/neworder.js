define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let initValidation = function () {

    };

    let validate = function () {
        var validationResult = validation.validate(['CreateOrder']);
        if (validationResult !== true) {
            $('#BtnCreateOrder').prop('disabled', false);
        }

        return validationResult;
    };

    let btnCreateOrder_click = function () {
        $(this).prop('disabled', true);
        if (!validate()) {
            return;
        }

        var m = model.createModel();
        var json = model.captureJSON(m);

        var formData = new FormData();
        formData.append("formJson", json);
        formData.append("file", $('#IptPicture')[0].files[0], "file");
        formData.append("upload_file", true);
        $.ajax({
            url: '/Order/ACreate',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                alert('完成');
            }
        });
    };

    return {
        ready: function () {
            initValidation();
            $('#BtnCreateOrder').click(btnCreateOrder_click);
        }
    };
});