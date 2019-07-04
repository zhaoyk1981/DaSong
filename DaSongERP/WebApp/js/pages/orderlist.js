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

    let btnGenJinOrder_click = function () {
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
                    window.open('/Order/GenJin/' + data.OrderID);
                }
                else {
                    $('#LblMessage').text('没有找到订单');
                }
            }
        });
    };

    let btnChaiBao_click = function () {
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
                    window.open('/Order/ChaiBao/' + data.OrderID);
                }
                else {
                    $('#LblMessage').text('没有找到订单');
                }
            }
        });
    };

    let btnShouHou_click = function () {
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
                    window.open('/Order/ShouHou/' + data.OrderID);
                }
                else {
                    $('#LblMessage').text('没有找到订单');
                }
            }
        });
    };

    let btnKeFu_click = function () {
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
                    window.open('/Order/KeFu/' + data.OrderID);
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
            $('#BtnGenJinOrder').click(btnGenJinOrder_click);
            $('#BtnChaiBao').click(btnChaiBao_click);
            $('#BtnShouHou').click(btnShouHou_click);
            $('#BtnKeFu').click(btnKeFu_click);
        }
    };
});