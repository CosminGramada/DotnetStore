"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Validators = void 0;
const test_1 = require("@playwright/test");
class Validators {
    static validateProduct(productModel, productInfo) {
        (0, test_1.expect)(productInfo).toBeDefined();
        (0, test_1.expect)(productInfo.name).toBe(productModel.name);
        if (productModel.discount) {
            (0, test_1.expect)(Number(productInfo.price).toFixed(2)).toBe(Number(productModel.price - productModel.price * 10 / 100).toFixed(2));
            (0, test_1.expect)(productInfo.discountedPrice).toBe(productModel.price);
            (0, test_1.expect)(productInfo.isOnSale).toBeTruthy();
        }
        else {
            (0, test_1.expect)(productInfo.discountedPrice).toBeNull();
            (0, test_1.expect)(productInfo.isOnSale).toBeFalsy();
            (0, test_1.expect)(productInfo.price).toBe(productModel.price);
        }
        if (productModel.imageName) {
            (0, test_1.expect)(productInfo.imageName).not.toContain('00000000-0000-0000-0000-000000000001.png');
        }
        else {
            (0, test_1.expect)(productInfo.imageName).toContain('00000000-0000-0000-0000-000000000001.png');
        }
        let productQuantity = productModel.variants.reduce((total, a) => total + a.quantity, 0);
        if (productQuantity == 0) {
            (0, test_1.expect)(productInfo.isSoldOut).toBeTruthy();
        }
        else {
            (0, test_1.expect)(productInfo.isSoldOut).toBeFalsy();
        }
    }
}
exports.Validators = Validators;
