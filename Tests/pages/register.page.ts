import { Page } from '@playwright/test';
import {User} from "../interfaces/user";
import {RegisterConfirmationPage} from "./register-confirmation.page";

export class RegisterPage {
    private readonly page: Page;
    private readonly registerButton = () => this.page.locator('#registerSubmit');
    private readonly emailInput = () => this.page.locator('#Input_Email');
    private readonly usernameInput = () => this.page.locator('#Input_Username');
    private readonly firstNameInput = () => this.page.locator('#Input_FirstName');
    private readonly lastNameInput = () => this.page.locator('#Input_LastName');
    private readonly passwordInput = () => this.page.locator('#Input_Password');
    private readonly confirmPasswordInput = () => this.page.locator('#Input_ConfirmPassword');

    constructor(page: Page) {
        this.page = page;
    }

    async register(user: User) {
        await this.emailInput().fill(user.email);
        await this.usernameInput().fill(user.username);
        await this.firstNameInput().fill(user.firstName);
        await this.lastNameInput().fill(user.lastName);
        await this.passwordInput().fill(user.password);
        await this.confirmPasswordInput().fill(user.confirmPassword);
        await this.registerButton().click();
        const registerConfirmationPage = new RegisterConfirmationPage(this.page);
        await registerConfirmationPage.confirmRegistration();
    }
}
