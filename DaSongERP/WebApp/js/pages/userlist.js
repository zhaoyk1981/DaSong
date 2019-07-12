define(['jquery', 'mustache', 'kyle_toolkit_repeater', 'kyle_toolkit_enhance'], function ($, mustache, repeater, enhance) {
    let btnSearch_click = function (event) {
        repeater.dataBind(true);
    };

    let btnDelete_click = function () {
        if (!window.confirm('确实要删除吗？')) {
            return false;
        }

        let id = encodeURI($(this).closest("[data-id]").attr('data-id'));
        $.ajax({
            url: '/User/ARemove',
            type: 'POST',
            dataType: 'JSON',
            data: {
                ID: id
            },
            success: function (data) {
                if (data.Success === true) {
                    alert('删除成功');
                    window.location.reload(true);
                    return;
                }

                alert('删除失败');
            }
        });
    };

    return {
        ready: function (vm) {
            repeater.init({
                target: $('.repeater'),
                tmplItem: $('#tmplRow').html(),
                newFilters: function () {
                    //let m = model.createModel();
                    //let newCondition = model.capture(m);
                    //return newCondition;
                    return {};
                },
                url: '/User/AIndex',
                currentSortPaging: vm.currentSortPaging
            }, true);

            $('.repeater').delegate('.btn-delete', 'click', btnDelete_click);
            $('#BtnSearch').click(btnSearch_click).click();
        }
    };
});