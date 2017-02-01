$('#emailbtn').on('click',function(e){

    $.ajax({
        url: "/Item/GetUploaderEmail?UserID=" + $('#emailbtn').attr('UserID'),
        type: "POST",
        success: function (data) {
            alertify.alert("Uploader Email:" + data);
        },
        error: function () {
            alertify.error("Something went wrong");
        }

    });

});