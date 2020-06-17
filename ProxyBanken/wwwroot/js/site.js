$(".nav-link").removeClass('active');

$("#configBody").load("/home/config");

$("#modalSave").on('click', function () {
    var form = $("#BaseModal").find('form');
    $.ajax({
        url: $(form).attr('action'),
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            if (data == true) {
                var table = $('.table').DataTable();
                if (table) {
                    table.ajax.reload();
                }
                $("#BaseModal").modal('hide');
            } else {
                alert("an error ocurred");
            }
        }
    });
});
