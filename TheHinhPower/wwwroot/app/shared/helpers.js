function themChucDanh(tieude, idSelect) {
    bootbox.prompt({
        title: tieude,
        inputType: 'text',
        size: "small",
        callback: function (val) {
            console.log(val);
            if (val) {
                $.ajax({
                    type: "POST",
                    url: "/Admin/TopicTeacher/SaveCategoryHelperModal",
                    data: {
                        Name: val,
                        Type: "ChucDanh",
                        NameType: "DanhMucChung"
                    },
                    dataType: "json",
                    success: function (data) {
                        var $newOption = $("<option selected='selected'></option>").val(data.Id).text(data.Name);
                        $(idSelect).append($newOption).trigger('change');
                        utils.notify('Lưu thành công', 'success');
                    },
                    error: function () {
                        utils.notify("Lỗi không thêm được dữ liệu", 'error');
                    }
                });
            }
        }
    });
}

function themTenGiangVien(tieude, idChucDanh, idTen) {
    var chucDanh = $(idChucDanh).val();
    if (chucDanh) {
        bootbox.prompt({
            title: tieude,
            inputType: 'text',
            size: "small",
            callback: function (val) {
                console.log(val);
                if (val) {
                    $.ajax({
                        type: "POST",
                        url: "/Admin/TopicTeacher/SaveAddManagementTopicId",
                        data: {
                            FullName: val,
                            TitleHumanManagementTopicId: chucDanh,
                            Position: 'Lecturers'
                        },
                        dataType: "json",
                        success: function (data) {
                            var $newOption = $("<option selected='selected'></option>").val(data.Id).text(data.FullName)
                            $(idTen).append($newOption).trigger('change');
                            utils.notify('Lưu thành công', 'success');
                        },
                        error: function () {
                            utils.notify("Lỗi không thêm được dữ liệu", 'error');
                        }
                    });
                }
            }
        });
    } else {
        utils.notify("Vui lòng chọn chức danh", 'error');
    }
}