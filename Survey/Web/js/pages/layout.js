define(['jquery', 'bootstrap'], function ($, bs) {
    return {
        ready: function () {
            $('.menu-static').on('click', function () {
                $(this).closest('.menu-v').toggleClass('exp');
            });

            $('.collapse-ctrl').on('click', function () {
                $('.body').toggleClass('collapsed');
            });

            $('.menu-active').each(function () {
                let menu = $("[menu-id='" + $(this).val() + "']");
                menu.addClass('active').closest('.menu-item').addClass('exp');
            });
        }
    };
});