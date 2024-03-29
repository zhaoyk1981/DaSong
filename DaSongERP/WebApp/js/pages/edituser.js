﻿define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation', 'select2', 'select2zhcn'], function ($, enhance, model, validation, select2, select2zhcn) {
    let validate = function () {
        let validationResult = validation.validate(['submit']);
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

        let m = model.createModel();
        let json = model.captureJSON(m);

        let formData = new FormData();
        formData.append("formJson", enhance.HTMLEncode(json));
        //formData.append("file", $('#IptPicture')[0].files[0], "file");
        //formData.append("upload_file", true);
        $.ajax({
            url: '/User/AUpdate',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                let msg = data.Success === true ? '操作成功' : '操作失败';
                if (data.ErrorMessage !== '') {
                    msg = data.ErrorMessage;
                }

                alert(msg);
                if (data.Success === false) {
                    $('#BtnSubmit').prop('disabled', false);
                }
            }
        });
    };

    return {
        ready: function () {
            $('#SlctPermissionID').select2({
                language: "zh-CN",
                allowClear: true,
                placeholder: "请选择权限"
            });

            $('#BtnSubmit').click(btnSubmit_click);
        }
    };
});