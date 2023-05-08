
    $(document).on("click", "#btnminusBasket", function (e) {
       
        e.preventDefault();
        var id = $('#btnminusBasket').attr("data-productId");
        var url = "@Url.Action("RemoveProductFromSessionByIdMinus","Product")";
        $.ajax({
            url: url,
            data: { productId: id },
            type: "POST",
            success: function (response) {
                if (!response.error) {
                    location.reload();
                   
                    $(".cartdropdown").addClass("show");
                }
                else {
                    alert(response.message)
                }
            }
        });
    });

   