import {Page} from '@playwright/test';
import {BasePage} from "./base.page";
import {Product, ProductInformation} from "../interfaces/product";
import {ProductFormPage} from "./product-form.page";
import {ProductItemComponent} from "./product-item.page";

export class ProductsPage extends BasePage {
    private readonly addNewProductButton = () => this.page.locator('#add_new_product');
    private productsElements = () => this.page.$$('li.product-item');
    private productsElementss = () => this.page.locator('li.product-item');

    constructor(page: Page) {
        super(page);
    }

    async addNewProduct(product: Product) {
        await this.addNewProductButton().first().click();
        const productFormPage = new ProductFormPage(this.page);

        return productFormPage.addNewProduct(product);
    }

    async getAllProducts(): Promise<ProductInformation[]> {
        const allProducts = [];
        const productElements = await this.productsElements();

        for (const productElement of productElements) {
            const productItemComponent = new ProductItemComponent(productElement);
            allProducts.push(await productItemComponent.getProductInformation());
        }
        return allProducts;
    }

    async getProductByName(name: string): Promise<ProductInformation> {
        const products = await this.productsElementss();
        const handles = await products.elementHandles();

        for (const product of handles) {
            const titleElement = await product.$('.product-item-title');
            const title = await titleElement.textContent();
            if (title.trim() === name) {
                const oldPriceElement = await product.$('s.price-compare');
                const imageNameElement = await product.$('img.product-item-img');
                const priceElement = await product.$('span.price');
                const saleBadgeElement = await product.$('span.badge-sale');
                const soldOutBadgeElement = await product.$('span.badge-sold-out');

                return {
                    element: null,
                    name: title.trim(),
                    imageName: await imageNameElement.getAttribute('src'),
                    price: Number((await priceElement.textContent()).trim().replace('$', '')),
                    discountedPrice: oldPriceElement ? Number((await oldPriceElement.textContent()).replace('Old price', '').replace('$', '').trim()) : null,
                    isOnSale: saleBadgeElement != null,
                    isSoldOut: soldOutBadgeElement != null
                };
            }
        }

        return null;
    }
}
