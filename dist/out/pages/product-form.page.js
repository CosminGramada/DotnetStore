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
exports.ProductFormPage = void 0;
const products_page_1 = require("./products.page");
const base_page_1 = require("./base.page");
class ProductFormPage extends base_page_1.BasePage {
    constructor(page) {
        super(page);
        this.nameInput = () => this.page.locator('#Product_Name');
        this.descriptionTextArea = () => this.page.locator('#Product_Description');
        this.categorySelect = () => this.page.locator('#Product_CategoryId');
        this.addVariantButton = () => this.page.locator('#add_variant input');
        this.variantRow = () => this.page.locator('[role=row]');
        this.priceInput = () => this.page.locator('#Product_Price');
        this.discountSelect = () => this.page.locator('#Product_DiscountId');
        this.imageInput = () => this.page.locator('#Product_ImageFile');
        this.saveChangesButton = () => this.page.locator('#save_changes');
    }
    addNewProduct(product, addAnother = false) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.nameInput().fill(product.name);
            if (product.description) {
                yield this.descriptionTextArea().fill(product.description);
            }
            yield this.categorySelect().selectOption({ label: product.category.toString() });
            for (const variant of product.variants) {
                yield this.addVariantButton().click();
                yield this.variantRow().last().locator('[name^=product_color]').selectOption({ label: variant.color });
                yield this.variantRow().last().locator('[name^=product_size]').selectOption({ label: variant.size });
                yield this.variantRow().last().locator('[name^=quantity]').fill(variant.quantity.toString());
            }
            yield this.priceInput().fill(product.price.toString());
            if (product.discount) {
                yield this.discountSelect().selectOption({ label: product.discount });
            }
            if (product.imageName) {
                yield this.imageInput().setInputFiles(product.imageName);
            }
            yield this.saveChangesButton().click();
            return new products_page_1.ProductsPage(this.page);
        });
    }
}
exports.ProductFormPage = ProductFormPage;
