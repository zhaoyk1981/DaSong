if (sessionStorage.getItem('ClientTS') == null && window.debug === 'DEBUG') {
    sessionStorage.setItem('ClientTS', new Date().getTime().toString());
}

require.config({
    urlArgs: "buildver=" + sessionStorage.getItem('buildVer') + (sessionStorage.getItem('ClientSession') || ''),
    baseUrl: '/js/pages',
    waitSeconds: 0,
    paths: {
        jquery: '/scripts/jquery-3.4.1.min',
        bootstrap: '/scripts/bootstrap.bundle.min',
        "requirejstext": "/scripts/text",
        kyle_toolkit_settings: '/js/KyleToolkit/settings',
        jsExtension: '/js/KyleToolkit/jsExtension',
        kyle_toolkit_validation: '/js/KyleToolkit/validation',
        validation_result_handler: '/js/KyleToolkit/validation_result_handler',
        kyle_toolkit_log: '/js/KyleToolkit/log',
        kyle_toolkit_repeater: '/js/KyleToolkit/repeater',
        popup: '/js/KyleToolkit/popup',
        kyle_toolkit_model: '/js/KyleToolkit/model',
        kyle_toolkit_enhance: '/js/KyleToolkit/enhance',
        mustache: '/scripts/mustache',
        select2: '/scripts/select2.min',
        select2zhcn: '/scripts/i18n/zh-CN',
        clipboard: '/scripts/clipboard.min'
    },
    shim: {
        bootstrap: ["jquery"],
    }
});

require(['jquery', 'kyle_toolkit_enhance'], function ($) {
    $(function () {
        $.ajaxSetup({
            timeout: 120000 //120秒
        });

        $('[data-page-js]').each(function () {
            let sender = $(this);
            let pagejs = sender.attr('data-page-js');
            if (pagejs != null) {
                require([pagejs], function (p) {
                    if (p == null) {
                        console.log(pagejs + '.js not found!');
                        return;
                    }

                    let vmjson = sender.attr('vm-json');
                    sender.removeAttr('vm-json');
                    let vm = {};
                    if (vmjson != null && vmjson.length > 0) {
                        try {
                            vm = JSON.parse(vmjson);
                        }
                        catch (exception) {
                            vm = {};
                        }
                    }

                    if (typeof (p.ready) === 'function') {
                        p.ready(vm);
                    }
                });
            }
        });
    });
});
