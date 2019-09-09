define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let validate = function () {
        let validationResult = validation.validate(['submit']);
        if (validationResult !== true) {
            $('#BtnSubmit').prop('disabled', false);
        }

        return validationResult;
    };

    let btnByDay_click = function () {
        req('日');
    };

    let btnByMonth_click = function () {
        req('月');
    };

    let req = function (dateType) {
        if (!validate()) {
            return;
        }

        let m = model.createModel();
        let c = model.capture(m);
        c.DateType = dateType;
        let json = JSON.stringify(c);

        let formData = new FormData();
        formData.append("formJson", enhance.HTMLEncode(json));

        $.ajax({
            url: '/TongJi/ASales',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                $('.总订单数').text(data.Str总订单数);
                $('.有效订单数').text(data.Str有效订单数);
                $('.总销售额').text(data.Str总销售额);
                $('.有效销售额').text(data.Str有效销售额);
                $('.总毛利').text(data.Str总毛利);
                $('.有效毛利').text(data.Str有效毛利);
            }
        });
    };

    return {
        ready: function () {
            $('.btn-by-day').click(btnByDay_click).click();
            $('.btn-by-month').click(btnByMonth_click);
        }
    };
});