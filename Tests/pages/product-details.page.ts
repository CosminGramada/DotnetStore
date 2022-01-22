import {Locator, Page} from '@playwright/test';
import {Header} from "./header.page";

export class ProductDetailsPage {
    private readonly page;
    private readonly addToCartButton = () => this.page.locator('.add-to-cart-btn');
    private readonly colorSelect = () => this.page.locator('#option-select-color');
    private readonly sizeSelect = (): Locator => this.page.locator('#option-select-size');

    constructor(page: Page) {
        this.page = page;
    }

    async addProductToCart() {
        const firstColorElement = await this.colorSelect().first().locator('option').last();
        const colorName = await firstColorElement.textContent();
        await Promise.all([
            this.colorSelect().first().selectOption({label: colorName}),
            this.page.waitForFunction(() => {
                const select = document.querySelector('#option-select-size');
                if (!select)
                    return false;
                // @ts-ignore
                return [...select.options].length > 1;
            })
        ]);

        await this.page.waitForLoadState('networkidle');
        
        const firstSizeElement = await this.sizeSelect().first().locator('option').last();
        const sizeName = await firstSizeElement.textContent();

        await Promise.all([
            this.sizeSelect().first().selectOption({label: sizeName}),
            this.addToCartButton().getAttribute('disabled') == null
        ]);

        await this.addToCartButton().click();
        return this;
    }

    header = () => new Header(this.page);
}
