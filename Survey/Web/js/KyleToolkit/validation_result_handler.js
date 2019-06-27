define(['jquery'], function ($) {
    let handlers = {
        dynamicErrorMessageHandler: function (validator) {
            let invalid = validator.isValid() === false;
            if (validator.errorWrappers == null) {
                if (invalid === true) {
                    validator.target.closest('.form-group').toggleClass('has-error', true);
                }

                if (validator.myself != null) {
                    validator.myself.toggleClass('has-error', invalid);
                    if (!String.isNullOrWhiteSpace(validator.errorMessage)) {
                        let lblErrorMessage = validator.myself.find('.error-message:first');
                        if (lblErrorMessage.length == 0) {
                            lblErrorMessage = $('<div></div>').addClass('error-message');
                            validator.myself.append(lblErrorMessage);
                        }

                        lblErrorMessage.html(validator.errorMessage);
                    }
                }

                let controlWrapper = validator.target.closest('.form-control-wrapper');
                if (controlWrapper.length == 0) {
                    validator.target.toggleClass('has-error', invalid);
                }
                else {
                    controlWrapper.toggleClass('has-error', invalid);
                }
            }
            else {
                $(validator.errorWrappers).toggleClass('has-error', invalid);
            }
        },
        alertHandler: function (validator, validation) {
            let invalid = validator.isValid() === false;
            if (invalid) {
                validation.invalidCount++;
            }

            if (validator.errorWrappers == null) {
                if (invalid === true) {
                    validator.target.closest('.form-group').toggleClass('has-error', true);
                }

                if (validator.myself != null) {
                    //validator.myself.toggleClass('has-error', hasError);
                    if (invalid) {
                        if (String.isNullOrWhiteSpace(validator.errorMessage)) {
                            let lblErrorMessage = validator.myself.find('.error-message:first');
                            if (lblErrorMessage.length > 0) {
                                validator.errorMessage = lblErrorMessage.text();
                            }
                        }

                        if (validation.invalidCount <= 1) {
                            alert(validator.errorMessage);
                        }
                    }
                }

                let controlWrapper = validator.target.closest('.form-control-wrapper');
                if (controlWrapper.length == 0) {
                    validator.target.toggleClass('has-error', invalid);
                }
                else {
                    controlWrapper.toggleClass('has-error', invalid);
                }
            }
            else {
                //$(validator.errorWrappers).toggleClass('has-error', hasError);
            }
        }
    };
    return handlers;
});