define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let btnEditOrder_click = function () {
        $('#LblMessage').empty();
        var jd订单号 = $.trim($('#TxtJD订单号').val());
        if (jd订单号.length === 0) {
            return;
        }

        $.ajax({
            url: '/Order/AGetOrderID',
            type: 'POST',
            dataType: 'JSON',
            data: {
                jdoid: jd订单号
            },
            success: function (data) {
                if (data.Success) {
                    window.open('/Order/Edit/' + data.OrderID);
                }
                else {
                    $('#LblMessage').text('没有找到订单');
                }
            }
        });
    };

    return {
        ready: function () {
            $('#BtnEditOrder').click(btnEditOrder_click);
        }
    };
});