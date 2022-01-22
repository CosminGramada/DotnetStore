import {Page} from '@playwright/test';
import {AccountPage} from "./account.page";

export class AccountPasswordPage {
    private readonly page;
    private readonly updatePasswordButton = () => this.page.locator('#change-password-form button[type=submit]');
    private readonly currentPasswordField = () => this.page.locator('#Input_OldPassword');
    private readonly newPasswordField = () => this.page.locator('#Input_NewPassword');
    private readonly confirmNewPasswordField = () => this.page.locator('#Input_ConfirmPassword');

    constructor(page: Page) {
        this.page = page;
    }

    async updatePassword(oldPassword: string, newPassword) {
        await this.currentPasswordField().fill(oldPassword);
        await this.newPasswordField().fill(newPassword);
        await this.confirmNewPasswordField().fill(newPassword);
        await this.updatePasswordButton().click();
    }
}
