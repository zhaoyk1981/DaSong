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

                let copyText = document.getElementById("txtCopy");
                copyText.select();
                document.execCommand("copy");
            }
        });
    };

    let txtProductImage_change = function () {
        let src = $.trim($('#Txt商品图片').val());
        let fg = $('#Txt商品图片').closest('.form-group');
        fg.find('a.product-thumbnail-link').prop('href', src).toggle(src !== '');
        fg.find('img').prop('src', src);
        if (src !== '' && timer !== null) {
            clearInterval(timer);
        }
    };

    let txtOrderNumbers_change = function () {
        let jd = $.trim($('#TxtJD订单号').val());
        let tb = $.trim($('#Txt淘宝订单号').val());
        if (jd === '' || tb === '') {
            return true;
        }

        $('#LblOrderNumberExists').empty();
        let json = enhance.HTMLEncode(JSON.stringify({
            JD订单号: jd,
            淘宝订单号: tb
        }));
        $.ajax({
            url: '/Order/AHasOrder',
            type: 'POST',
            dataType: 'JSON',
            data: {
                FormJson: json
            },
            success: function (data) {
                if (data.HasOrder === true) {
                    $('#LblOrderNumberExists').text('JD订单号和淘宝订单号已存在');
                }
            }
        });
        return true;
    };

    let timer = null;

    return {
        ready: function () {
            $('#BtnSubmit').click(btnSubmit_click);
            $('#Txt商品图片').on('change', txtProductImage_change);
            $('#TxtJD订单号,#Txt淘宝订单号').on('change', txtOrderNumbers_change);
            timer = setInterval(txtProductImage_change, 1000);
        }
    };
});