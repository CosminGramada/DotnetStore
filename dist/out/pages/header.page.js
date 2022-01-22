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
exports.Header = void 0;
const login_page_1 = require("./login.page");
const search_results_page_1 = require("./search-results.page");
const products_page_1 = require("./products.page");
const cart_page_1 = require("./cart.page");
const register_page_1 = require("./register.page");
const account_page_1 = require("./account/account.page");
class Header {
    constructor(page) {
        this.accountButton = () => this.page.locator('#account-nav-item');
        this.loginButton = () => this.page.locator('#login-nav-item');
        this.registerButton = () => this.page.locator('#register-nav-item');
        this.searchButton = () => this.page.locator('#search-nav-item');
        this.searchInput = () => this.page.locator('#minisearch-input');
        this.searchGoButton = () => this.page.locator('#search-nav-item button');
        this.catalogMenu = () => this.page.locator('#navbar-nav #catalog');
        this.catalogAllProductsMenuItem = () => this.page.locator('#navbar-nav #catalog-all');
        this.productsMenu = () => this.page.locator('#product_menu');
        this.productsMenuItem = () => this.page.locator('#manage_products');
        this.cartButton = () => this.page.locator('#cart-nav-item');
        this.viewCartButton = () => this.page.locator('#cart-nav-item .minicart-view-cart-btn');
        this.loggedInUserText = () => this.page.locator('#user-name');
        this.page = page;
    }
    goToAccount() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.accountButton().first().click();
            return new account_page_1.AccountPage(this.page);
        });
    }
    goToLogin() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.loginButton().first().click();
            return new login_page_1.LoginPage(this.page);
        });
    }
    goToRegister() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.registerButton().first().click();
            return new register_page_1.RegisterPage(this.page);
        });
    }
    getLoggedInUser() {
        return __awaiter(this, void 0, void 0, function* () {
            return this.loggedInUserText().allInnerTexts();
        });
    }
    userIsLoggedIn() {
        return __awaiter(this, void 0, void 0, function* () {
            const text = yield this.loggedInUserText().allTextContents();
            return text.length > 0;
        });
    }
    goToAllProducts() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.catalogMenu().click();
            yield this.catalogAllProductsMenuItem().click();
            return new products_page_1.ProductsPage(this.page);
        });
    }
    goToAdminManageProductsPage() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.productsMenu().click();
            yield this.productsMenuItem().click();
            return new products_page_1.ProductsPage(this.page);
        });
    }
    searchForProduct(productName) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.searchButton().click();
            yield this.searchInput().fill(productName);
            yield this.searchGoButton().click();
            return new search_results_page_1.SearchResultsPage(this.page);
        });
    }
    goToCartPage() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.cartButton().click();
            yield this.viewCartButton().click();
            return new cart_page_1.CartPage(this.page);
        });
    }
}
exports.Header = Header;
