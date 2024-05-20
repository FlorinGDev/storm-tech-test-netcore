$(document).ready(function () {
    $('#isDoneToggle').change(function () {
        var display = 'block';
        var hide = 'none';
        var displyOption = $(this).prop('checked') == true ? hide : display;
        $('.onToggleIsDoneHide').each(function () {
            this.style.display = displyOption;
        });
    });

    $('#createItemPopUp').click(function () {
        window.open("", "Create New Item", "height=200,width=200,modal=yes,position=center,200");
    });

});