define(['jquery', 'kyle_toolkit_enhance'], function ($, enhance) {
    var btnSearch_click = function () {
        var s = encodeURI($.trim($('#TxtSearch').val()));
        window.location = '/User?search=' + s;
    };

    var btnRemove_click = function () {
        if (!window.confirm('确实要删除吗？')) {
            return false;
        }

        var id = encodeURI($(this).closest("[data-id]").attr('data-id'));
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
        ready: function () {
            $('#BtnSearch').click(btnSearch_click);
            $('.btn-remove').click(btnRemove_click);
        }
    };
});