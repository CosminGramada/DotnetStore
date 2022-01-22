import {Page} from "@playwright/test";
import {ProductItemComponent} from "./product-item.page";
import {ProductsPage} from "./products.page";
import {commerce, internet} from "faker";
import {ShippingMethod} from "../enums/checkout";
import {CheckoutPaymentPage} from "./checkout-payment.page";
import {CheckoutShippingPage} from "./checkout-shipping.page";

export class CheckoutInformationPage {
    private readonly page;
    private readonly continueToShippingButton = () => this.page.locator('#continue_to_shipping_button');

    constructor(page: Page) {
        this.page = page;
    }

    async goToShipping() {
        await this.continueToShippingButton().click();
        return new CheckoutShippingPage(this.page);
    }
}
