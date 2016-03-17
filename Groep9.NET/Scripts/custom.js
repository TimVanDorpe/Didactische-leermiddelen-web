

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

//var items = $.map(
//    $(this).sortable('toArray'),
//    function (item, index) {
//        return { "item": item };
//    }
//);

//$.ajax({
//    url: '/Catalogus/ReserveerProducten',
//    type: 'post',
//    data: { items: items }
//});
$('.input-group.date').datepicker({
    language: "nl-BE",
    autoclose: true,
    todayHighlight: true
});


$(document).ready(function () {
    //event.preventDefault();
    // Connect to "change" event in order to toggle glyphs
    if ($(".toggle").prop("checked")) {
        $(this).prev().addClass("glyphicon-ok-circle");
        $(this).prev().removeClass("glyphicon-unchecked");
        $(this).prev().addClass("btn-danger");
        $(this).prev().removeClass("groen");
    } else {
        $(this).prev().removeClass("glyphicon-ok-circle");
        $(this).prev().addClass("glyphicon-unchecked");
       $(this).prev().addClass("groen");
       $(this).prev().removeClass("btn-danger");
    }
    /*$('.toggle').click(function (e) {
        if ($(e.target).is('input')) { // prevent double-event due to bubbling
            $(this).find('.glyphicon').toggleClass('glyphicon-check glyphicon-unchecked');
        }
    });*/
});