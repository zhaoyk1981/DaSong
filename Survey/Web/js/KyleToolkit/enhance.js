define(['jquery'], function ($) {


    let isNullOrEmpty = function (str, trim) {
        if (str == null) {
            return true;
        }

        if (typeof (str) != 'string') {
            throw 'str is not a string';
        }

        if (trim === false) {
            str = $.trim(str);
        }

        return str.length === 0;
    };

    //#region 清除autoComplete=off的控件的值
    let autoCompleteOff = function () {
        $('input[autocomplete=off]:not([value]), [autocomplete=off] input:not([value])')
            .filter('[type=text],[type=search],[type=url],[type=tel],[type=telephone],[type=email],[type=password],[type=datepickers],[type=range],[type=color]')
            .val('');
    };
    //#endregion 清除autoComplete=off的控件的值

    //#region 支持on-enter事件
    let defaultButton = function () {
        $("body").delegate("[on-enter]", "keyup", function (event) {
            try {
                if (event.keyCode == 13) {
                    event.preventDefault();
                    let selector = '';
                    let def = $(this);
                    do {
                        selector = $.trim(def.attr('default-button'));
                        def = def.parent().closest('[default-button]');
                    } while (def.length > 0 && (selector == null || String.isNullOrEmpty(selector)));

                    if ($(selector).is('a[href]')) {
                        let r = $(selector).triggerHandler('click');
                        if (r !== false) {
                            window.location = $(selector).attr('href');
                        }
                    }
                    else {
                        $(selector).trigger('click');
                    }
                }
            }
            catch (exception) {
                console.log(exception);
            }
        });
    };

    let QueryString = function () {
        let search = window.location.search;
        let qs = {
        };
        if (String.isNullOrEmpty(search)) {
            return qs;
        }

        search = search.substr(1);
        let ary = search.split('&');
        for (let i = 0; i < ary.length; i++) {
            let itm = ary[i].split('=');
            let key = itm[0];
            let value = '';
            if (itm.length > 1) {
                value = itm[1];
            }

            qs[key] = value;
        }

        return qs;
    };

    let HTMLEncode = function (html) {
        let temp = document.createElement("div");
        (temp.textContent !== null) ? (temp.textContent = html) : (temp.innerText = html);
        let output = temp.innerHTML;
        temp = null;
        return output;
    };

    let HTMLDecode = function (text) {
        let temp = document.createElement("div");
        temp.innerHTML = text;
        let output = temp.innerText || temp.textContent;
        temp = null;
        return output;
    };

    let output = {
        QueryString: QueryString,
        HTMLEncode: HTMLEncode,
        HTMLDecode: HTMLDecode
    };

    $(function () {
        String.isNullOrEmpty = isNullOrEmpty;
        autoCompleteOff();
        defaultButton();
    });

    return output;
});