$(function () {
    // Initialize Bootstrap Tooltips
    $('[data-toggle="tooltip"]').tooltip()

    //Admin - product variant add / update
    $('#add_variant').on('click', function () {
        const rows = $('div[role="row"]');
        const arr = [];
        let exists = false;
        $.each(rows, function (k, row) {
            const color = $(this).find('select[name^="product_color"] option:selected').val();
            const size = $(this).find('select[name^="product_size"] option:selected').val();
            if (arr.includes(color + '_' + size)) {
                exists = true;
                awn.alert('The Color - Size combination already exists.');
            }
            else {
                arr.push(color + '_' + size);
            }
        });

        if (exists) {
            return false;
        }

        const elems = $('select[name^="product_color"]').length;

        const baseUrl = document.location.origin;
        const token = $('meta[name="csrf-token"]').attr('content');

        $('#Product_Price').closest('div').before(
            `<div role="row" style="display: flex;flex-direction: row;">
                <div class="col-md-3"></div>
                <div class="col-md-3">
                    <select class="form-select" type="text" name="product_color_${elems + 1}" required>
                    </select>
                </div>
                <div class="col-md-3" style="padding: 0;">
                    <select class="form-select" type="text" name="product_size_${elems + 1}" required>
                    </select>
                </div>
                <div class="col-md-3" style="display: flex;flex-direction: row;align-items: center;">
                    <input asp-for="ProductVariant.Quantity" class="form-control" type="text" name="quantity_${elems + 1}"
                           value="" placeholder="Quantity" required>
                        <a type="button" class="delete" title="Delete" data-toggle="tooltip" style="margin-right: -100px;">
                            <i class="material-icons" style="color: #E34724; cursor: pointer;">&#xE872;</i>
                        </a>
                    </input>
                </div>
            </div>`
        );

        let productColors = $(`[name="product_color_${elems + 1}"]`);
        let productSizes = $(`[name="product_size_${elems + 1}"]`);

        $.ajax({
            url: baseUrl + "/Product/GetSizes",
            type: "GET",
            data: {
                _token: token
            },
            dataType: 'json',
            success: function (data) {
                let options = `<option disabled selected>Select size</option>`;
                $.each(data, function (key, item) {
                    options += `<option value=${item.id}>${item.name}</option>`;
                });

                productSizes.html(options);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                awn.alert("Status: " + textStatus + " Error: " + errorThrown);
            }
        });

        $.ajax({
            url: baseUrl + "/Product/GetColors",
            type: "GET",
            data: {
                _token: token
            },
            dataType: 'json',
            success: function (data) {
                let options = `<option disabled selected>Select color</option>`;
                $.each(data, function (key, item) {
                    options += `<option value=${item.id}>${item.name}</option>`;
                });

                productColors.html(options);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                awn.alert("Status: " + textStatus + " Error: " + errorThrown);
            }
        });
    });

    //Admin - product add
    $('#add_product, #add_another_product').on('click', function (e) {
        const rows = $('div[role="row"]');
        const arr = [];
        let exists = false;
        $.each(rows, function (k, row) {
            const color = $(this).find('select[name^="product_color"] option:selected').val();
            const size = $(this).find('select[name^="product_size"] option:selected').val();
            if (arr.includes(color + '_' + size)) {
                exists = true;
                awn.alert('The Color - Size combination already exists.');
            }
            else {
                arr.push(color + '_' + size);
            }
        });

        if (exists) {
            return false;
        }

        const colors = $('select[name^="product_color"] option:selected, select[name^="product_size"] option:selected');
        $.each(colors, function (key, value) {
            if (value.disabled) {
                awn.alert('Please select at least one product variant.');
                return false;
            }
        });

        if (colors.length === 0) {
            e.preventDefault();
            awn.alert('Please select at least one product variant.')
        }
    });

    //Product details page - Enable Add To Cart button if both color and size is selected
    $('#option-select-size').on('change', function () {
        const color = $('#option-select-color').val()?.trim();
        const size = $('#option-select-size').val()?.trim();
        const addButton = $('.add-to-cart-btn');
        const product_id = $('#Product_Id').val();

        if (color.toLowerCase() !== 'select color' && size.toLowerCase() !== 'select size') {
            addButton.prop('disabled', false);
        }

        $.ajax({
            url: `/Product/GetProductVariantQuantity?productId=${product_id}&colorId=${color}&sizeId=${size}`,
            type: "GET",
            data: {
                colorId: color,
                sizeId: size,
                productId: product_id
            },
            dataType: 'json',
            success: function (data) {
                if (data == 0) {
                    addButton.prop('disabled', true);
                    addButton.html('Unavailable');
                }
                else {
                    addButton.prop('disabled', false);
                    addButton.html('Add to cart');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                awn.alert("Status: " + textStatus + " Error: " + errorThrown);
            }
        });
    });

    //Product details page - Populate available sizes based on the selected color
    $('#add_to_cart #option-select-color').on('change', function (e) {
        const token = $('meta[name="csrf-token"]').attr('content');

        const product_id = $('#Product_Id').val();
        const color_id = $(this).val();

        const data = {
            _token: token,
            product_id: product_id,
            color_id: color_id
        }

        $.ajax({
            url: `/Product/GetProductSizes?productId=${product_id}&colorId=${color_id}`,
            type: "GET",
            cache: false,
            data: data,
            success: function (data) {
                let option = '<option value="" disabled selected>Select size</option>';
                $.each(data, function (key, value) {
                    option += `<option value="${value.id}">${value.name}</option>`;
                });
                $("#add_to_cart #option-select-size").html(option);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                awn.alert("Status: " + textStatus + " Error: " + errorThrown);
            }
        });
    });
});

$(document).ready(function () {
    const color = $('#option-select-color').find('option[selected]').text()?.trim();
    const size = $('#option-select-size').find('option[selected]').text()?.trim();
    const addButton = $('.add-to-cart-btn');

    if (color.toLowerCase() === 'select color' || size.toLowerCase() === 'select size') {
        addButton.prop('disabled', true);
    }

    $(document).on('click', 'div a.delete', function () {
        const row = $(this).closest('div[role="row"]');
        row.remove();
    });

    $('[name=address_country]').on('change', function () {
        const idCountry = this.value;
        const isModal = $("[name=address_province]").parents('.modal.show');
        const provinceElem = isModal.length > 0 ? $(".modal.show [name=address_province]") : $("#add-address-collapse [name=address_province]");

        provinceElem.html('');

        const baseUrl = document.location.origin;
        const token = $('meta[name="csrf-token"]').attr('content');

        $.ajax({
            url: baseUrl + "/api/fetch-regions",
            type: "POST",
            data: {
                country_id: idCountry,
                _token: token
            },
            dataType: 'json',
            success: function (result) {
                const wrapper = provinceElem.parents('#addresses-province-wrapper-new');
                if (result.regions.length > 0) {
                    wrapper.removeClass('visually-hidden');
                    $.each(result.regions, function (key, value) {
                        provinceElem.append('<option value="' + value
                            .id + '">' + value.name + '</option>');
                    });
                } else {
                    wrapper.addClass('visually-hidden');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                awn.alert("Status: " + textStatus + " Error: " + errorThrown);
            }
        });
    });
});

