import {Page} from "@playwright/test";
import {ProductItemComponent} from "./product-item.page";
import {ProductsPage} from "./products.page";
import {commerce, internet} from "faker";
import {CheckoutShippingPage} from "./checkout-shipping.page";
import {CheckoutInformationPage} from "./checkout-information.page";

export class CartPage {
    private readonly page;
    private readonly noteTextarea = () => this.page.locator('#cart-note');
    private readonly checkoutButton = () => this.page.locator('#checkout-btn');

    constructor(page: Page) {
        this.page = page;
    }

    async goToCheckout() {
        await this.noteTextarea().fill(commerce.productDescription());
        await this.checkoutButton().click();
        return new CheckoutInformationPage(this.page);
    }
}
