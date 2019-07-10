define(['jquery', 'mustache', 'kyle_toolkit_repeater', 'kyle_toolkit_enhance', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, mustache, repeater, enhance, model, validation) {
    let validate = function () {
        let validationResult = validation.validate(['default']);
        if (validationResult !== true) {
            $('#BtnSubmit').prop('disabled', false);
        }

        return validationResult;
    };

    let btnSubmit_click = function () {
        $(this).prop('disabled', true);
        if (!validate()) {
            return;
        }

        let formData = new FormData();
        //formData.append("formJson", json);
        formData.append("file", $('#IptExcel')[0].files[0], $('#IptExcel')[0].files[0].name);
        formData.append("upload_file", true);
        $.ajax({
            url: '/Order/AImport',
            type: 'POST',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.Success !== true) {
                    alert('操作失败,' + (data.ErrorMessage || ''));
                    return;
                }

                $("#LblMessage").text('未导入订单数量：' + data.未导入);
                window.location = data.Url;
            }
        });
    };

    let chkMy_click = function () {
        if ($(this).prop('checked') === true) {
            $('#Ddl导入状态').val('true');
        }

        return true;
    };

    let btnSearch_click = function (event) {
        repeater.dataBind(true);
    };

    return {
        ready: function (vm) {
            repeater.init({
                target: $('.repeater'),
                tmplItem: $('#tmplRow').html(),
                newFilters: function () {
                    let m = model.createModel({
                        formWrapper: $('#FormConditions')
                    });
                    let newCondition = model.capture(m);
                    return newCondition;
                },
                url: '/Order/ADianHuaKeFuList',
                currentSortPaging: vm.currentSortPaging
            }, true);

            $('#ChkMy').click(chkMy_click);
            $('#BtnSubmit').click(btnSubmit_click);
            $('#BtnSearch').click(btnSearch_click).click();
        }
    };
});