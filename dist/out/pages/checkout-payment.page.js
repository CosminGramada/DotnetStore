"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.CheckoutPaymentPage = void 0;
class CheckoutPaymentPage {
    constructor(page) {
        this.cardNumberInput = () => this.page.locator('#checkout_credit_card_number');
        this.cardNameInput = () => this.page.locator('#checkout_credit_card_name');
        this.expiryMonthInput = () => this.page.locator('#checkout_payment_expiration_month');
        this.expiryYearInput = () => this.page.locator('#checkout_payment_expiration_year');
        this.cvvInput = () => this.page.locator('#checkout_credit_card_cvv');
        this.payNowButton = () => this.page.locator('#continue_button');
        this.page = page;
    }
    payAndSubmitOrder() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.cardNumberInput().fill('4111111111111111');
            yield this.cardNameInput().fill('Test test');
            yield this.expiryMonthInput().selectOption({ label: 'May' });
            yield this.expiryYearInput().selectOption({ label: '2023' });
            yield this.cvvInput().fill('123');
            yield this.payNowButton().click();
            return;
        });
    }
}
exports.CheckoutPaymentPage = CheckoutPaymentPage;
