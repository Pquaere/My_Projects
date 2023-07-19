(function ($) {
    ("use strict");
    // Multiple select DropDown
    $(document).ready(function () {

        $(".js-example-basic-multiple").each(function () {
            $(this).select2({
                placeholder: $(this).attr("placeholder"),
                allowClear: true
            });

        });
    });
    // End
})(jQuery);