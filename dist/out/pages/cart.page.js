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
exports.CartPage = void 0;
const faker_1 = require("faker");
const checkout_shipping_page_1 = require("./checkout-shipping.page");
class CartPage {
    constructor(page) {
        this.noteTextarea = () => this.page.locator('#cart-note');
        this.checkoutButton = () => this.page.locator('#checkout-btn');
        this.page = page;
    }
    goToCheckout() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.noteTextarea().fill(faker_1.commerce.productDescription());
            yield this.checkoutButton().click();
            return new checkout_shipping_page_1.CheckoutShippingPage(this.page);
        });
    }
}
exports.CartPage = CartPage;
