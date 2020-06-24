$(document).ready(function () {

    $.fn.dataTable.moment("DD/MM/YYYY HH:mm:ss");
    $.fn.dataTable.moment("DD/MM/YYYY");

    var table = $('#proxyListTable').DataTable({
        // Design Assets
        stateSave: true,
        autoWidth: true,
        // ServerSide Setups
        processing: true,
        serverSide: true,
        // Paging Setups
        paging: true,
        displayStart: 0,
        "order": [[5, "desc"]],
        // Searching Setups
        searching: { regex: true },
        // Ajax Filter
        ajax: {
            type: "POST",
            url: "/api/proxyapi",
            contentType: "application/json",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            }
        },
        // Columns Setups
        columns: [
            {
                "className": 'details-control',
                "orderable": false,
                "data": null,
                "defaultContent": '<span class="material-icons">keyboard_arrow_right</span >'
            },

            { data: "ip" },
            { data: "port" },
            {
                data: "createdOn",
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
            {
                data: "modifiedOn",
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
            {
                data: "lastFunctionalityTestDate",
                render: function (data, type, row) {
                    if (data == null) {
                        return "";
                    }

                    var lastDate = moment(data);
                    var now = moment(new Date());
                    return now.diff(lastDate, 'minute') + ' minutes ago';
                }
            },
            {
                data: "anonymity",
                render: function (data, type, row) {

                    return data;
                }
            }
        ],
    });

    $('#proxyListTable tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            row.child.hide();
            $(this).html('<span class="material-icons">keyboard_arrow_right</span >');
        }
        else {
            // Open this row
            row.child(format(row.data())).show();
            $(this).html('<span class="material-icons">keyboard_arrow_down</span >');
        }

    });

    function format(d) {
        console.log(d.id);
        //return "";
        $.get("/Home/ProxyTest?proxyId=" + d.id, function (data) {
            html = data;
        });
        return html;
    }

    $.ajax("/api/statisticapi").done(function (data) {
        $("#proxyCount").text(data.proxyCount);
        $("#providerCount").text(data.providerCount);
        $("#testServerCount").text(data.testServerCount);
    });
});