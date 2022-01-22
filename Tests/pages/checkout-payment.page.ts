import {Page} from "@playwright/test";
import {ProductItemComponent} from "./product-item.page";
import {ProductsPage} from "./products.page";
import {commerce, internet} from "faker";
import {ShippingMethod} from "../enums/checkout";

export class CheckoutPaymentPage {
    private readonly page;
    private readonly cardNumberInput = () => this.page.locator('#checkout_credit_card_number');
    private readonly cardNameInput = () => this.page.locator('#checkout_credit_card_name');
    private readonly expiryMonthInput = () => this.page.locator('#checkout_payment_expiration_month');
    private readonly expiryYearInput = () => this.page.locator('#checkout_payment_expiration_year');
    private readonly cvvInput = () => this.page.locator('#checkout_credit_card_cvv');
    private readonly payNowButton = () => this.page.locator('#continue_button');

    constructor(page: Page) {
        this.page = page;
    }

    async payAndSubmitOrder() {
        await this.cardNumberInput().fill('4111111111111111');
        await this.cardNameInput().fill('Test test');
        await this.expiryMonthInput().selectOption({label: 'May'});
        await this.expiryYearInput().selectOption({label: '2023'});
        await this.cvvInput().fill('123');
        await this.payNowButton().click();
        return;
    }
}
