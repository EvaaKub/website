$(document).on("click", ".addToCartButton", function () {
    var goodId = $(this).data("goodid");
    $.ajax({
        url: "/Home/AddToCart",
        type: "POST",
        data: { goodid: goodId },
        success: function (response) {
            window.location.href = "/Home/bok1";
        },
        error: function (error) {
            window.location.href = "/Home/reg";
        },
    });
});
$(document).ready(function () {
    $("#searchTerm").on("keyup", function (event) {
        if (event.key === "Enter") {
            console.log("MEOW");
            event.preventDefault();
            $("#searchButton").click();
        }
    });
    $("#searchButton").on("click", function () {
        var searchTerm = $("#searchTerm").val();
        if (searchTerm.length >= 3) {
            $.ajax({
                url: "/Home/Search",
                method: "GET",
                data: { searchTerm: searchTerm },
                success: function (response) {
                    $("#searchResults").html(response);
                    $('#searchResultsModal').modal('show');
                },
                error: function (error) {
                    console.error("Произошла ошибка", error);
                }
            });
        } else {
            $('#searchResults').html('');
            $('#searchResultsModal').modal('hide');
        }
    });

});