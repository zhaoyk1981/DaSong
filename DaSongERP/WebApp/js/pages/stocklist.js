define(['jquery', 'mustache', 'kyle_toolkit_repeater', 'kyle_toolkit_model', 'kyle_toolkit_validation'], function ($, mustache, repeater, model, validation) {
    let btnSearch_click = function (event) {
        repeater.dataBind(true);
    };

    let btnDelete_click = function () {
        if (!window.confirm('确实要删除吗？')) {
            return false;
        }

        let id = encodeURI($(this).closest("[data-id]").attr('data-id'));
        $.ajax({
            url: '/Stock/ADelete',
            type: 'POST',
            dataType: 'JSON',
            data: {
                ID: id
            },
            success: function (data) {
                alert(data.Success === true ? '删除成功' : '删除失败, 该项不存在或使用中。');
                btnSearch_click();
            }
        });
    };

    return {
        ready: function (vm) {
            repeater.init({
                target: $('.repeater'),
                tmplItem: $('#tmplRow').html(),
                newFilters: function () {
                    let m = model.createModel();
                    let newCondition = model.capture(m);
                    return newCondition;
                },
                url: '/Stock/AIndex',
                currentSortPaging: vm.currentSortPaging
            }, true);

            $('.repeater').delegate('.btn-delete', 'click', btnDelete_click);
            $('#BtnSearch').click(btnSearch_click).click();
        }
    };
});