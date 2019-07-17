define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation', 'clipboard'], function ($, enhance, model, validation, ClipBoardJS) {
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

        let m = model.createModel();
        let json = model.captureJSON(m);

        let formData = new FormData();
        formData.append("formJson", enhance.HTMLEncode(json));
        //formData.append("file", $('#IptPicture')[0].files[0], "file");
        //formData.append("upload_file", true);
        $.ajax({
            url: '/Order/AGenJin',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.Success) {
                    alert('操作成功');
                }
                else {
                    alert('操作失败');
                    $('#BtnSubmit').prop('disabled', false);
                }
            }
        });
    };

    //let Ddl来快递_change = function () {
    //    let selectedValue = $('#Ddl来快递').val();
    //    let 没订货 = selectedValue === '没订货';
    //    $('#Txt来快递单号').prop('disabled', 没订货);
    //    if (没订货 === true) {
    //        $('#Txt来快递单号').val('');
    //        validation.validate(['default']);
    //    }
    //};

    return {
        ready: function () {
            new ClipBoardJS('.btn-copy-clipboard');
            //$('#Ddl来快递').change(Ddl来快递_change).change();
            $('#BtnSubmit').click(btnSubmit_click);
        }
    };
});