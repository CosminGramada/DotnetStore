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
exports.ProductItemComponent = void 0;
class ProductItemComponent {
    constructor(baseProductElement) {
        this.oldPriceElement = () => this.baseProductElement.$('s.price-compare');
        this.imageNameElement = () => this.baseProductElement.$('img.product-item-img');
        this.priceElement = () => this.baseProductElement.$('span.price');
        this.saleBadgeElement = () => this.baseProductElement.$('span.badge-sale');
        this.soldOutBadgeElement = () => this.baseProductElement.$('span.badge-sold-out');
        this.titleElement = () => this.baseProductElement.$('.product-item-title');
        this.baseProductElement = baseProductElement;
    }
    getProductInformation() {
        return __awaiter(this, void 0, void 0, function* () {
            return {
                element: this.baseProductElement,
                name: (yield (yield this.titleElement()).textContent()).trim(),
                imageName: yield (yield this.imageNameElement()).getAttribute('src'),
                price: Number((yield (yield this.priceElement()).textContent()).trim().replace('$', '')),
                discountedPrice: (yield this.oldPriceElement()) ? Number((yield (yield this.oldPriceElement()).textContent()).replace('Old price', '').replace('$', '').trim()) : null,
                isOnSale: (yield this.saleBadgeElement()) != null,
                isSoldOut: (yield this.soldOutBadgeElement()) != null
            };
        });
    }
}
exports.ProductItemComponent = ProductItemComponent;
