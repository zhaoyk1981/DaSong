define(['jquery'], function ($) {
    return {
        ready: function () {
        },
        init: function () {
            console.log('popup_toolkit: init');
            if ($("[outside-close='true']").length > 0) {
                $(document).delegate('*', 'click', function (event) {
                    let selector = "[popup][outside-close='true'][visible='true']";
                    let pc = $(this).closest(selector);
                    let p = $(selector).not(this).not(pc);
                    if (p.length > 0) {
                        p.each(function () {
                            $(this).attr('visible', 'false');
                        });

                        event.stopPropagation();
                    }
                    else if ($(this).is(selector)) {
                        event.stopPropagation();
                    }
                });
            }

            $('[popup]').delegate('.popup-close', 'click', function (event) {
                let p = $(this).closest('[popup]');
                if (p.is("[visible='true']")) {
                    p.attr('visible', 'false');
                }
                else if (p.css('display')=="block") {
                    p.css('display', 'none');
                }

                event.stopPropagation();
            });
            $('[target-popup]').click(function (event) {
                let popup = $($(this).attr('target-popup'));
                let visible = popup.attr('visible');
                popup.attr('visible', visible === 'true' ? 'false' : 'true');
                event.stopPropagation();
            });
        }
    };
});