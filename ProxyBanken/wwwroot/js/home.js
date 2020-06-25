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
                        return '<span class="material-icons text-danger">highlight_off</span >';
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
            },
            {
                data: "id",
                render: function (data, type, row) {
                    return '<div id="refreshProxy" data-id=' + data + '><i class="material-icons refreshProxy">refresh</i></div>';
                }
            },
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
        var html = "<div id='test_" + d.id + "'>s</div>"
        $.get("/api/ProxyTestApi?proxyId=" + d.id, function (data) {
            var table = '<table class="table"><thead><tr><th>Server Name</th><th>Success Date</th><th>Status</th><th>Response Time(ms)</th></tr></thead><tbody>';
            for (var i = 0; i < data.length; i++) {
                table += '<tr><td>' + data[i].proxyTestServer.name + '</td><td>';
                if (data[i].lastSuccessDate) {
                    table += moment(data[i].lastSuccessDate).format("ddd DD/MM/YYYY HH:mm:ss");
                } else {
                    table += '<i class="material-icons" style="color:red">wifi_off</i>';
                }
                table += '</td>';
                if (data[i].statusCode) {
                    table += '<td>' + data[i].statusCode + '</td>';
                } else {
                    table += '<td></td>';
                }
                table += '<td>';
                if (data[i].responseTime) {
                    table += data[i].responseTime;
                } else {
                    table += '<i class="material-icons" style="color:red">wifi_off</i>';
                }
                table += '</td>';
                table += '</tr>';
            }
            table += "</tbody></table>";

            $("#test_" + d.id).html(table);

        });
        return html;
    }

    $.ajax("/api/statisticapi").done(function (data) {
        $("#proxyCount").text(data.proxyCount);
        $("#providerCount").text(data.providerCount);
        $("#testServerCount").text(data.testServerCount);
    });

    $(document).on('click', '#refreshProxy', function () {
        $(this).html('<span class="spinner-grow spinner-grow-sm text-info" role="status" aria-hidden="true"></span><span class="sr-only">Loading...</span>');
        var table = $('.data-table').DataTable();
        var tr = $(this).closest('tr');
        var row = table.row(tr);
        if (row.child.isShown()) {
            row.child.hide();
            $(tr).find('td.details-control').html('<span class="material-icons">keyboard_arrow_right</span >');
        }

        $.get("/api/proxytestapi/proxytest?id=" + $(this).data('id'), function () {
            table.ajax.reload();
            $(this).html('<i class="material-icons refreshProxy">refresh</i>');

        });
    })

    $(document).on('click', "#saveProxies", function () {
        window.open("/api/proxyapi/export?dtParametersString=" + table.ajax.params());
    });

    $(document).on('click', "#updateProxies", function () {
        $('.alert').show()
        var table = $('.data-table').DataTable();
        $.get("/api/proxyapi/update", function () {
            table.ajax.reload();
            $('.alert').hide()
            $.ajax("/api/statisticapi").done(function (data) {
                $("#proxyCount").text(data.proxyCount);
                $("#providerCount").text(data.providerCount);
                $("#testServerCount").text(data.testServerCount);
            });
        });
    });
});