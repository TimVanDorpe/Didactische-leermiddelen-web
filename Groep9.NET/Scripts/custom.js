

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

alert("test1");
$(document).ready(function () {
    alert("test1");
    //event.preventDefault();
    // Connect to "change" event in order to toggle glyphs
    if ($(".toggle").prop("checked")) {
        alert("test2");
        $(this).prev().addClass("glyphicon-ok-circle");
        $(this).prev().removeClass("glyphicon-unchecked");
     //   $(this).prev().prev().addClass("btn-danger");
     //   $(this).prev().prev().removeClass("groen");
    } else {
        $(this).prev().removeClass("glyphicon-ok-circle");
        $(this).prev().addClass("glyphicon-unchecked");
      // $(this).prev().prev().addClass("groen");
       //$(this).prev().prev().removeClass("btn-danger");
    }
    /*$('.toggle').click(function (e) {
        if ($(e.target).is('input')) { // prevent double-event due to bubbling
            $(this).find('.glyphicon').toggleClass('glyphicon-check glyphicon-unchecked');
        }
    });*/
});