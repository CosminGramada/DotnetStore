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
exports.ProductsPage = void 0;
const base_page_1 = require("./base.page");
const product_form_page_1 = require("./product-form.page");
const product_item_page_1 = require("./product-item.page");
class ProductsPage extends base_page_1.BasePage {
    constructor(page) {
        super(page);
        this.addNewProductButton = () => this.page.locator('#add_new_product');
        this.productsElements = () => this.page.$$('li.product-item');
        this.productsElementss = () => this.page.locator('li.product-item');
    }
    addNewProduct(product) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.addNewProductButton().first().click();
            const productFormPage = new product_form_page_1.ProductFormPage(this.page);
            return productFormPage.addNewProduct(product);
        });
    }
    getAllProducts() {
        return __awaiter(this, void 0, void 0, function* () {
            const allProducts = [];
            const productElements = yield this.productsElements();
            for (const productElement of productElements) {
                const productItemComponent = new product_item_page_1.ProductItemComponent(productElement);
                allProducts.push(yield productItemComponent.getProductInformation());
            }
            return allProducts;
        });
    }
    getProductByName(name) {
        return __awaiter(this, void 0, void 0, function* () {
            const products = yield this.productsElementss();
            const handles = yield products.elementHandles();
            for (const product of handles) {
                const titleElement = yield product.$('.product-item-title');
                const title = yield titleElement.textContent();
                if (title.trim() === name) {
                    const oldPriceElement = yield product.$('s.price-compare');
                    const imageNameElement = yield product.$('img.product-item-img');
                    const priceElement = yield product.$('span.price');
                    const saleBadgeElement = yield product.$('span.badge-sale');
                    const soldOutBadgeElement = yield product.$('span.badge-sold-out');
                    return {
                        element: null,
                        name: title.trim(),
                        imageName: yield imageNameElement.getAttribute('src'),
                        price: Number((yield priceElement.textContent()).trim().replace('$', '')),
                        discountedPrice: oldPriceElement ? Number((yield oldPriceElement.textContent()).replace('Old price', '').replace('$', '').trim()) : null,
                        isOnSale: saleBadgeElement != null,
                        isSoldOut: soldOutBadgeElement != null
                    };
                }
            }
            return null;
        });
    }
}
exports.ProductsPage = ProductsPage;
