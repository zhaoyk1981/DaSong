define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let initValidation = function () {

    };

    let validate = function () {
        var validationResult = validation.validate(['default']);
        if (validationResult !== true) {
            $('#BtnSubmit').prop('disabled', false);
        }

        return validationResult;
    };

    let btnSubmit_click = function () {
        $(this).prop('disabled', true);
        if (!validate()) {
            return;
        }

        var m = model.createModel();
        var json = model.captureJSON(m);

        var formData = new FormData();
        formData.append("formJson", enhance.HTMLEncode(json));
        //formData.append("file", $('#IptPicture')[0].files[0], "file");
        //formData.append("upload_file", true);
        $.ajax({
            url: '/Order/AShouHou',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                alert(data.Success === true ? '操作成功' : '操作失败');
            }
        });
    };

    return {
        ready: function () {
            initValidation();
            $('#BtnSubmit').click(btnSubmit_click);
        }
    };
});