import {Page} from '@playwright/test';
import {Product} from "../interfaces/product";
import {ProductsPage} from "./products.page";
import {BasePage} from "./base.page";

export class ProductFormPage extends BasePage {

    private readonly nameInput = () => this.page.locator('#Product_Name');
    private readonly descriptionTextArea = () => this.page.locator('#Product_Description');
    private readonly categorySelect = () => this.page.locator('#Product_CategoryId');
    private readonly addVariantButton = () => this.page.locator('#add_variant input');
    private readonly variantRow = () => this.page.locator('[role=row]');
    private readonly priceInput = () => this.page.locator('#Product_Price');
    private readonly discountSelect = () => this.page.locator('#Product_DiscountId');
    private readonly imageInput = () => this.page.locator('#Product_ImageFile');
    private readonly saveChangesButton = () => this.page.locator('#save_changes');

    constructor(page: Page) {
        super(page);
    }

    async addNewProduct(product: Product, addAnother = false) {
        await this.nameInput().fill(product.name);
        if (product.description) {
            await this.descriptionTextArea().fill(product.description);
        }
        await this.categorySelect().selectOption({label: product.category.toString()});
        for (const variant of product.variants) {
            await this.addVariantButton().click();
            await this.variantRow().last().locator('[name^=product_color]').selectOption({label: variant.color});
            await this.variantRow().last().locator('[name^=product_size]').selectOption({label: variant.size});
            await this.variantRow().last().locator('[name^=quantity]').fill(variant.quantity.toString());
        }
        await this.priceInput().fill(product.price.toString());
        if (product.discount) {
            await this.discountSelect().selectOption({label: product.discount});
        }
        if (product.imageName) {
            await this.imageInput().setInputFiles(product.imageName);
        }
        
        await this.saveChangesButton().click();
        return new ProductsPage(this.page);
    }
}
