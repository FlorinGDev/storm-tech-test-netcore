$(document).ready(function () {
    $('#isDoneToggle').change(function () {
        var display = 'block';
        var hide = 'none';
        var displyOption = $(this).prop('checked') == true ? hide : display;
        $('.onToggleIsDoneHide').each(function () {
            this.style.display = displyOption;
        });
    });

   

});