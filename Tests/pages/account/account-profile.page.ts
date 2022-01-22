import {Page} from '@playwright/test';

export class AccountProfilePage {
    private readonly page;
    private readonly saveProfileButton = () => this.page.locator('#update-profile-button');
    private readonly usernameText = () => this.page.locator('#Username');
    private readonly phoneNumberField = () => this.page.locator('#Input_PhoneNumber');

    constructor(page: Page) {
        this.page = page;
    }

    async getUsername(): Promise<string> {
        return (await this.usernameText()).getAttribute('value');
    }

    async saveProfileChanges(phoneNumber: string) {
        await this.phoneNumberField().fill(phoneNumber);
        await this.saveProfileButton().click();
    }
}
