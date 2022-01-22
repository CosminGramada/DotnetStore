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
exports.SearchResultsPage = void 0;
const product_item_page_1 = require("./product-item.page");
class SearchResultsPage {
    constructor(page) {
        this.productsElements = () => this.page.$$('li.product-item');
        this.page = page;
    }
    getFirstProduct() {
        return __awaiter(this, void 0, void 0, function* () {
            const products = yield this.productsElements();
            const productItemComponent = new product_item_page_1.ProductItemComponent(products[0]);
            return productItemComponent.getProductInformation();
        });
    }
    getAllProducts() {
        return __awaiter(this, void 0, void 0, function* () {
            const productsList = [];
            const products = yield this.productsElements();
            for (const product of products) {
                const productItemComponent = new product_item_page_1.ProductItemComponent(product);
                productsList.push(yield productItemComponent.getProductInformation());
            }
            return productsList;
        });
    }
    getProductInfo() {
        return __awaiter(this, void 0, void 0, function* () {
            const products = yield this.productsElements();
            const abc = products[0];
            const productItemComponent = new product_item_page_1.ProductItemComponent(abc);
            return productItemComponent.getProductInformation();
        });
    }
}
exports.SearchResultsPage = SearchResultsPage;
