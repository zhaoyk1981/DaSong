define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {

    let validate = function () {
        let validationResult = validation.validate(['UpdateOrder']);
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
            url: '/Order/AUpdate',
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
        let src = $.trim($(this).val());
        let fg = $(this).closest('.form-group');
        fg.find('img').prop('src', src);
        fg.find('a.product-thumbnail-link').prop('href', src).toggle(src !== '');
    };

    let txtOrderNumbers_change = function () {
        $('#LblOrderNumberExists').empty();
        $('#BtnSubmit').prop('disabled', false);
        let m = model.createModel();
        let order = model.capture(m);
        if (order.JD订单号 === '' && order.货号 === '' && order.淘宝订单号 === '' && order.采购备注 === '') {
            return true;
        }

        let json = JSON.stringify(order);
        let formData = new FormData();
        formData.append("formJson", enhance.HTMLEncode(json));
        $.ajax({
            url: '/Order/AHasOrder',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.HasOrder === true) {
                    $('#BtnSubmit').prop('disabled', true);
                    $('#LblOrderNumberExists').text('JD订单号、淘宝订单号、货号和SKU及采购备注 已存在');
                }
            }
        });
        return true;
    };

    let loadSpecList = function () {
        let condition = {
            货号: $.trim($('#Txt货号').val()),
            仓库: $('#Ddl中转仓').val()
        };
        let json = JSON.stringify(condition);
        let formData = new FormData();
        formData.append("formJson", enhance.HTMLEncode(json));

        $.ajax({
            url: '/Stock/AGetSpecOptions',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.SpecOptions.length > 0) {
                    let ddl = $('#Ddl规格')[0];
                    while (ddl.options.length > 0) {
                        ddl.options.remove(0);
                    }

                    for (let i = 0; i < data.SpecOptions.length; i++) {
                        let op = $("<option value='" + data.SpecOptions[i].Value + "'>" + data.SpecOptions[i].Text + "</option>");
                        ddl.options.add(op[0]);
                    }
                }
            }
        });
    };

    return {
        ready: function () {
            $('#BtnSubmit').click(btnSubmit_click);
            $('#Txt商品图片').on('change', txtProductImage_change);
            //$('#TxtJD订单号,#Txt淘宝订单号,#Txt货号,#Txt采购备注').on('change', txtOrderNumbers_change);
            $('#Ddl中转仓,#Txt货号').on('change', loadSpecList);
        }
    };
});