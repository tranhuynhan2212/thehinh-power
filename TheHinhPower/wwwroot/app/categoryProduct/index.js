var table;
$(document).ready(function () {
    table = $("#categoryProductTable").DataTable({
        "pageLength": 10,
        "processing": true,
        "serverSide": true,
        "sort": false,
        "dom": "rtip",
        "ajax": {
            "url": "/Admin/CategoryProduct/Data",
            "type": "POST",
            "datetype": "json"
        },
        "columns": [
            { "data": "name", "autoWidth": true },
            { "data": "commission_f1", "autoWidth": true },
            { "data": "commission_f2", "autoWidth": true },
            { "data": "commission_f3", "autoWidth": true },
            { "data": "personal", "autoWidth": true },
        ]
    });
});