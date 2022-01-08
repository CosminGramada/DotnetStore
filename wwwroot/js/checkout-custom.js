$(document).ready(function () {

    const urlPathName = window.location.pathname;

    let shippingSpan;
    let totalPaymentSpan;
    let currentTotalPayment;
    if (urlPathName !== "/checkout/payment") {
        let defaultShippingInfo = $(this).find(':checked').parents('div.content-box__row').find('span.content-box__emphasis');
        shippingSpan = $(this).find('td.total-line__price span.order-summary__small-text');
        totalPaymentSpan = $(this).find('span.payment-due__price');
        currentTotalPayment = totalPaymentSpan?.text()?.trim()?.replace('$', '').replace(',', '');

        if (defaultShippingInfo.length > 0) {
            const defaultShippingRate = defaultShippingInfo?.text()?.trim();
            if (defaultShippingRate === 'Free') {
                shippingSpan.text('Free');
                const span = $(this).find(':checked').parents('div.content-box__row').find('span.radio__label__accessory');
                span.append('<input name="shipping_rate" type="hidden" value="0">');
            } else {
                shippingSpan.text('$' + defaultShippingRate);
            }
        } else {
            shippingSpan.text('Calculated at next step');
        }
    }

    $("input.input-checkbox").change(function (e) {
        e.preventDefault();

        const passwordField = $(this).parents('div.address-fields').find('#checkout_shipping_password').parents('.field.field--optional');

        if (this.checked === true) {
            passwordField.removeClass('visually-hidden');
        }
        else {
            passwordField.addClass('visually-hidden');
        }
    });

    $("input.input-radio").change(function (e) {
        e.preventDefault();

        const allHiddenInputs = $(this).parents("div.content-box").find('input[type="hidden"]');
        allHiddenInputs.each((k, item) => {
            console.log(k, item);
            item.remove();
        })

        const shippingRateSpan = $(this).parents("div.content-box__row").find('span.content-box__emphasis');

        let shippingRate = shippingRateSpan.text()?.trim()?.replace('$', '');
        if (shippingRate === 'Free') {
            shippingRate = 0;
        }

        const span = $(this).parents('div.content-box__row').find('span.radio__label__accessory');
        span.append('<input name="shipping_rate" type="hidden" value="' + shippingRate + '">');

        let totalPaymentValue = Number(currentTotalPayment) + Number(shippingRate);

        if (shippingRate === 0) {
            shippingSpan.text('Free');
        }
        else {
            shippingSpan.text('$' + shippingRate);
        }

        totalPaymentSpan.text('$' + totalPaymentValue.toFixed(2));
    });

    $('[name=country]').on('change', function () {
        const idCountry = this.value;
        const provinceElem = $("[name=region]");

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
                const wrapper = provinceElem.closest('.field');
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
