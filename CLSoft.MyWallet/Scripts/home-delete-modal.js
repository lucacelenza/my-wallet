function deleteModalLoaded() {
    $("div.modal").modal("show");
}

$(function() {
    $(document).on("hidden.bs.modal",
        "div.modal",
        function() {
            $(this).remove();
        });
});