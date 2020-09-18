
var loginController = function (returnUrl) {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        $('#btnLogin').on('click', function (e) {
            e.preventDefault();
            var user = $('#txtUserName').val();
            var password = $('#txtPassword').val();
            login(user, password);
        });
    }

    var login = function (user, pass) {
        $.ajax({
            type: 'POST',
            data: {
                UserName: user,
                Password: pass
            },
            dateType: 'json',
            url: '/admin/login/authen',
            success: function (res) {
                if (res.success) {
                    if (returnUrl) {
                        window.location.href = returnUrl;
                    } else {
                        window.location.href = "/Admin/Home/Index";
                    }
                }
                else {
                    utils.notify(res.Message, 'error');
                }
            },
            error: function () {
                utils.notify("Có lỗi xảy ra", 'error')
            }
        })
    }
}



