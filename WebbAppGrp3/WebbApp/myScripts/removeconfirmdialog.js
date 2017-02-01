$('#removelink').on('click', function (e) {
    e.preventDefault();
    alertify.confirm("Are you sure you want to delete this item?",
        function (e) {
            if (e) {
                $.ajax({
                    url: "/Item/RemoveItem?itemID=" + $('#removelink').attr('ItemID'),
                    type: "POST",
                    success: function (data) {
                        alertify.success('Item has been removed!');
                        setTimeout(function () {
                            window.location = data;
                        }, 500);
                    },
                    error: function () {
                        alertify.error("Something went wrong");
                    }

                });
            }
            else {
                    alertify.error('Removal of item canceled');
            }
            

        });
})