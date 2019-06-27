define(['jquery'], function ($) {
    let docReady = function () {
        console.log('survey docReady');
    };

    return {
        ready: docReady
    };
});