
var UploadFile = function (fileInputImage, btnSelectImg, Category, RenderHtml, loadImage) {
    $(document).ready(function () {
        //Delete upload
        $(Category).on("click", "a.btn-click-delete", function (event) {
            $(this).closest('.tempRow').remove();
        });
                
        //Add Upload
        $(btnSelectImg).on('click', function () {
            $(fileInputImage).click();
        });
        $(fileInputImage).on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            var isValidated = false;
            var nameCategory = $(Category).attr('name');
            const validImageTypes = ['image/gif', 'image/jpeg', 'image/png', 'application/pdf', 'application/msword',
                'application/vnd.ms-word', 'application/vnd.ms-excel', 'application/vnd.ms-powerpoint',
                'application/vnd.openxmlformats-officedocument.wordprocessingml.document',
                'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
                'application/vnd.openxmlformats-officedocument.presentationml.presentation',
                'application/vnd.openxmlformats-officedocument.wordprocessingml.document'];
            const maxFileSize = 50000000; //50MB
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
                if (validImageTypes.indexOf(files[i].type) > -1) {
                    isValidated = true;
                } else {
                    utils.notify('Tập tin không đúng định dạng', 'error');
                    return false;
                }

                if (files[i].size < maxFileSize) {
                    isValidated = true;
                } else {
                    utils.notify('Kích thước tập tin quá lớn', 'error');
                    return false;
                }
            }
            if (isValidated) {
                if ($(loadImage).length > 0) {
                    $(loadImage).hide();
                }
                $(loadImage).show();
                var url = "/Admin/File/UploadFile?Category=" + nameCategory;
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (response) {
                        $(loadImage).hide();
                        $.each(response, function (i, item) {
                            $.ajax({
                                type: "Post",
                                url: "/Admin/TopicTeacher/_ShowUploadFileManager",
                                data: { uploadFile: item },
                                success: function (html) {
                                    $(RenderHtml).append(html);
                                }
                            })
                        });
                    },
                    error: function () {
                        $(loadImage).hide();
                        utils.notify('Tập tin tải lên thất bại', 'error');
                    }
                });
            }
        });
    })
}



//$(document).ready(function () {
//    //Delete upload
//    $(".ReLoadUpload").on("click", "a.btn-click-delete", function (event) {
//        $(this).closest('.UploadFile').remove();
//    });

//    var fileInputImage = '#' + $(".ReLoadUpload").attr('id');
//    alert(fileInputImage);
//    //Add Upload
//    $('.btnSelectImg').on('click', function () {
//        $('.fileInputImage').click();
//    });
//    $(".fileInputImage").on('change', function () {
//        var fileUpload = $(this).get(0);
//        var files = fileUpload.files;
//        var data = new FormData();
//        var isValidated = false;
//        const validImageTypes = ['image/gif', 'image/jpeg', 'image/png', 'application/pdf', 'application/msword',
//            'application/vnd.ms-word', 'application/vnd.ms-excel', 'application/vnd.ms-powerpoint',
//            'application/vnd.openxmlformats-officedocument.wordprocessingml.document',
//            'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
//            'application/vnd.openxmlformats-officedocument.presentationml.presentation',
//            'application/vnd.openxmlformats-officedocument.wordprocessingml.document'];
//        const maxFileSize = 50000000; //50MB
//        for (var i = 0; i < files.length; i++) {
//            data.append(files[i].name, files[i]);
//            if (validImageTypes.indexOf(files[i].type) > -1) {
//                isValidated = true;
//            } else {
//                utils.notify('Tập tin không đúng định dạng', 'error');
//                return false;
//            }

//            if (files[i].size < maxFileSize) {
//                isValidated = true;
//            } else {
//                utils.notify('Kích thước tập tin quá lớn', 'error');
//                return false;
//            }
//        }
//        if (isValidated) {
//            if ($('#loadImage').length > 0) {
//                $("#loadImage").hide();
//            }
//            $("#loadImage").show();
//            var Category = $(".ReLoadUpload").attr('name');
//            var url = "/Admin/File/UploadFile?Category=" + Category;
//            $.ajax({
//                type: "POST",
//                url: url,
//                contentType: false,
//                processData: false,
//                data: data,
//                success: function (response) {
//                    $("#loadImage").hide();

//                    console.log("success");
//                    //var template = $('#table-template').html();
//                    var render = "";

//                    $.each(response, function (i, item) {
//                        $.ajax({
//                            type: "Post",
//                            url: "/Admin/TopicTeacher/_ShowUploadFileManager",
//                            data: { uploadFile: item },
//                            success: function (html) { $(".LoadFileUpload").append(html); }
//                        })
//                    });
//                    if (render !== undefined) {
//                        $('.tbl-content').html(render);

//                    }
//                },
//                error: function () {
//                    $("#loadImage").hide();
//                    utils.notify('Tập tin tải lên thất bại', 'error');
//                }
//            });
//        }
//    });
//})

