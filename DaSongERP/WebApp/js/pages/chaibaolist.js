define(['jquery', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, enhance, model, validation) {
    let btnSearch_click = function () {
        let s = encodeURI($.trim($('#TxtSearch').val()));
        window.location = '/Order/ChaiBaoList?search=' + s;
    };

    let btnChaiBao_click = function () {
        let 来快递单号 = $.trim($('#TxtSearch').val());
        if (来快递单号 === '') {
            return false;
        }

        $.ajax({
            url: '/Order/AGetOrderID',
            type: 'POST',
            dataType: 'JSON',
            data: {
                来快递单号: 来快递单号
            },
            success: function (data) {
                if (data.ID !== '') {
                    window.open('/Order/ChaiBao/' + data.ID);
                    return;
                }

                btnSearch_click();
            }
        });
    };

    return {
        ready: function () {
            $('#BtnSearch').click(btnSearch_click);
            $('#BtnChaiBao').click(btnChaiBao_click);
            $('#TxtSearch').focus();
        }
    };
});