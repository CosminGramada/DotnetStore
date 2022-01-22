"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    Object.defineProperty(o, k2, { enumerable: true, get: function() { return m[k]; } });
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
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
const test_1 = require("@playwright/test");
const user_helper_1 = require("../../test-helpers/user-helper");
const product_1 = require("../../enums/product");
const faker_1 = require("faker");
const path = __importStar(require("path"));
const validators_1 = require("../../test-helpers/validators");
test_1.test.describe('Product', () => {
    test_1.test.beforeEach(({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        yield page.goto('https://localhost:7177/');
    }));
    (0, test_1.test)('admin user should be able to add new products with mandatory details only', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        const homepagePage = yield user_helper_1.UserTestHelper.loginWithAdminUser(page);
        // @ts-ignore
        const categories = Object.keys(product_1.ProductCategory).filter(c => isNaN(c));
        const productModel = {
            name: faker_1.commerce.product(),
            description: faker_1.commerce.productDescription(),
            price: Math.floor(Math.random() * (10000 - 100) + 100) / 100,
            category: categories[Math.floor(Math.random() * categories.length)],
            variants: [
                {
                    color: product_1.ProductColor.Blue,
                    size: product_1.ProductSize.Small,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: product_1.ProductColor.Black,
                    size: product_1.ProductSize.Small,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: product_1.ProductColor.Red,
                    size: product_1.ProductSize.Medium,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: product_1.ProductColor.Yellow,
                    size: product_1.ProductSize.ExtraLarge,
                    quantity: Math.floor(Math.random() * 100) + 1
                }
            ]
        };
        const productsPage = yield homepagePage.goToAdminManageProductsPage();
        yield productsPage.addNewProduct(productModel);
        const productInfo = yield productsPage.getProductByName(productModel.name);
        validators_1.Validators.validateProduct(productModel, productInfo);
    }));
    (0, test_1.test)('admin user should be able to add new products with an image', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        const homePage = yield user_helper_1.UserTestHelper.loginWithAdminUser(page);
        // @ts-ignore
        const categories = Object.keys(product_1.ProductCategory).filter(c => isNaN(c));
        const productModel = {
            name: faker_1.commerce.product(),
            description: faker_1.commerce.productDescription(),
            price: Math.floor(Math.random() * (10000 - 100) + 100) / 100,
            category: categories[Math.floor(Math.random() * categories.length)],
            variants: [
                {
                    color: product_1.ProductColor.Blue,
                    size: product_1.ProductSize.Small,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: product_1.ProductColor.Black,
                    size: product_1.ProductSize.Small,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: product_1.ProductColor.Red,
                    size: product_1.ProductSize.Medium,
                    quantity: Math.floor(Math.random() * 100) + 1
                },
                {
                    color: product_1.ProductColor.Yellow,
                    size: product_1.ProductSize.ExtraLarge,
                    quantity: Math.floor(Math.random() * 100) + 1
                }
            ],
            imageName: path.join(__dirname, '/../../assets/sweater.png')
        };
        const productsPage = yield homePage.goToAdminManageProductsPage();
        yield productsPage.addNewProduct(productModel);
        const productInfo = yield productsPage.getProductByName(productModel.name);
        validators_1.Validators.validateProduct(productModel, productInfo);
    }));
    (0, test_1.test)('product with 0 quantity should be displayed as Sold Out', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        const homePage = yield user_helper_1.UserTestHelper.loginWithAdminUser(page);
        // @ts-ignore
        const categories = Object.keys(product_1.ProductCategory).filter(c => isNaN(c));
        const productModel = {
            name: faker_1.commerce.product(),
            description: faker_1.commerce.productDescription(),
            price: Math.floor(Math.random() * (10000 - 100) + 100) / 100,
            category: categories[Math.floor(Math.random() * categories.length)],
            variants: [
                {
                    color: product_1.ProductColor.Blue,
                    size: product_1.ProductSize.Small,
                    quantity: 0
                }
            ]
        };
        const productsPage = yield homePage.goToAdminManageProductsPage();
        yield productsPage.addNewProduct(productModel);
        const productInfo = yield productsPage.getProductByName(productModel.name);
        validators_1.Validators.validateProduct(productModel, productInfo);
    }));
    (0, test_1.test)('discounted product should be displayed on Sale with a discounted price', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        const homePage = yield user_helper_1.UserTestHelper.loginWithAdminUser(page);
        // @ts-ignore
        const categories = Object.keys(product_1.ProductCategory).filter(c => isNaN(c));
        const productModel = {
            name: faker_1.commerce.product(),
            description: faker_1.commerce.productDescription(),
            price: Math.floor(Math.random() * (10000 - 100) + 100) / 100,
            category: categories[Math.floor(Math.random() * categories.length)],
            variants: [
                {
                    color: product_1.ProductColor.Blue,
                    size: product_1.ProductSize.Small,
                    quantity: 1
                }
            ],
            discount: '10% Discount'
        };
        const productsPage = yield homePage.goToAdminManageProductsPage();
        yield productsPage.addNewProduct(productModel);
        const productInfo = yield productsPage.getProductByName(productModel.name);
        validators_1.Validators.validateProduct(productModel, productInfo);
    }));
});
