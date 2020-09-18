
var FileManager = function (controllerSessionName, idOwnerSessionName) {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        //Init validation
        $('#btnSelectImg').on('click', function () {
            $('#fileInputImage').click();
        });
        $("#fileInputImage").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            var isValidated = false;
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
                if ($('#loadImage').length > 0) {
                    $("#loadImage").hide();
                }
                $("#loadImage").show();
                var url = "/Admin/File/UploadFile/?controllerSessionName=" + controllerSessionName + "&&idOwnerSessionName=" + idOwnerSessionName;
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (response) {
                        $("#loadImage").hide();
                        
                        console.log("success");
                        var template = $('#table-template').html();
                        var render = "";
                        $.each(response, function (i, item) {
                            render += Mustache.render(template, {
                                FileName: item.Name,
                                FilePath: item.PathImg,
                                TempId: item.TempId,
                                Id: item.Id
                            });
                        });
                        if (render !== undefined) {
                            $('#tbl-content').html(render);

                        }
                    },
                    error: function () {
                        $("#loadImage").hide();
                        utils.notify('Tập tin tải lên thất bại', 'error');
                    }
                });
            }
        });

        /* =======================================================================================
         *                                  DELETE
         * =======================================================================================
         */
        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var IdFile = $(this).data('id');
            var tempid = $(this).data('tempid');
            var deleteId = tempid;
            if (deleteId) {

            } else {
                deleteId = IdFile;
            }
            if (IdFile) {
                deleteId = IdFile
            }
            console.log(tempid);
            utils.confirm('Bạn có muốn xóa tập tin này?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/File/DeleteFile",
                    data: {
                        id: deleteId,
                        controllerSessionName: controllerSessionName,
                        idOwnerSessionName: idOwnerSessionName
                    },
                    beforeSend: function () {
                    },
                    success: function (response) {
                        console.log("success");
                        var template = $('#table-template').html();
                        var render = "";
                        $.each(response, function (i, item) {
                            render += Mustache.render(template, {
                                FileName: item.Name,
                                FilePath: item.PathImg,
                                TempId: item.TempId,
                                Id: item.Id
                            });
                        });
                        if (render !== undefined) {
                            $('#tbl-content').html(render);

                        }
                    },
                    error: function (status) {
                        console.log("Error");
                    }
                });
            });
        });
    }

    /* =======================================================================================
    *                                  GET ALL
    * =======================================================================================
    */
    function loadData() {
        $.ajax({
            type: "GET",
            url: "/Admin/File/GetAllFiles",
            data: {
                controllerSessionName: controllerSessionName,
                idOwnerSessionName: idOwnerSessionName
            },
            dataType: "json",
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        FileName: item.Name,
                        FilePath: item.PathImg,
                        TempId: item.TempId,
                        Id: item.Id
                    });
                });
                if (render !== undefined) {
                    $('#tbl-content').html(render);

                }
            },
            error: function (status) {
                console.log(status);
            }
        });
    }
}