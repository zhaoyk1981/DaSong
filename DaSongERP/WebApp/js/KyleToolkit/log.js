define(['log4javascript', 'jquery', 'kyle_toolkit_settings', 'jsExtension'], function (log4javascript, $, settings, jsExt) {
    let logSettings = settings.getLogSettings();
    let getLogger = function () {
        let logger = log4javascript.getDefaultLogger();
        log4javascript.setEnabled(logSettings.enabled);
        if (logSettings.postServer === true) {
            let ajaxAppender = new log4javascript.AjaxAppender(logSettings.serverUrl);
            ajaxAppender.setWaitForResponse(false);
            ajaxAppender.setLayout(new log4javascript.JsonLayout());
            //ajaxAppender.setRequestSuccessCallback(requestCallback);
            logger.addAppender(ajaxAppender);
        }

        return logger;
    };

    return {
        TRACE: 'trace',
        DEBUG: 'debug',
        INFO: 'info',
        WARN: 'warn',
        ERROR: 'error',
        FATAL: 'fatal',
        enable: function (value) {
            logSettings.enabled = value;
        },
        log: function (logType) {
            let logger = getLogger();
            if (logType == null) {
                logger.error('logType required');
                return;
            }

            if (logType.toLowerCase() === this.TRACE) {
                logger.trace.apply(logger, jsExt.arguments2Array(arguments, 1));
            }
            else if (logType.toLowerCase() == this.DEBUG) {
                logger.debug.apply(logger, jsExt.arguments2Array(arguments, 1));
            }
            else if (logType == this.INFO) {
                logger.info.apply(logger, jsExt.arguments2Array(arguments, 1));
            }
            else if (logType.toLowerCase() == this.WARN) {
                logger.warn.apply(logger, jsExt.arguments2Array(arguments, 1));
            }
            else if (logType.toLowerCase() == this.ERROR) {
                logger.error.apply(logger, jsExt.arguments2Array(arguments, 1));
            }
            else if (logType.toLowerCase() == this.FATAL) {
                logger.fatal.apply(logger, jsExt.arguments2Array(arguments, 1));
            }
        },

    };
});




