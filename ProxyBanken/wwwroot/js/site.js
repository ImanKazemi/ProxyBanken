$(".nav-link").removeClass('active');

$(document).on('click', "#configuration", function () {
    startLoading()
    $("#modalBody").load("/home/config");
});


$("#modalSave").on('click', function () {
    var form = $("#modalBody").find('form');
    
    $.ajax({
        url: $(form).attr('action'),
        data: form.serialize(),
        type: $(form).attr('method'),
        success: function (data) {
            var table = $('.data-table').DataTable();
            if (table) {
                table.ajax.reload();
            }
            $("#BaseModal").modal('hide');
        },
        error: function () {
            alert("an error ocurred");
        }
    });
});

$('body').on('click', '[data-toggle="modal"]', function () {
    $($(this).data("target") + ' .modal-body').html("");
    startLoading();
    $($(this).data("target") + ' .modal-body').load($(this).data("remote"));
    $($(this).data("target") + ' .modal-title').text($(this).text());
    completeLoading();
})

function completeLoading() {
    $("#modalLoading").hide();
    $("#modalBody").show();
}

function startLoading() {
    $("#modalLoading").hide();
    $("#modalBody").show();
}