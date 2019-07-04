define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let initValidation = function () {

    };

    let txt货号_blur = function () {
        var 货号 = $.trim($(this).val());
        if (货号.length === 0) {
            $('#LblStockInfo').empty();
            return;
        }

        $.ajax({
            url: '/Stock/AGetStockInfo',
            type: 'POST',
            dataType: 'JSON',
            data: {
                货号: 货号
            },
            success: function (data) {
                $('#LblStockInfo').text('库存: ' + data.库存数量 + ' 在途：' + data.在途数量);
            }
        });
    };

    let validate = function () {
        var validationResult = validation.validate(['UpdateOrder']);
        if (validationResult !== true) {
            $('#BtnUpdateOrder').prop('disabled', false);
        }

        return validationResult;
    };

    let btnUpdateOrder_click = function () {
        $(this).prop('disabled', true);
        if (!validate()) {
            return;
        }

        var m = model.createModel();
        var json = model.captureJSON(m);

        var formData = new FormData();
        formData.append("formJson", json);
        //formData.append("file", $('#IptPicture')[0].files[0], "file");
        //formData.append("upload_file", true);
        $.ajax({
            url: '/Order/AUpdate',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                alert('完成');
            }
        });
    };

    return {
        ready: function () {
            initValidation();
            $('#BtnUpdateOrder').click(btnUpdateOrder_click);
            $('#Txt货号').blur(txt货号_blur);
        }
    };
});