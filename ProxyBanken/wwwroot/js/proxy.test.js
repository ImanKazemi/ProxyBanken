﻿$(document).ready(function () {
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
            url: "/api/ProxyTestServerapi",
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
            { data: "name" },
            { data: "url" },
            {
                width: "150px",
                data: "id",
                render: function (data, type, row) {
                    var editButton = '<div style="display:inline-flex"><button type="button" data-toggle="modal" data-remote="/proxytestserver/insert/' + data +
                        '" data-target="#BaseModal" class="btn btn-dark btn-sm"><span class="material-icons font-sm">edit</span></button> | ';
                    var deleteButton = ' <button type="button" data-toggle="modal" data-remote="/ProxyTestServer/delete/' + data +
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

    $('body').on('click', '[data-toggle="modal"]', function () {
        $($(this).data("target") + ' .modal-body').load($(this).data("remote"));
        $($(this).data("target") + ' .modal-title').text($(this).text());
    })

});