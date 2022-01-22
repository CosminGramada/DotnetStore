import {Page} from "@playwright/test";
import {ProductItemComponent} from "./product-item.page";
import {ProductsPage} from "./products.page";

export class SearchResultsPage {
    private readonly page;
    private readonly productsElements = () => this.page.$$('li.product-item');

    constructor(page: Page) {
        this.page = page;
    }

    async getFirstProduct() {
        const products = await this.productsElements();
        const productItemComponent = new ProductItemComponent(products[0]);
        return productItemComponent.getProductInformation();
    }

    async getAllProducts() {
        const productsList = [];
        const products = await this.productsElements();
        for (const product of products) {
            const productItemComponent = new ProductItemComponent(product);
            productsList.push(await productItemComponent.getProductInformation());
        }
        return productsList;
    }

    async getProductInfo() {
        const products = await this.productsElements();
        const abc = products[0];
        const productItemComponent = new ProductItemComponent(abc);
        return productItemComponent.getProductInformation();
    }
}
