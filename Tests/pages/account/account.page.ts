import {Page} from '@playwright/test';
import {AccountAddressesPage} from "./address.page";
import {Header} from "../header.page";
import {AccountMenu} from "../../enums/account-menu";
import {AccountProfilePage} from "./account-profile.page";
import {AccountEmailPage} from "./account-email.page";
import {AccountPasswordPage} from "./account-password.page";

export class AccountPage {
    protected readonly page;
    private readonly editUserButton = () => this.page.locator('#edit_user');
    private readonly userDetailsText = () => this.page.locator('#user-details address p');
    private readonly profileMenuItem = () => this.page.locator('#profile');
    private readonly emailMenuItem = () => this.page.locator('#email');
    private readonly passwordMenuItem = () => this.page.locator('#change-password');
    private readonly addressesMenuItem = () => this.page.locator('#address');
    private readonly ordersMenuItem = () => this.page.locator('#orders');

    constructor(page: Page) {
        this.page = page;
    }
    
    async openAccountMenuItem(menuItem: AccountMenu) {
        switch (menuItem) {
            case AccountMenu.Profile: {
                this.profileMenuItem().click();
                return new AccountProfilePage(this.page);
            }
            case AccountMenu.Email: {
                this.emailMenuItem().click();
                return new AccountEmailPage(this.page);
            }
            case AccountMenu.Password: {
                this.passwordMenuItem().click();
                return new AccountPasswordPage(this.page);
            }
            case AccountMenu.Addresses: {
                this.addressesMenuItem().click();
                return new AccountAddressesPage(this.page);
            }
            case AccountMenu.Orders: {
                this.ordersMenuItem().click();
                return new AccountProfilePage(this.page);
            }
        }
    }

    header = () => new Header(this.page);
}
