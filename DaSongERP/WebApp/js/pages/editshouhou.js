define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
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

        $.ajax({
            url: '/Meta/AUpdateShouHou',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                let msg = data.Success === true ? '操作成功' : '操作失败, 名称可能已存在。';
                alert(msg);
                if (data.Success === false) {
                    $('#BtnSubmit').prop('disabled', false);
                }
            }
        });
    };

    return {
        ready: function () {
            $('#BtnSubmit').click(btnSubmit_click);
        }
    };
});