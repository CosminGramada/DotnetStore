import {Page} from '@playwright/test';
import {AccountPage} from "./account.page";

export class AccountEmailPage {
    private readonly page;
    private readonly changeEmailButton = () => this.page.locator('#change-email-button');
    private readonly emailText = () => this.page.locator('#Email');
    private readonly emailField = () => this.page.locator('#Input_NewEmail');

    constructor(page: Page) {
        this.page = page;
    }

    async getEmail(): Promise<string> {
        return this.emailText().textContent();
    }

    async saveEmailChanges(email: string) {
        await this.emailField().fill(email);
        await this.changeEmailButton().click();
    }
}
