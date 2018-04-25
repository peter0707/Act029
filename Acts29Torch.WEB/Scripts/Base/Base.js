var BaseJs = {
    GoTo: function (url) {
        $("#btnBack").button("loading");
        window.location.href = url;
    },

    SaveData: function (url, postData) {
        if ($("#validateList").valid()) {
            var btn = $("#btnSave");
            btn.button('loading');
            $.post(url, postData, function (res, status, jqXHR) {
                if (res.flag) {
                    alert("操作成功");
                } else {
                    alert("操作失敗：" + res.msg);
                }
            }).error(function () {
                alert("服務器程序錯誤");
            }).complete(function () {
                btn.button('reset');
            });
        }
    }
}
