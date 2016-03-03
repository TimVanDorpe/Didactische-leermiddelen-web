

function mobileViewUpdate() {
    var viewportWidth = $(window).width();
    if (viewportWidth < 992) {
        $('#filter-panel').addClass('collapse filter-panel col-xs-12');
                $('#panel').addClass('panel panel-default');
                $('#panel-body').addClass('panel-body');
    } else {
        $('#filter-panel').removeClass('collapse filter-panel  col-xs-12');
                $('#panel').removeClass('panel panel-default');
                $('#panel-body').removeClass('panel-body');
    }
}

$(window).load(mobileViewUpdate);
$(window).resize(mobileViewUpdate);

var items = $.map(
    $(this).sortable('toArray'),
    function (item, index) {
        return { "item": item };
    }
);

$.ajax({
    url: '/Catalogus/ReserveerProducten',
    type: 'post',
    data: { items: items }
});
//$("#toggleButton").toggle(function () {
//    $("#voegToe").show();
//    $("#verwijder").hide();
//}, function () {
//    $("#verwijder").show();
//    $("#voegToe").hide();
//});