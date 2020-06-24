$(document).ready(function () {

    var id = $("#Id").val();
    if (id > 0) {
        $.getJSON("/api/ProxyTestServerapi/" + id, function (data) {
            completeLoading();
            $("#Name").val(data.name)
            $("#Url").val(data.url)
        });
    } else {
        completeLoading();
    }

})