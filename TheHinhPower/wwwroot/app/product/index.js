
var table;
$(document).ready(function () {
    table = $("#productTable").DataTable({
        "pageLength": 10,
        "processing": true,
        "serverSide": true,
        "sort": false,
        "dom": "rtip",
        "ajax": {
            "url": "/Admin/Product/Data",
            "type": "POST",
            "datetype": "json"
        },
        "columns": [
            { "data": "name", "autoWidth": true },
            { "data": "price", "autoWidth": true },
            { "data": "image", "autoWidth": true },
            { "data": "description", "autoWidth": true },
        ]
    });
});