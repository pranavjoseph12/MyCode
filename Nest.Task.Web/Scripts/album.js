$(document).ready(function () {
    LoadResults();
    $("#btnSearch").unbind().bind('click', function () { LoadResults() });
});
function LoadResults() {
    var pageNumber = 1;
    if ($(".page_num").length > 0)
        pageNumber = $(".page_num").val() == null ? 1 : $(".page_num").val();
    $('#search-main').html($('.spinner').parent('div').html());
    $.ajax({
        type: 'POST',
        url: '/DashBoard/Search',
        data: ({ term: $("#txtSearch").val(), pageNumber: pageNumber }),
        success: BindResluts,
        error :function(xhr, status) {
            alert(status);
        } 
    });
}
function BindResluts(data) {
    $('#search-main').html(data);
    //$("#divGalleries").on('.albumTitle', 'click', function (e) {
    //    alert(1);
    //});
    $(".albumTitle").unbind().bind('click', function (e) {
        $("#ModalGallery").find('.modal-body').html($(this).closest(".parCard").find(".divPhotos").html());
        $("#ModalGallery").show();
        $(".thumbImage").unbind().bind('click', function (e) {
            var url = $(this).parent('div').attr('data-image');
            $(".active").removeClass("active");
            $(this).parent('div').addClass("active");
            $(this).closest('.gallery').find('.realPic').find('img').attr("src",url);
        });
    });
    $(".page_num").change(function () {
        LoadResults();
    });
}