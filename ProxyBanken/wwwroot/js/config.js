$(document).ready(function () {
    $.getJSON("/api/configapi", function (data) {
        completeLoading();
        $("#DeleteInterval").val(data.deleteInterval)
        $("#UpdateInterval").val(data.updateInterval)
    });
})