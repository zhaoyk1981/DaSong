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
        var validationResult = validation.validate(['CreateOrder']);
        if (validationResult !== true) {
            $('#BtnCreateOrder').prop('disabled', false);
        }

        return validationResult;
    };

    let btnCreateOrder_click = function () {
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
            url: '/Order/ACreate',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                alert(data.Success === true ? '操作成功' : '操作失败');
            }
        });
    };

    return {
        ready: function () {
            initValidation();
            $('#BtnCreateOrder').click(btnCreateOrder_click);
            $('#Txt货号').blur(txt货号_blur);
        }
    };
});