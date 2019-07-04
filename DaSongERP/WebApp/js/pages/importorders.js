define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
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

        var formData = new FormData();
        //formData.append("formJson", json);
        formData.append("file", $('#IptExcel')[0].files[0], $('#IptExcel')[0].files[0].name);
        formData.append("upload_file", true);
        $.ajax({
            url: '/Order/AImport',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.Success !== true) {
                    alert('操作失败');
                    return;
                }

                $("#LblMessage").text('未导入订单数量：' + data.未导入);
                window.open(data.Url);
            }
        });
    };

    return {
        ready: function () {
            $('#BtnSubmit').click(btnSubmit_click);
        }
    };
});