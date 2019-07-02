define(['jquery', 'jsExtension', 'validation_result_handler'], function ($, jsExt, handlers) {

    let ValidationResult = {
        createInstance: function () {
            let validationResult = {
                validatorResults: [],
                isValid: function () { // final result
                    for (let i = 0; i < this.validatorResults.length; i++) {
                        if (this.validatorResults[i].isValid() == null) { // maybe ignore
                            continue;
                        }

                        if (this.validatorResults[i].isValid() === false) {
                            return false;
                        }
                    }

                    return true;
                }
            };

            return validationResult;
        }
    };

    let Validator = {
        createInstance: function () {
            let validator = {
                required: null, // string, should NOT eqauls
                client: null, // js script validate function
                server: null, // server url
                callback: null, // validated call back
                minLength: Number.NaN, // int
                maxLength: Number.NaN, // int
                min: null, // min value
                max: null,
                regex: null,
                target: null, // jQuery object
                validationGroup: null, // 
                hasError: false, // validator has error
                _isValid: null, // 
                isValid: function (v) {
                    if (arguments.length == 0) {
                        if (this.ignore === true) {
                            return true;
                        }

                        if (this.hasError === true) {
                            return false;
                        }

                        if (this._isValid == null) {
                            return null;
                        }

                        return this.reverse === true ? (this._isValid !== true) : (this._isValid === true);
                    }

                    if (this._isValid !== false) {
                        // set value
                        this._isValid = v == null ? null : (v === true);
                    }
                    return this;
                },
                //result: null,
                ignore: false,
                validateEmpty: false,
                validateDisabled: false,
                validateReadOnly: false,
                validatePrepare: null,
                reverse: false,
                pri: 0,
                validating: null, // event
                validated: null, // event
                autoTrim: false
            };

            let _trimValue = function (value, validator) {
                if (value == null || validator.autoTrim !== true) {
                    return value;
                }

                return $.trim(value);
            };

            // input type=text/password...  value != required
            let _validateRequiredTextBox = function (validator, targets) {
                let isValid = null;
                targets.each(function () {
                    isValid = true;
                    let v = _trimValue($(this).val(), validator);
                    if (v === validator.required) {
                        isValid = false;
                        return false; // break loop
                    }
                });

                validator.isValid(isValid);
            };

            // input type=checkbox  selectedItems.count >= (int)required
            let _validateRequiredCheckBox = function (validator, targets) {
                let minCheckedCount = 1;
                if (!String.isNullOrWhiteSpace(validator.required)) {
                    minCheckedCount = parseInt(validator.required);
                }

                if (isNaN(minCheckedCount)) { // must be int value
                    validator.hasError = true;
                    return;
                }

                let checked = targets.filter(':checked');
                validator.isValid(checked.length >= minCheckedCount);
            };

            // input type=radio  selectedValue != required
            let _validateRequiredRadio = function (validator, targets) {
                let checked = targets.filter(':checked');
                if (checked.length === 0) {
                    validator.isValid(false);
                    return;
                }

                validator.isValid(true);
                if (!String.isNullOrWhiteSpace(validator.required)) {
                    validator.isValid(checked.val() !== validator.required);
                    return;
                }
            };

            // requred select[multiple] selectedItems.count >= (int)required
            let _validateRequiredSelectMultiple = function (validator, targets) {
                let minSelectedCount = 1;
                if (!String.isNullOrWhiteSpace(validator.required)) {
                    minSelectedCount = parseInt(validator.required);
                }

                if (isNaN(minSelectedCount)) {
                    validator.hasError = true;
                    return;
                }

                let isValid = null;
                targets.each(function () {
                    isValid = true;
                    let selectedCount = this.selectedOptions.length; // selected items count
                    if (selectedCount < minSelectedCount) { // check min selected
                        isValid = false;
                        return false;
                    }
                });

                validator.isValid(isValid);
            };

            // select (single)  selectedValue != required
            let _validateRequiredSelectSingle = function (validator, targets) {
                let isValid = null;
                targets.each(function () {
                    isValid = true;
                    if (this.options.length === 0) { // 单选框无选项时，验证失败
                        isValid = false;
                        return false;
                    }

                    if (String.isNullOrEmpty(validator.required)) { // required属性为空时，如果选中的是第一项，则验证失败
                        if (this.selectedIndex === 0) {
                            isValid = false;
                            return false;
                        }
                    }
                    else if ($(this).val() === validator.required) { // required属性有值时，不能选中此值的项。
                        isValid = false;
                        return false;
                    }
                });

                validator.isValid(isValid);
            };

            // according option filter disabled and readonly
            let _filterDisabledReadOnly = function (validator) {
                let targets = validator.target;
                if (targets == null) {
                    return $();
                }

                if (validator.validateDisabled !== true) {
                    targets = targets.not(':disabled');
                }

                if (validator.validateReadOnly !== true) {
                    targets = targets.not('[readonly]');
                }

                return targets;
            };

            // required
            let _validateRequired = function (validator) {
                let all = _filterDisabledReadOnly(validator);

                let targets = all.filter('input[type=checkbox]');
                if (targets.length > 0) {
                    _validateRequiredCheckBox(validator, targets);
                }

                targets = all.filter('input[type=radio]');
                if (targets.length > 0) {
                    _validateRequiredRadio(validator, targets);
                }

                targets = all.filter('select[multiple]');
                if (targets.length > 0) {
                    _validateRequiredSelectMultiple(validator, targets);
                }

                targets = all.filter('select').not('[multiple]');
                if (targets.length > 0) {
                    _validateRequiredSelectSingle(validator, targets);
                }

                targets = all.filter('input[type=text],input[type=password],textarea,input[type=email],input[type=tel],input[type=hidden],input[type=file],input[type=datetime-local],input[type=datetime],input[type=date],input[type=time],input[type=month],input[type=search],input[type=url],input[type=week],input[type=number],input[type=color],input[type=range]');
                if (targets.length > 0) {
                    _validateRequiredTextBox(validator, targets);
                }
            };

            // client function validation
            let _validateClient = function (validator, validation) {
                return validation.functions[validator.client](validator);
            };

            // post value to server for validation
            let _validateServer = function (validator, validation, clientReturns) {
                let postData = clientReturns;
                if (postData == null) {
                    postData = {
                        value: _trimValue($.getVal(validator.target), validator)
                    };

                    if (postData.value === '' && validator.validateEmpty === false) {
                        validator.ignore = true;
                        return;
                    }
                }

                let postJson = null;

                if (typeof (postData) == 'object') { // object -> json
                    postJson = JSON.stringify(postData);
                }

                let responseObj = null;
                $.ajax({
                    url: validator.server,
                    type: 'post',
                    async: false, // important
                    dataType: 'text',
                    data: {
                        json: postJson
                    },
                    success: function (strResult, textStatus, jqXHR) {
                        responseObj = $.parseJSON(strResult);
                        validator.isValid(responseObj.IsValid === true);
                        validator.errorMessage = responseObj.errorMessage;
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        responseObj = {
                            XMLHttpRequest: XMLHttpRequest,
                            textStatus: textStatus,
                            errorThrown: errorThrown,
                            hasError: true
                        };

                        console.log((validator.id || validator.name) + ': ' + XMLHttpRequest.status + '; ' + textStatus + '; ' + errorThrown);
                        validator.hasError = true;
                    }
                });

                return responseObj;
            };
            // pattern
            let _validateRegex = function (validator) {
                let isValid = null;
                let targets = _filterDisabledReadOnly(validator);
                targets.each(function () {
                    let value = _trimValue($.getVal(this), validator);
                    if (value === '' && validator.validateEmpty !== true) {
                        return true; // ignore empty
                    }

                    isValid = validator.regex.test(value);
                    if (!isValid) {
                        isValid = false;
                        return false;
                    }
                });

                validator.isValid(isValid);
            };
            // length        minLength <= value.length <= maxLength
            let _validateLength = function (validator) {
                let isValid = null;
                let targets = _filterDisabledReadOnly(validator);
                targets.each(function () {
                    let v = _trimValue($(this).val(), validator);
                    if (v === '' && validator.validateEmpty !== true) {
                        return true;
                    }

                    isValid = true;
                    let len = v.toString().length;
                    if ((!isNaN(validator.minLength) && len < validator.minLength)
                        || (!isNaN(validator.maxLength) && len > validator.maxLength)) {
                        isValid = false;
                        return false;
                    }
                });

                validator.isValid(isValid);
            }

            // compare value,  == != > >= < <= typeof
            let _compare = function (v1, op, v2) {
                if (op == '=' || op == '==') {
                    return v1 === v2;
                }

                if (op == '!=' || op == '<>') {
                    return v1 !== v2;
                }

                if (op == '>') {
                    return v1 > v2;
                }

                if (op == '>=') {
                    return v1 >= v2;
                }

                if (op == '<') {
                    return v1 < v2;
                }

                if (op == '<=') {
                    return v1 <= v2;
                }

                if (op == 'typeof') {
                    return typeof (v1) === typeof (v2);
                }

                if (op == 'in') {
                    return v2.indexOf(v1) >= 0;
                }

                return v2.indexOf(v1) < 0;
            };

            // compare with value or control's value
            let _validateCompare = function (validator) {
                let isValid = null;
                let targets = _filterDisabledReadOnly(validator);
                targets.each(function () {
                    let v = _trimValue($(this).val(), validator);
                    if (v === '' && validator.validateEmpty === false) {
                        return true;
                    }

                    isValid = true;
                    v = convert(v, validator.dataType);
                    if (v == null) {
                        isValid = false;
                        return false;
                    }

                    if (validator.compareValue != null) {
                        if (_compare(v, validator.compareOperator, validator.compareValue) !== true) {
                            isValid = false;
                            return false;
                        }
                    }

                    // only support when compareValue is null
                    if (validator.compareValue1 != null) {
                        if (_compare(v, validator.compareOperator1, validator.compareValue1) !== true) {
                            isValid = false;
                            return false;
                        }
                    }

                    if (validator.compareValue2 != null) {
                        if (_compare(v, validator.compareOperator2, validator.compareValue2) !== true) {
                            isValid = false;
                            return false;
                        }
                    }
                });

                validator.isValid(isValid);
            };

            let _validate = function (validator, validation) {
                if (validator.validating != null) {
                    validation.functions[validator.validating](validator);
                }
                else {
                    validation.validating(validator);
                }

                if (validator.hasError === true) {
                    return validator;
                }

                if (validator.ignore === true || validator.myself.is(':hidden')) {
                    return validator;
                }

                let serverValidateResponse = null;
                try {
                    let clientReturns = null;
                    if (!String.isNullOrWhiteSpace(validator.client)) {
                        clientReturns = _validateClient(validator, validation);
                    }

                    if (validator.ignore === true) {
                        return validator;
                    }

                    if (!String.isNullOrWhiteSpace(validator.server)) {
                        serverValidateResponse = _validateServer(validator, validation, clientReturns);
                    }

                    if (validator.required != null) {
                        _validateRequired(validator);
                    }

                    if (validator.regex != null) {
                        _validateRegex(validator);
                    }

                    if (!isNaN(validator.minLength) || !isNaN(validator.maxLength)) {
                        _validateLength(validator);
                    }

                    if (validator.dataType != null) {
                        _validateCompare(validator);
                    }
                }
                catch (validateErr) {
                    validator.hasError = true;
                    console.log((validator.id || validator.name) + ': ' + validateErr);
                }

                let execValidated = true;
                if (validator.callback != null) {
                    execValidated = validation.functions[validator.callback](validator, serverValidateResponse);
                }

                if (execValidated !== false) {
                    if (validator.validated != null) {
                        validation.functions[validator.validated](validator, validation);
                    }
                    else {
                        validation.validated(validator, validation);
                    }
                }

                return validator;
            };

            validator.validate = function (validation) {
                return _validate(this, validation);
            };

            return validator;
        }
    };

    let initGeneric = function (v, validator) {
        validator.id = v.attr('id');
        validator.name = v.attr('name');
        validator.ignore = String.tryToLowerCase($.getAttr(v, 'validate-ignore')) === 'true';
        validator.validateEmpty = String.tryToLowerCase($.getAttr(v, 'validate-empty')) !== 'false';
        validator.validateDisabled = String.tryToLowerCase($.getAttr(v, 'validate-disabled')) === 'true';
        validator.validateReadOnly = String.tryToLowerCase($.getAttr(v, 'validate-readonly')) === 'true';
        validator.client = String.isNullOrWhiteSpace($.getAttr(v, 'validate-client'), null);
        validator.reverse = String.tryToLowerCase($.getAttr(v, 'validate-reverse')) === 'true';
        validator.pri = parseFloat($.getAttr(v, 'validate-pri'));
        if (isNaN(validator.pri)) {
            validator.pri = 0;
        }

        validator.isKey = $.getAttr(v, 'key-validate') === 'true';
        validator.callback = String.isNullOrWhiteSpace($.getAttr(v, 'validate-callback'), null);
        validator.validating = String.isNullOrWhiteSpace($.getAttr(v, 'validating'), null);
        validator.validated = String.isNullOrWhiteSpace($.getAttr(v, 'validated'), null);
        validator.errorWrappers = String.isNullOrWhiteSpace($.getAttr(v, 'error-wrappers'), null);
        validator.autoTrim = String.tryToLowerCase($.getAttr(v, 'auto-trim')) === 'true';
    };

    let initRequired = function (v, validator) {
        let attrRequired = v.attr('data-required');
        if (attrRequired != null) {
            validator.required = attrRequired;
            return true;
        }

        if (v.attr('required') != null) {
            validator.required = '';
            return true;
        }

        return false;
    };

    let initServer = function (v, validator) {
        validator.server = String.isNullOrWhiteSpace($.getAttr(v, 'validate-server'), null);
        return false;
    };

    let initRegex = function (v, validator) {
        let regex = $.getAttr(v, 'validate-regex');
        if (String.isNullOrWhiteSpace(regex)) {
            return false;
        }

        let regexAttr = $.getAttr(v, 'validate-regex-attr');
        try {
            if (String.isNullOrWhiteSpace(regexAttr)) {
                regex = new RegExp(regex);
            }
            else {
                regex = new RegExp(regex, regexAttr);
            }
        } catch (ex) {
            validator.hasError = true;
            console.log((validator.id || validator.name) + ': regex pattern error: "' + regex + '"; ' + regexAttr);
            return true;
        }

        validator.regex = regex;
        return true;
    };

    let initLength = function (v, validator) {
        let minLength = parseInt($.getAttr(v, 'minlength'));
        let maxLength = parseInt($.getAttr(v, 'maxlength'));
        validator.minLength = minLength;
        validator.maxLength = maxLength;
        return !isNaN(minLength) || !isNaN(maxLength);
    };

    let supportDataTypes = ['string', 'int', 'number', 'float', 'date', 'datetime', 'time'];

    let supportOperators = ['=', '==', '!=', '<>', '>', '>=', '<', '<=', 'typeof', 'in', 'not-in'];

    let initCompare = function (v, validator) {
        let dataType = String.tryToLowerCase($.getAttr(v, 'type'));
        if (String.isNullOrEmpty(dataType)) {
            return true;
        }

        if (supportDataTypes.indexOf(dataType) < 0) {
            Console.log((validator.id || validator.name) + ': unsupport data type ' + dataType);
            validator.hasError = true;
            return true;
        }

        dataType = dataType.toLowerCase();
        let attrCompareValue = $.getAttr(v, 'compare-value');
        let attrCompareValue1 = $.getAttr(v, 'compare-value1');
        let attrCompareValue2 = $.getAttr(v, 'compare-value2');

        let compareSelector = $.getAttr(v, 'compare-selector');
        let compareSelector1 = $.getAttr(v, 'compare-selector1');
        let compareSelector2 = $.getAttr(v, 'compare-selector2');

        let compareOperator = String.isNullOrWhiteSpace($.getAttr(v, 'compare-operator'), '=');
        if (supportOperators.indexOf(compareOperator) < 0) {
            validator.hasError = true;
            return true;
        }

        let compareOperator1 = String.isNullOrWhiteSpace($.getAttr(v, 'compare-operator1'), '>=');
        if (supportOperators.indexOf(compareOperator1) < 0) {
            validator.hasError = true;
            return true;
        }

        let compareOperator2 = String.isNullOrWhiteSpace($.getAttr(v, 'compare-operator2'), ((dataType == 'date' || dataType == 'datetime') ? '<' : '<='));
        if (supportOperators.indexOf(compareOperator2) < 0) {
            validator.hasError = true;
            return true;
        }

        let compareValue = convert($(compareSelector).val(), dataType, attrCompareValue, ['in', 'not-in'].indexOf(compareOperator) >= 0);
        let compareValue1 = convert($(compareSelector1).val(), dataType, attrCompareValue1, ['in', 'not-in'].indexOf(compareOperator1) >= 0);
        let compareValue2 = convert($(compareSelector2).val(), dataType, attrCompareValue2, ['in', 'not-in'].indexOf(compareOperator2) >= 0);

        validator.dataType = dataType;
        validator.compareOperator = compareOperator;
        validator.compareOperator1 = compareOperator1;
        validator.compareOperator2 = compareOperator2;
        validator.compareValue = compareValue;
        validator.compareValue1 = compareValue1;
        validator.compareValue2 = compareValue2;

        return true;
    };

    // 收集验证器
    // group: 验证组
    let gatherValidators = function (group) {
        group = String.isNullOrWhiteSpace(group, 'default');
        let validators = null;
        let validationGroups = {
            'default': []
        };

        let groupNames = ['default'];

        $('.validator').each(function () {
            let validator = Validator.createInstance();
            let v = $(this);
            validator.myself = v;
            if (validators == null) {
                validators = v;
            }
            else {
                validators = validators.add(v);
            }

            let vg = $.getAttr(v, 'validation-group');

            if (vg == null) {
                let vgp = v.closest('[data-validation-group],[validation-group]');
                if (vgp.length == 0) {
                    // 没有父级验证组元素
                    vg = 'default';
                }
                else {
                    vg = $.getAttr(vgp, 'validation-group');
                }
            }

            if (String.isNullOrWhiteSpace(vg)) {
                vg = 'default'; // 父级验证组元素默认名
            }

            if (vg !== group) {
                return true;
            }

            let validateTarget = v;
            let attrValidateTarget = $.getAttr(v, 'validate-target');

            if (attrValidateTarget != null) {
                validateTarget = $(attrValidateTarget);
            }

            validator.target = validateTarget;

            initGeneric(v, validator);
            initRequired(v, validator);
            initServer(v, validator);
            initRegex(v, validator);
            initLength(v, validator);
            initCompare(v, validator);

            if (validationGroups[vg] == null) {
                validationGroups[vg] = [];
                groupNames.push(vg);
            }

            validationGroups[vg].push(validator);
        });

        let i;
        for (i = 0; i < groupNames.length; i++) {
            let g = validationGroups[groupNames[i]];
            // sort by pri desc
            g.sort(function (a, b) {
                if (a.pri == b.pri) {
                    return 0;
                }

                return a.pri < b.pri ? 1 : -1;
            });
        }

        return validationGroups[group];
    };
    // 验证一组
    // group 验证组
    let _validate = function (groupOrRules, validation, async) {
        let type = typeof (groupOrRules);
        let validators = null;
        if (type == 'string') {
            validators = gatherValidators(groupOrRules);
        }
        else if (Array.isArray(groupOrRules)) {
            validators = [];
            for (let i = 0; i < groupOrRules.length; i++) {
                validators = validators.concat(gatherValidators(groupOrRules[i]));
            }
        }
        //else if (type == 'object') {
        //    validators = [$.extend(Validator.createInstance(), groupOrRules)];
        //}

        let dtd = $.Deferred();
        let syncFunc = function () {
            let result = ValidationResult.createInstance();
            (validators || []).forEach(function (value, i, array) {
                let r = value.validate(validation); // 遍历验证器进行验证
                if (r != null) {
                    result.validatorResults.push(r);
                    if (r.isValid() === false && r.isKey === true) { // 关键验证失败时，停止之后的验证
                        return false;
                    }
                }
            });

            (validators || []).forEach(function (value, i, array) {
                if (value.errorWrappers == null) {
                    $(value.myself).closest('.form-group').removeClass('validating');
                } else {
                    $(value.errorWrappers).removeClass('validating');
                }
            });

            return result.isValid();
        };

        let asyncFunc = function () {
            let result = syncFunc();

            if (result === true) {
                dtd.resolve(result);
            }
            else {
                dtd.reject(result);
            }
        };

        if (async === true) {
            // 异步执行验证
            setTimeout(asyncFunc, 1);
            return dtd.promise();
        }

        let isValid = syncFunc();
        return isValid;
    };

    // 验证前事件，应移动到验证功能之外
    let validatingEvent = {
        defaultHandler: function (validator) {
            if (validator.errorWrappers == null) {
                let formGroup = validator.target.closest('.form-group');
                if (!formGroup.hasClass('validating')) {
                    formGroup.removeClass('has-error').addClass('validating');
                }

                $(validator.myself).removeClass('has-error');
                //validator.target.closest('.form-group').find('.has-error').addBack().removeClass('has-error');
            } else {
                if ($(validator.errorWrappers).hasClass('validating')) {
                    $(validator.errorWrappers).removeClass('has-error').addClass('validating');
                }
            }
        }
    };
    // 验证后事件，应移动到验证功能之外
    //let validatedEvent = {
    //    defaultHandler: function (validator) {
    //        let hasError = validator.isValid() === false;
    //        if (validator.errorWrappers == null) {
    //            validator.target.closest('.form-group').toggleClass('has-error', hasError);
    //            if (validator.myself != null) {
    //                validator.myself.toggleClass('has-error', hasError);
    //                if (!String.isNullOrWhiteSpace(validator.errorMessage)) {
    //                    let lblErrorMessage = validator.myself.find('.error-message:first');
    //                    if (lblErrorMessage.length == 0) {
    //                        lblErrorMessage = $('<div></div>').addClass('error-message');
    //                        validator.myself.append(lblErrorMessage);
    //                    }

    //                    lblErrorMessage.html(validator.errorMessage);
    //                }
    //            }

    //            let controlWrapper = validator.target.closest('.form-control-wrapper');
    //            if (controlWrapper.length == 0) {
    //                validator.target.toggleClass('has-error', hasError);
    //            }
    //            else {
    //                controlWrapper.toggleClass('has-error', hasError);
    //            }
    //        }
    //        else {
    //            $(validator.errorWrappers).toggleClass('has-error', hasError);
    //        }
    //    }
    //};

    let validation = {
        functions: {},
        result: null,
        invalidCount: 0,
        validate: function (groupOrRules, async) {
            this.invalidCount = 0;
            if (groupOrRules == null) {
                throw 'Argument is null: groupOrRules';
            }

            return _validate(groupOrRules, this, async);
        },
        validating: validatingEvent.defaultHandler,
        validated: handlers.dynamicErrorMessageHandler,
        newValidator: function (v) {
            return Validator.createInstance();
        }
    };

    return validation;
});

// TODO:
//  1. 正则库
