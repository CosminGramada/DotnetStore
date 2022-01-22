import {Page} from '@playwright/test';
import {LoginPage} from "./login.page";
import {SearchResultsPage} from "./search-results.page";
import {ProductsPage} from "./products.page";
import {CartPage} from "./cart.page";
import {RegisterPage} from "./register.page";
import {AccountPage} from "./account/account.page";

export class Header {
    private readonly page;
    private accountButton = () => this.page.locator('#account-nav-item');
    private loginButton = () => this.page.locator('#login-nav-item');
    private registerButton = () => this.page.locator('#register-nav-item');
    private searchButton = () => this.page.locator('#search-nav-item');
    private searchInput = () => this.page.locator('#minisearch-input');
    private searchGoButton = () => this.page.locator('#search-nav-item button');
    private catalogMenu = () => this.page.locator('#navbar-nav #catalog');
    private catalogAllProductsMenuItem = () => this.page.locator('#navbar-nav #catalog-all');
    private productsMenu = () => this.page.locator('#product_menu');
    private productsMenuItem = () => this.page.locator('#manage_products');
    private cartButton = () => this.page.locator('#cart-nav-item');
    private viewCartButton = () => this.page.locator('#cart-nav-item .minicart-view-cart-btn');

    private loggedInUserText = () => this.page.locator('#user-name');

    constructor(page: Page) {
        this.page = page;
    }

    async goToAccount(): Promise<AccountPage> {
        await this.accountButton().first().click();
        return new AccountPage(this.page);
    }

    async goToLogin(): Promise<LoginPage> {
        await this.loginButton().first().click();
        return new LoginPage(this.page);
    }

    async goToRegister(): Promise<RegisterPage> {
        await this.registerButton().first().click();
        return new RegisterPage(this.page);
    }

    async getLoggedInUser() {
        return this.loggedInUserText().allInnerTexts();
    }

    async userIsLoggedIn() {
        const text = await this.loggedInUserText().allTextContents();
        return text.length > 0;
    }

    async goToAllProducts() {
        await this.catalogMenu().click();
        await this.catalogAllProductsMenuItem().click();
        return new ProductsPage(this.page);
    }

    async goToAdminManageProductsPage() {
        await this.productsMenu().click();
        await this.productsMenuItem().click();
        return new ProductsPage(this.page);
    }

    async searchForProduct(productName: string) {
        await this.searchButton().click();
        await this.searchInput().fill(productName);
        await this.searchGoButton().click();

        return new SearchResultsPage(this.page);
    }

    async goToCartPage() {
        await this.cartButton().click();
        await this.viewCartButton().click();
        return new CartPage(this.page);
    }
}
