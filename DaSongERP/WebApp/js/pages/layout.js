define(['jquery', 'bootstrap'], function ($, bs) {
    return {
        ready: function () {
            $.ajax({
                url: '/Order/AGetOrderCount',
                type: 'POST',
                dataType: 'JSON',
                data: {},
                success: function (data) {
                    $('.genjin-number,.import-number,.chaibao-number,.shouhou-number').empty();
                    if (data.未跟进 > 0) {
                        $('.genjin-number').text(data.未跟进);
                    }

                    if (data.未导入 > 0) {
                        $('.import-number').text(data.未导入);
                    }

                    if (data.未拆包 > 0) {
                        $('.chaibao-number').text(data.未拆包);
                    }

                    if (data.未完结售后 > 0) {
                        $('.shouhou-number').text(data.未完结售后);
                    }
                }
            });
        }
    };
});