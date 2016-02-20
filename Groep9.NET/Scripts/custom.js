

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

