$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

    $(document).on("click", "td a.add", function (e) {
        e.preventDefault();
        let empty = false;
        const input = $(this).parents("tr").find('input[type="text"],input[type="date"],select');
        input.each(function () {
            if (!$(this).val() && !$(this).attr("name")?.includes('description') && !$(this).attr("name")?.includes('code')) {
                $(this).addClass("error");
                empty = true;
            } else {
                $(this).removeClass("error");
            }
        });
        if ($("form#discount_form")) {
            $("form#discount_form").trigger("submit", {triggerOrigin: "add"});
        }
        if ($("form#user_form")) {
            $("form#user_form").trigger("submit", {triggerOrigin: "add"});
        }

        $(this).parents("tr").find(".error").first().focus();
        if (!empty) {
            input.each(function () {
                $(this).parent("td").html($(this).val());
            });
            $(this).parents("tr").find(".add, .edit").toggle();
        }
    });

    // Edit row on edit button click
    $(document).on("click", "td a.edit", function (tst) {
        $(this).parents("tr").find("td:not(:last-child)").each(function () {
            if ($(this).attr('attr')?.includes('_date')) {
                $(this).html('<input type="date" class="form-control" name="' + $(this).attr('attr') + '" value="' + $(this).text() + '">');
            } else if ($(this).attr('attr')?.includes('_select')) {
                const elem = $(this);
                const baseUrl = document.location.origin;
                const token = $('meta[name="csrf-token"]').attr('content');

                $.ajax({
                    type: 'GET',
                    url: baseUrl + '/admin/api/discount_types',
                    data: {
                        _token: token
                    },
                    success: function (data) {
                        let options = "";
                        for (const type in data) {
                            options += '<option value="' + data[type].id + '">' + data[type].name + '</option>';
                        }
                        const html = '<select class="form-select" name="discount_type">' + options + '</select>';
                        elem.html(html);
                    }
                });

            } else if ($(this).attr('name')?.includes('_id')) {
                $(this).html('<input type="hidden" class="form-control" name="' + $(this).attr('name') + '" value="' + $(this).text() + '">');
            } else {
                $(this).html('<input type="text" class="form-control" name="' + $(this).attr('attr') + '" value="' + $(this).text().trim().replace('$', '') + '">');
            }
        });
        $(this).parents("tr").find(".add, .edit").toggle();
        $(this).parents("tr").find(".add").css('display', 'inline');
    });
    // Delete row on delete button click
    $(document).on("click", "td a.delete", function () {
        $(this).parents("tr").find("td:not(:last-child)").each(function () {
            if ($(this).attr('name')?.includes('_id')) {
                $(this).html('<input type="hidden" class="form-control" name="' + $(this).attr('name') + '" value="' + $(this).text() + '">');
            }
        });
        if ($("form#discount_form")) {
            $("form#discount_form").trigger("submit", {triggerOrigin: "delete"});
        }
        if ($("form#user_form")) {
            $("form#user_form").trigger("submit", {triggerOrigin: "delete"});
        }
        $(this).parents("tr").remove();
    });

    $('form#discount_form').on('submit', (function (e, origin) {
        e.preventDefault();
        const baseUrl = document.location.origin;
        const token = $('meta[name="csrf-token"]').attr('content');
        const discountId = $(this).find('input[name="discount_id"][type="hidden"]').val();
        const formData = $(this).serialize();
        const type = origin.triggerOrigin === "add" ? 'POST' : 'DELETE';

        $.ajax({
            type: type,
            url: baseUrl + `/admin/discounts/${discountId}`,
            data: formData + '&_token=' + token,
            success: function (data) {
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                console.log("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    }));

    $('form#user_form').on('submit', (function (e, origin) {
        e.preventDefault();
        const formData = $(this).serialize();
        const url = origin.triggerOrigin === "add" ? 'edit_user.php' : 'delete_user.php';

        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            success: function (data) {
                console.log(data);
            }
        });
    }));
});
