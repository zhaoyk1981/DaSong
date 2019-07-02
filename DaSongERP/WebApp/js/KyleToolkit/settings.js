define([], function () {
    let log = {
        enabled: true,
        postServer: true,
        postServerLevel: '',
        serverUrl: '/log/append'
    };

    return {
        getLogSettings: function () {
            return log;
        }
    };
});