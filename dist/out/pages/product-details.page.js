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
exports.ProductDetailsPage = void 0;
const header_page_1 = require("./header.page");
class ProductDetailsPage {
    constructor(page) {
        this.addToCartButton = () => this.page.locator('.add-to-cart-btn');
        this.colorSelect = () => this.page.locator('#option-select-color');
        this.sizeSelect = () => this.page.locator('#option-select-size');
        this.header = () => new header_page_1.Header(this.page);
        this.page = page;
    }
    addProductToCart() {
        return __awaiter(this, void 0, void 0, function* () {
            const firstColorElement = yield this.colorSelect().first().locator('option').last();
            const colorName = yield firstColorElement.textContent();
            yield Promise.all([
                this.colorSelect().first().selectOption({ label: colorName }),
                this.page.waitForFunction(() => {
                    const select = document.querySelector('#option-select-size');
                    if (!select)
                        return false;
                    // @ts-ignore
                    return [...select.options].length > 1;
                })
            ]);
            const firstSizeElement = yield this.sizeSelect().first().locator('option').last();
            const sizeName = yield firstSizeElement.textContent();
            yield Promise.all([
                this.sizeSelect().first().selectOption({ label: sizeName }),
                this.addToCartButton().getAttribute('disabled') == null
            ]);
            yield this.addToCartButton().click();
            return this;
        });
    }
}
exports.ProductDetailsPage = ProductDetailsPage;
