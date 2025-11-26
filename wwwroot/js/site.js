$(document).ready(() => {
    $('#open-sidebar').click(() => {
        // add class active on #sidebar
        $('#sidebar').addClass('active');

        // show sidebar overlay
        $('#sidebar-overlay').removeClass('d-none');
    });

    $('#sidebar-overlay').click(function () {
        // remove class active from #sidebar
        $('#sidebar').removeClass('active');

        // hide sidebar overlay
        $(this).addClass('d-none');
    });
});
