define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let validate = function () {
        let validationResult = validation.validate(['CreateOrder']);
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
            url: '/Order/ACreate',
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

    let txtProductImage_input = function () {
        let src = $.trim($(this).val());
        let fg = $(this).closest('.form-group');
        fg.find('img').prop('src', src);
        fg.find('a.product-thumbnail-link').prop('href', src).toggle(src !== '');
    };

    return {
        ready: function () {
            $('#BtnSubmit').click(btnSubmit_click);
            $('#Txt商品图片').on('input', txtProductImage_input);
            //$('#Txt货号').blur(txt货号_blur);
        }
    };
});