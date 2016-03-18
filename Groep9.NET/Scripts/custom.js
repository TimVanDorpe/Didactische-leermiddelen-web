

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
$('#sandbox-container .input-group.date').datepicker({
    format: "dd/mm/yyyy",
    language: "nl-BE",
    autoclose: true,
    todayHighlight: true
});

$(document).ready(function () {
    //event.preventDefault();
    // Connect to "change" event in order to toggle glyphs
    if ($(".toggle").prop("checked")) {
        $(this).prev(".verlanglijstGlyphicon").addClass("glyphicon-ok-circle");
        $(this).prev(".verlanglijstGlyphicon").removeClass("glyphicon-unchecked");
        $(this).parent("label").addClass("btn-danger");
        $(this).parent("label").removeClass("groen");
        $(this).css("color:yellow;");
    } else {
        $(this).prev(".verlanglijstGlyphicon").removeClass("glyphicon-ok-circle");
        $(this).prev(".verlanglijstGlyphicon").addClass("glyphicon-unchecked");
        $(this).parent().addClass("groen");
        $(this).parent().removeClass("btn-danger");
    }
    /*$('.toggle').click(function (e) {
        if ($(e.target).is('input')) { // prevent double-event due to bubbling
            $(this).find('.glyphicon').toggleClass('glyphicon-check glyphicon-unchecked');
        }
    });*/
});