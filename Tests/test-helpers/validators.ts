import {Product, ProductInformation} from "../interfaces/product";
import {expect} from "@playwright/test";

export class Validators {
    static validateProduct(productModel: Product, productInfo: ProductInformation) {
        expect(productInfo).toBeDefined();
        expect(productInfo.name).toBe(productModel.name);
        if (productModel.discount) {
            expect(Number(productInfo.price).toFixed(2)).toBe(Number(productModel.price - productModel.price * 10 / 100).toFixed(2));
            expect(productInfo.discountedPrice).toBe(productModel.price);
            expect(productInfo.isOnSale).toBeTruthy();
        }
        else {
            expect(productInfo.discountedPrice).toBeNull();
            expect(productInfo.isOnSale).toBeFalsy();
            expect(productInfo.price).toBe(productModel.price);
        }

        if (productModel.imageName) {
            expect(productInfo.imageName).not.toContain('00000000-0000-0000-0000-000000000001.png');
        }
        else {
            expect(productInfo.imageName).toContain('00000000-0000-0000-0000-000000000001.png');
        }

        let productQuantity = productModel.variants.reduce((total, a) => total + a.quantity, 0);

        if (productQuantity == 0) {
            expect(productInfo.isSoldOut).toBeTruthy();
        }
        else {
            expect(productInfo.isSoldOut).toBeFalsy();
        }
    }
}
