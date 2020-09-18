var utils = {
    configs: {
        pageSize: 10,
        pageIndex: 1
    },
    notify: function (message, type) {
        $.notify.addStyle('success', {
            html: "<div class='alert alert-success alert-dismissable'>" +
                "<i class='zmdi zmdi-check pr-15 pull-left'></i> <p class='pull-left'><span data-notify-text/></p>" +
                "<div class='clearfix'></div>" +
                "</div >",
            classes: {
                base: {
                    "white-space": "nowrap",
                    "background-color": "#8BC34A",
                    "color": "white",
                    "padding": "20px",
                }
            }
        });
        $.notify.addStyle('error', {
            html: "<div class='alert alert-danger alert-dismissable'>" +
                "<i class='zmdi zmdi-block pr-15 pull-left'></i> <p class='pull-left'><span data-notify-text/></p>" +
                "<div class='clearfix'></div>" +
                "</div >",
            classes: {
                base: {
                    "white-space": "nowrap",
                    "background-color": "#f33923",
                    "color": "white",
                    "padding": "20px",
                }
            }
        });
        $.notify.addStyle('warning', {
            html: "<div class='alert alert-warning alert-dismissable'>" +
                "<i class='zmdi zmdi-alert-circle-o pr-15 pull-left'></i> <p class='pull-left'><span data-notify-text/></p>" +
                "<div class='clearfix'></div>" +
                "</div >",
            classes: {
                base: {
                    "white-space": "nowrap",
                    "background-color": "#f8b32d",
                    "color": "white",
                    "padding": "20px",
                }
            }
        });
        $.notify(message, {
            style: type,
            position: 'bottom right',
        });
    },
    confirm: function (message, okCallback) {
        bootbox.dialog({
            message: message,
            onEscape: true,
            buttons: {
                success: {
                    label: "Đồng ý",
                    className: 'btn-success',
                    callback: function () {
                        okCallback();
                    }
                },
                cancel: {
                    label: "Hủy",
                    className: 'btn-danger',
                    callback: function () {
                    }
                }
            }
        });
    },
    confirmSmall: function (message, okCallback) {
        bootbox.dialog({
            message: message,
            onEscape: true,
            size: "small",
            buttons: {
                success: {
                    label: "Đồng ý",
                    className: 'btn-success',
                    callback: function () {
                        okCallback();
                    }
                },
                cancel: {
                    label: "Hủy",
                    className: 'btn-danger',
                    callback: function () {
                    }
                }
            }
        });
    },

    dateFormatInput: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        return year + "-" + month + "-" + day;
    },
    dateFormatView: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        return day + "/" + month + "/" + year;
    },
    dateTimeFormatView: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        var ss = newdate.getSeconds();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        if (ss < 10)
            ss = "0" + ss;
        return day + "/" + month + "/" + year + " " + hh + ":" + mm + ":" + ss;
    },
    startLoading: function () {
        if ($('.dv-loading').length > 0)
            $('.dv-loading').removeClass('hide');
    },
    stopLoading: function () {
        if ($('.dv-loading').length > 0)
            $('.dv-loading')
                .addClass('hide');
    },
    getStatus: function (status) {
        if (status == 1)
            return '<span class="badge bg-green">Kích hoạt</span>';
        else
            return '<span class="badge bg-red">Khoá</span>';
    },
    formatNumber: function (number, precision) {
        if (!isFinite(number)) {
            return number.toString();
        }

        var a = number.toFixed(precision).split('.');
        a[0] = a[0].replace(/\d(?=(\d{3})+$)/g, '$&,');
        return a.join('.');
    },
    unflattern: function (arr) {
        var map = {};
        var roots = [];
        for (var i = 0; i < arr.length; i += 1) {
            var node = arr[i];
            node.children = [];
            map[node.Id] = i; // use map to look-up the parents
            if (node.ParentId !== null) {
                arr[map[node.ParentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    }
}

$(document).ajaxSend(function (e, xhr, options) {
    if (options.type.toUpperCase() == "POST" || options.type.toUpperCase() == "PUT") {
        var token = $('form').find("input[name='__RequestVerificationToken']").val();
        xhr.setRequestHeader("RequestVerificationToken", token);
    }
});