define(['jquery'], function ($) {
    window.String.isNullOrEmpty = function (str, defaultValue) {
        let result = str == null || str.length == 0;
        if (arguments.length == 1) {
            return result;
        }

        return result === true ? defaultValue : str;
    };

    window.String.isNullOrWhiteSpace = function (str, defaultValue) {
        let result = String.isNullOrEmpty(str) || /^\s*$/.test(str);
        if (arguments.length == 1) {
            return result;
        }

        return result === true ? defaultValue : str;
    };

    window.String.tryToLowerCase = function (str) {
        if (str == null) {
            return null;
        }

        return str.toString().toLowerCase();
    };

    window.String.tryToUpperCase = function (str) {
        if (str == null) {
            return null;
        }

        return str.toString().toUpperCase();
    };
    // dataPrefix: bool, true:视data-attr与attr相同, 默认; false: 仅支持attr
    // dataPrefixFirst: bool, true: data-attr优先，默认; false: attr优先
    $.extend({
        getAttr: function (target, attr, dataPrefix, dataPrefixFirst) {
            if (target == null || attr == null) {
                return null;
            }

            dataPrefix = dataPrefix == null ? true : dataPrefix;
            dataPrefixFirst = dataPrefixFirst == null ? true : dataPrefixFirst;
            let attrValue = $(target).attr(attr);
            if (dataPrefix === false) {
                return attrValue;
            }

            let dataAttrValue = $(target).attr('data-' + attr);
            if (dataPrefixFirst) {
                return dataAttrValue == null ? attrValue : dataAttrValue;
            }

            return attrValue == null ? dataAttrValue : attrValue;
        },
        getVal: function (target) {
            if (target == null) {
                return null;
            }

            let tgt = $(target);
            if (tgt.filter('input[type=checkbox]').length > 0) {
                let values = {};
                let names = [];
                tgt.filter('input[type=checkbox]:checked').each(function () {
                    let name = $(this).prop('name');
                    if (names.indexOf(name) < 0) {
                        names.push(name);
                        values[name] = [];
                    }

                    values[name].push($(this).val());
                });

                if (names.length == 0) {
                    return [];
                }

                if (names.length == 1) {
                    return values[name];
                }

                return values;
            }

            if (tgt.filter('input[type=radio]').length > 0) {
                let values = {};
                let names = [];
                tgt.filter('input[type=radio]:checked').each(function () {
                    let name = $(this).prop('name');
                    if (names.indexOf(name) < 0) {
                        names.push(name);
                    }

                    values[name] = $(this).val();
                });

                if (names.length == 0) {
                    return null;
                }

                if (names.length == 1) {
                    return values[name];
                }

                return values;
            }

            return tgt.val();
        }
    });



    window.convert = function (value, dataType, defaultStrValue, isInOperator) {
        let v = value;
        defaultStrValue = arguments.length <= 2 ? null : defaultStrValue;
        if (v == null) {
            v = defaultStrValue;
        }

        if (v == null) {
            return v;
        }

        if (typeof(v) == 'string' && isInOperator) {
            v = v.split(',');
        }

        if (dataType == 'string') {
            if (Array.isArray(v)) {
                for (let i = 0; i < v.length; i++) {
                    v[i] = v[i].toString();
                }

                return v;
            }

            return v.toString();
        }

        if (dataType == 'int') {
            if (Array.isArray(v)) {
                for (let i = 0; i < v.length; i++) {
                    v[i] = parseInt(v[i]);
                }

                return v;
            }

            let intVal = parseInt(v);
            if (isNaN(intVal)) {
                return null;
            }

            return intVal;
        }

        if (dataType == 'number' || dataType == 'float') {
            if (Array.isArray(v)) {
                for (let i = 0; i < v.length; i++) {
                    v[i] = parseFloat(v[i]);
                }

                return v;
            }

            let numVal = parseFloat(v);
            if (isNaN(numVal)) {
                return null;
            }

            return numVal;
        }

        if (dataType == 'datetime' || dataType == 'date') {
            try {
                if (Array.isArray(v)) {
                    for (let i = 0; i < v.length; i++) {
                        v[i] = new Date(v[i]);
                    }

                    return v;
                }

                let dtVal = new Date(v);
                return dtVal;
            } catch (ex) {
                console.log(ex.message + ' ' + ex.stack);
                return null;
            }
        }

        if (dataType == 'time') {
            try {
                if (Array.isArray(v)) {
                    for (let i = 0; i < v.length; i++) {
                        v[i] = new Date('2014-08-13 ' + v[i]);
                    }

                    return v;
                }

                let dtVal = new Date('2014-08-13 ' + v);
                return dtVal;
            } catch (ex) {
                console.log(ex.message + ' ' + ex.stack);
                return null;
            }
        }

        console.log('unsupport data type: ' + dataType);
        return null;
    };

    return {
        arguments2Array: function (args, start) {
            let array = [];
            if (args == null && args.length === 0) {
                return array;
            }

            let i;
            for (i = start || 0; i < args.length; i++) {
                array.push(args[i]);
            }

            return array;
        }
    };
});