import { Page } from '@playwright/test';
import {RegisterPage} from "./register.page";

export class LoginPage {
    private readonly page: Page;
    private readonly signInButton = () => this.page.locator('#login-submit');
    private readonly usernameInput = () => this.page.locator('#Input_Email');
    private readonly passwordInput = () => this.page.locator('#Input_Password');
    private readonly registerNewUserLink = () => this.page.locator('#register-user');
    private readonly loginErrorText = () => this.page.locator('div.text-danger li');

    constructor(page: Page) {
        this.page = page;
    }

    async login(username?: string, password?: string) {
        await this.enterUsername(username);
        await this.enterPassword(password);
        await this.clickSignInButton();
    }

    async getErrorMessage() {
        return this.loginErrorText().textContent();
    }

    async goToRegistration() {
        await this.registerNewUserLink().click();
        return new RegisterPage(this.page);
    }

    private async enterUsername(username: string) {
        await this.usernameInput().fill(username);
    }

    private async enterPassword(password: string) {
        await this.passwordInput().fill(password);
    }

    private async clickSignInButton() {
        await this.signInButton().first().click();
    }
}
