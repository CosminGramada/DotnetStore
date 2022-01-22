import {Page} from "@playwright/test";
import {ProductItemComponent} from "./product-item.page";
import {ProductsPage} from "./products.page";
import {commerce, internet} from "faker";
import {ShippingMethod} from "../enums/checkout";
import {CheckoutPaymentPage} from "./checkout-payment.page";

export class CheckoutShippingPage {
    private readonly page;
    private readonly freeShippingMethod = () => this.page.locator('#checkout_shipping_rate_id_free');
    private readonly standardShippingMethod = () => this.page.locator('#checkout_shipping_rate_id_standard');
    private readonly expressShippingMethod = () => this.page.locator('#checkout_shipping_rate_id_express');
    private readonly continueToPaymentButton = () => this.page.locator('.step__footer button');

    constructor(page: Page) {
        this.page = page;
    }

    async goToPayment(shippingMethod: ShippingMethod) {
        switch (shippingMethod) {
            case ShippingMethod.Free: {
                await this.freeShippingMethod().click();
                break;
            }
            case ShippingMethod.Standard: {
                await this.standardShippingMethod().click();
                break;
            }
            case ShippingMethod.Express: {
                await this.expressShippingMethod().click();
                break;
            }
        }
        await this.continueToPaymentButton().click();
        return new CheckoutPaymentPage(this.page);
    }
}
