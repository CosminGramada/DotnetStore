import {Page} from '@playwright/test';
import {AccountAddressesPage} from "./address.page";
import {Address} from "../../interfaces/address";

export class AddressFormPage {
    private readonly page: Page;
    private readonly firstNameInput = () => this.page.locator('#UserAddress_FirstName');
    private readonly lastNameInput = () => this.page.locator('#UserAddress_LastName');
    private readonly address1Input = () => this.page.locator('#UserAddress_Address1');
    private readonly address2Input = () => this.page.locator('#UserAddress_Address2');
    private readonly cityInput = () => this.page.locator('#UserAddress_City');
    private readonly countrySelect = () => this.page.locator('#UserAddress_CountryId');
    private readonly zipInput = () => this.page.locator('#UserAddress_Zip');
    private readonly phoneInput = () => this.page.locator('#UserAddress_PhoneNumber');
    private readonly setDefaultCheckbox = () => this.page.locator('#UserAddress_IsDefault');

    private readonly addAddressButton = () => this.page.locator('#address_form_new [type=submit]');

    constructor(page: Page) {
        this.page = page;

    }

    async addNewAddress(address: Address) {
        await this.firstNameInput().fill(address.firstName);
        await this.lastNameInput().fill(address.lastName);
        await this.address1Input().fill(address.address1);
        await this.address2Input().fill(address.address2);
        await this.cityInput().fill(address.city);
        await this.countrySelect().selectOption({label: address.country});
        await this.zipInput().fill(address.zip);
        await this.phoneInput().fill(address.phone);
        if (address.default) {
            await this.setDefaultCheckbox().check();
        }
        await this.addAddressButton().click();
        return new AccountAddressesPage(this.page);
    }
}
