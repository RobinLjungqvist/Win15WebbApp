$('#removeexpired').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        url: "/Admin/Expired/Index",
        type: "POST",
        success: function (data) {
            alertify.alert(data);
        },
        error: function () {
            alertify.error("Something went wrong");
        }

    });
});