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
exports.CheckoutShippingPage = void 0;
const checkout_1 = require("../enums/checkout");
const checkout_payment_page_1 = require("./checkout-payment.page");
class CheckoutShippingPage {
    constructor(page) {
        this.freeShippingMethod = () => this.page.locator('#checkout_shipping_rate_id_free');
        this.standardShippingMethod = () => this.page.locator('#checkout_shipping_rate_id_standard');
        this.expressShippingMethod = () => this.page.locator('#checkout_shipping_rate_id_express');
        this.continueToPaymentButton = () => this.page.locator('.step__footer button');
        this.page = page;
    }
    goToPayment(shippingMethod) {
        return __awaiter(this, void 0, void 0, function* () {
            switch (shippingMethod) {
                case checkout_1.ShippingMethod.Free: {
                    yield this.freeShippingMethod().click();
                    break;
                }
                case checkout_1.ShippingMethod.Standard: {
                    yield this.standardShippingMethod().click();
                    break;
                }
                case checkout_1.ShippingMethod.Express: {
                    yield this.expressShippingMethod().click();
                    break;
                }
            }
            yield this.continueToPaymentButton().click();
            return new checkout_payment_page_1.CheckoutPaymentPage(this.page);
        });
    }
}
exports.CheckoutShippingPage = CheckoutShippingPage;
