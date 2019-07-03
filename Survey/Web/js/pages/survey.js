define(['jquery'], function ($) {
    let docReady = function () {
        console.log('survey docReady');
        $('.btn-answer').click(btnAnswer_click);
        $('#BtnSubmit').click(btnSubmit_click);
    };

    let btnAnswer_click = function () {
        $(this).addClass('active');
        let subView = $(this).closest('.sub-view');
        moveNextStepView(subView);
    };

    let moveNextStepView = function (currentStepView) {
        let nextView = currentStepView.next('.sub-view');
        $('.sub-view').toggleClass('active', false);
        nextView.toggleClass('active', true);
    };

    let btnSubmit_click = function () {
        let subView = $(this).closest('.sub-view');
        moveNextStepView(subView);
    };

    return {
        ready: docReady
    };
});