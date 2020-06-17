$(document).ready(function () {
    $('#providerTable').DataTable({
        // Design Assets
        stateSave: true,
        autoWidth: true,
        // ServerSide Setups
        processing: true,
        serverSide: true,
        // Paging Setups
        paging: true,
        // Searching Setups
        searching: { regex: true },
        // Ajax Filter
        ajax: {
            url: "/api/proxyproviderapi",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: function (d) {
                console.log(d);
                return JSON.stringify(d);
            }
        },
        // Columns Setups
        columns: [
            { data: "url" },
            {
                data: "lastFetchOn",
                render: function (data, type, row) {
                    // If display or filter data is requested, format the date
                    if (type === "display" || type === "filter") {
                        return moment(data).format("ddd DD/MM/YYYY HH:mm:ss");
                    }
                    // Otherwise the data type requested (`type`) is type detection or
                    // sorting data, for which we want to use the raw date value, so just return
                    // that, unaltered
                    return data;
                }
            },
            { data: "lastFetchProxyCount" },
            { data: "exception" },
            { data: "rowQuery" },
            { data: "ipQuery" },
            { data: "portQuery" },
            {
                width: "152px",
                data: "id",
                render: function (data, type, row) {
                    var editButton = '<div style="display:inline-flex"><button type="button" data-toggle="modal" data-remote="/proxyprovider/insert/' + data +
                        '" data-target="#BaseModal" class="btn btn-dark btn-sm"><span class="material-icons font-sm">edit</span></button> | ';
                    var deleteButton = ' <button type="button" data-toggle="modal" data-remote="/proxyprovider/delete/' + data +
                        '" data-target="#BaseModal" class="btn btn-dark btn-sm"><span class="material-icons font-sm">delete</span></button></div>';

                    return editButton + deleteButton;
                }
            },
        ],
        // Column Definitions
        columnDefs: [
            { targets: "no-sort", orderable: false }
        ]
    });
});

$('body').on('click', '[data-toggle="modal"]', function () {
    $($(this).data("target") + ' .modal-body').load();
    $($(this).data("target") + ' .modal-title').text($(this).text());
})