define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let validate = function () {
        let validationResult = validation.validate(['CreateStock']);
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
            url: '/Stock/AUpdate',
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

    let txtProductImage_change = function () {
        let src = $.trim($('#TxtThumbnails').val());
        let fg = $('#TxtThumbnails').closest('.form-group');
        fg.find('a.product-thumbnail-link').prop('href', src).toggle(src !== '');
        fg.find('img').prop('src', src);
        if (src !== '' && timer != null) {
            clearInterval(timer);
            timer = null;
        }
    };

    return {
        ready: function () {
            $('#BtnSubmit').click(btnSubmit_click);
            $('#TxtThumbnails').on('change', txtProductImage_change);
        }
    };
});