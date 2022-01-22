import {ElementHandle} from "playwright";
import {ProductInformation} from "../interfaces/product";

export class ProductItemComponent {
    private readonly baseProductElement: ElementHandle;
    private readonly oldPriceElement = () => this.baseProductElement.$('s.price-compare');
    private readonly imageNameElement = () => this.baseProductElement.$('img.product-item-img');
    private readonly priceElement = () => this.baseProductElement.$('span.price');
    private readonly saleBadgeElement = () => this.baseProductElement.$('span.badge-sale');
    private readonly soldOutBadgeElement = () => this.baseProductElement.$('span.badge-sold-out');
    private readonly titleElement = () => this.baseProductElement.$('.product-item-title');

    constructor(baseProductElement: ElementHandle) {
        this.baseProductElement = baseProductElement;
    }

    async getProductInformation(): Promise<ProductInformation> {
        return {
            element: this.baseProductElement,
            name: (await (await this.titleElement()).textContent()).trim(),
            imageName: await (await this.imageNameElement()).getAttribute('src'),
            price: Number((await (await this.priceElement()).textContent()).trim().replace('$', '')),
            discountedPrice: await this.oldPriceElement() ? Number((await (await this.oldPriceElement()).textContent()).replace('Old price', '').replace('$', '').trim()) : null,
            isOnSale: await this.saleBadgeElement() != null,
            isSoldOut: await this.soldOutBadgeElement() != null
        };
    }
}
