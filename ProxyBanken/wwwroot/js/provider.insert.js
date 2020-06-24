$(document).ready(function () {

    var id = $("#Id").val();
    if (id > 0) {
        $.getJSON("/api/proxyproviderapi/" + id, function (data) {
            completeLoading();
            $("#Url").val(data.url)
            $("#RowQuery").val(data.rowQuery)
            $("#IpQuery").val(data.ipQuery)
            $("#PortQuery").val(data.portQuery)
        });
    } else {
        completeLoading();
    }
    //alert(id);

})