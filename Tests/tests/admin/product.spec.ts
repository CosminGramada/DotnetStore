import {test, expect} from '@playwright/test';
import {UserTestHelper} from "../../test-helpers/user-helper";
import {ProductCategory, ProductColor, ProductSize} from "../../enums/product";
import {Product} from "../../interfaces/product";
import {commerce} from "faker";
import * as path from "path";
import {Validators} from "../../test-helpers/validators";
import {SearchResultsPage} from "../../pages/search-results.page";
import {HomePage} from "../../pages/home.page";

test.describe('Product', () => {
    test.beforeEach(async ({page}) => {
        await page.goto('https://localhost:7177/');
    });

    test('admin user should be able to add new products with mandatory details only', async ({page}) => {
        const homepagePage = await UserTestHelper.loginWithAdminUser(page);
        // @ts-ignore
        const categories = Object.keys(ProductCategory).filter(c => isNaN(c));

        const productModel: Product = {
            name: commerce.product(),
            description: commerce.productDescription(),
            price: Math.floor(Math.random() * (10000 - 100) + 100) / 100,
            category: categories[Math.floor(Math.random() * categories.length)] as unknown as ProductCategory,
            variants: [
                {
                    color: ProductColor.Blue,
                    size: ProductSize.Small,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: ProductColor.Black,
                    size: ProductSize.Small,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: ProductColor.Red,
                    size: ProductSize.Medium,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: ProductColor.Yellow,
                    size: ProductSize.ExtraLarge,
                    quantity: Math.floor(Math.random() * 100) + 1
                }
            ]
        };
        const productsPage = await homepagePage.goToAdminManageProductsPage();
        await productsPage.addNewProduct(productModel);

        const productInfo = await productsPage.getProductByName(productModel.name);
        Validators.validateProduct(productModel, productInfo);
    });

    test('admin user should be able to add new products with an image', async ({page}) => {
        const homePage = await UserTestHelper.loginWithAdminUser(page);

        // @ts-ignore
        const categories = Object.keys(ProductCategory).filter(c => isNaN(c));
        const productModel: Product = {
            name: commerce.product(),
            description: commerce.productDescription(),
            price: Math.floor(Math.random() * (10000 - 100) + 100) / 100,
            category: categories[Math.floor(Math.random() * categories.length)] as unknown as ProductCategory,
            variants: [
                {
                    color: ProductColor.Blue,
                    size: ProductSize.Small,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: ProductColor.Black,
                    size: ProductSize.Small,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: ProductColor.Red,
                    size: ProductSize.Medium,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: ProductColor.Yellow,
                    size: ProductSize.ExtraLarge,
                    quantity: Math.floor(Math.random() * 100) + 1
                }
            ],
            imageName: path.join(__dirname, '/../../assets/sweater.png')
        };
        const productsPage = await homePage.goToAdminManageProductsPage();
        await productsPage.addNewProduct(productModel);
        const productInfo = await productsPage.getProductByName(productModel.name);

        Validators.validateProduct(productModel, productInfo);
    });

    test('product with 0 quantity should be displayed as Sold Out', async ({page}) => {
        const homePage = await UserTestHelper.loginWithAdminUser(page);

        // @ts-ignore
        const categories = Object.keys(ProductCategory).filter(c => isNaN(c));
        const productModel: Product = {
            name: commerce.product(),
            description: commerce.productDescription(),
            price: Math.floor(Math.random() * (10000 - 100) + 100) / 100,
            category: categories[Math.floor(Math.random() * categories.length)] as unknown as ProductCategory,
            variants: [
                {
                    color: ProductColor.Blue,
                    size: ProductSize.Small,
                    quantity: 0
                }
            ]
        };
        const productsPage = await homePage.goToAdminManageProductsPage();
        await productsPage.addNewProduct(productModel);
        const productInfo = await productsPage.getProductByName(productModel.name);

        Validators.validateProduct(productModel, productInfo);
    });

    test('discounted product should be displayed on Sale with a discounted price', async ({page}) => {
        const homePage = await UserTestHelper.loginWithAdminUser(page);

        // @ts-ignore
        const categories = Object.keys(ProductCategory).filter(c => isNaN(c));
        const productModel: Product = {
            name: commerce.product(),
            description: commerce.productDescription(),
            price: Math.floor(Math.random() * (10000 - 100) + 100) / 100,
            category: categories[Math.floor(Math.random() * categories.length)] as unknown as ProductCategory,
            variants: [
                {
                    color: ProductColor.Blue,
                    size: ProductSize.Small,
                    quantity: 1
                }
            ],
            discount: '10% Discount'
        };
        const productsPage = await homePage.goToAdminManageProductsPage();
        await productsPage.addNewProduct(productModel);
        const productInfo = await productsPage.getProductByName(productModel.name);

        Validators.validateProduct(productModel, productInfo);
    });
});
