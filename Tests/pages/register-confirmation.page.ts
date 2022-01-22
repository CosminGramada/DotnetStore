import {expect, Page} from '@playwright/test';

export class RegisterConfirmationPage {
    private readonly page: Page;
    private readonly registerConfirmLink = () => this.page.locator('#confirm-link');
    private readonly registerConfirmSuccessMessage = () => this.page.locator('div.alert');

    constructor(page: Page) {
        this.page = page;
    }

    async confirmRegistration() {
        await this.registerConfirmLink().click();
        expect((await this.registerConfirmSuccessMessage().textContent()).trim()).toBe('Thank you for confirming your email.');
    }
}
