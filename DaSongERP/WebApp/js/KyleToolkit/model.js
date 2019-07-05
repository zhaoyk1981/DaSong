define(['jquery'], function ($) {
    let getProp = function (options) {
        let backStore = {
            value: null
        };

        let settings = {
            getter: function () {
                return this.value;
            },
            setter: function (value) {
                this.value = value;
            }
        };

        $.extend(settings, options);

        return function () {
            if (arguments.length == 0) {
                return settings.getter.call(backStore);
            }
            else {
                settings.setter.apply(backStore, arguments);
            }
        };
    };

    let createModel = function (options) {
        options = options || {};
        options.model = options.model || {};
        options.procNames = [];
        options.formWrapper = $(options.formWrapper || 'form');
        if (options.formWrapper.length == 0) {
            return options.model;
        }

        $(options.formWrapper).find('*[name]').each(function () {
            let ctrl = $(this);
            let name = ctrl.prop('name');
            if (options.procNames.indexOf(name) >= 0) {
                return true;
            }

            if (ctrl.is('select.flag[multiple]')) {
                let optgroups = ctrl.children('optgroup');
                if (optgroups.length > 0) {
                    options.model[name] = getProp({
                        getter: function () {
                            let value = {};
                            optgroups.each(function () {
                                let dept = $(this).attr('value');
                                let selectedValue = 0;
                                optgroups.find('option:selected').each(function () {
                                    selectedValue += parseInt($(this).val());
                                });
                                if (selectedValue > 0) {
                                    value[dept] = selectedValue;
                                }
                            });

                            return value;
                        },
                        setter: function (value) {
                            optgroups.each(function () {
                                let dept = $(this).attr('value') || '';
                                if (dept.length === 0 || value[dept] == null) {
                                    return true;
                                }

                                optgroups.find('option').each(function () {
                                    let v = parseInt($(this).val());
                                    $(this).prop('selected', (value[dept] & v) === v);
                                });
                            });
                        }
                    });
                }
                else {
                    options.model[name] = getProp({
                        getter: function () {
                            let value = 0;
                            ctrl.children('option:selected').each(function () {
                                value += parseInt($(this).val());
                            });

                            return value;
                        },
                        setter: function (value) {
                            optgroups.each(function () {
                                let dept = $(this).attr('value') || '';
                                if (dept.length === 0 || value[dept] == null) {
                                    return true;
                                }

                                optgroups.find('option').each(function () {
                                    let v = parseInt($(this).val());
                                    $(this).prop('selected', (value[dept] & v) === v);
                                });
                            });
                        }
                    });
                }
            } else if (ctrl.is('input[type=text],input[type=password],input[type=hidden],input[type=date],input[type=datetime-local],input[type=number],input[type=email],input[type=date],input[type=month],input[type=range],input[type=search],input[type=tel],input[type=time],input[type=url],input[type=week],input[type=color],input[type=datetime],textarea,select')) {
                options.model[name] = getProp({
                    getter: function () {
                        if (ctrl.attr('data-type') === 'int') {
                            return parseInt(ctrl.val());
                        }

                        if (ctrl.attr('trim') === 'false' || ctrl.is('input[type=password]')) {
                            return ctrl.val();
                        }

                        return $.trim(ctrl.val());
                    },
                    setter: function (value) {
                        ctrl.val(value);
                    }
                });
            } else if (ctrl.is('input[type=checkbox]')) {
                let ctrls = $('input[name="' + name + '"]');
                if (ctrls.length === 1 && ctrls.attr('data-type') === 'bool') {
                    options.model[name] = getProp({
                        getter: function () {
                            return ctrl.prop('checked');
                        },
                        setter: function (value) {
                            ctrl.prop('checked', value);
                        }
                    });
                } else {
                    options.model[name] = getProp({
                        getter: function () {
                            let vals = [];
                            let isFlag = ctrls.hasClass('flag');
                            if (isFlag === true) {
                                vals = 0;
                            }

                            ctrls.filter(':checked').each(function () {
                                let dataType = $(this).attr('data-type') || 'string';
                                let val = this.value;
                                switch (dataType) {
                                    case 'int':
                                        val = parseInt(val);
                                        break;
                                    case 'bool':
                                        val = val === 'true'
                                        break;
                                }

                                if (isFlag) {
                                    vals += val;
                                }
                                else {
                                    vals.push(val);
                                }
                            });
                            return vals;
                        },
                        setter: function (value) {
                            let vals = value;
                            ctrls.each(function () {
                                this.checked = vals.length > 0 && vals.indexOf(this.value) >= 0;
                            });
                        }
                    });
                }
            } else if (ctrl.is('input[type=radio]')) {
                let ctrls = $('input[name="' + name + '"]');
                options.model[name] = getProp({
                    getter: function () {
                        let v = null;
                        ctrls.filter(':checked').each(function () {
                            let dataType = $(this).attr('data-type') || 'string';
                            let val = this.value;
                            switch (dataType) {
                                case 'int':
                                    v = parseInt(val);
                                    break;
                                case 'bool':
                                    v = val === 'true'
                                    break;
                                default:
                                    v = val;
                                    break;
                            }

                            return false;
                        });

                        return v;
                    },
                    setter: function (value) {
                        ctrls.each(function () {
                            this.checked = this.value == (value || '').toString();
                        });
                    }
                });
            }

            options.procNames.push(name);
            return true;
        });

        return options.model;
    };

    let capture = function (sourceModel, ignoreProps) {
        ignoreProps = ignoreProps || [];
        let tgt = {};
        for (let p in sourceModel) {
            if (ignoreProps.indexOf(p) >= 0) {
                continue;
            }

            tgt[p] = sourceModel[p]();
        }

        return tgt;
    };

    let buildFormData = function (sourceModel, ignoreProps) {
        ignoreProps = ignoreProps || [];
        let tgt = new FormData();
        for (let p in sourceModel) {
            if (ignoreProps.indexOf(p) >= 0) {
                continue;
            }

            tgt.append(p, sourceModel[p]());
        }

        return tgt;
    };

    let captureJSON = function (sourceModel, ignoreProps) {
        ignoreProps = ignoreProps || [];
        let tgt = {};
        for (let p in sourceModel) {
            if (ignoreProps.indexOf(p) >= 0) {
                continue;
            }

            tgt[p] = sourceModel[p]();
        }

        return JSON.stringify(tgt);
    };

    return {
        createModel: createModel,
        capture: capture,
        captureJSON: captureJSON,
        buildFormData: buildFormData
    };
});
