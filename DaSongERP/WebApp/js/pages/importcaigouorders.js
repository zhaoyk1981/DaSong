define(['jquery', 'mustache', 'kyle_toolkit_repeater', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, mustache, repeater, enhance, model, validation) {
    let validate = function () {
        let validationResult = validation.validate(['default']);
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

        let formData = new FormData();
        //formData.append("formJson", json);
        formData.append("file", $('#IptExcel')[0].files[0], $('#IptExcel')[0].files[0].name);
        formData.append("upload_file", true);
        $.ajax({
            url: '/Order/AImportCaiGou',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.Success !== true) {
                    alert('操作失败,' + (data.ErrorMessage || ''));
                    return;
                }

                window.location = data.Url;
            }
        });
    };

    return {
        ready: function (vm) {
            $('#BtnSubmit').click(btnSubmit_click);
        }
    };
});