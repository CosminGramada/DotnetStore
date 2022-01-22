import {Page} from '@playwright/test';
import {AddressFormPage} from "./address-form.page";
import {address as fakerAddress, name, phone} from "faker";
import {Address} from "../../interfaces/address";
import {ElementHandle} from "playwright";

export class AccountAddressesPage {
    private readonly page;
    private readonly addAddressButton = () => this.page.locator('#add-address a');
    private readonly addressesCards = () => this.page.$$('#addresses-list li');
    private readonly addressDetailsText = () => this.page.locator('#account-details address p');

    constructor(page: Page) {
        this.page = page;
    }

    async addNewAddress() {
        await this.addAddressButton().first().click();
        const addressForm = new AddressFormPage(this.page);

        const address: Address = {
            firstName: name.firstName(),
            lastName: name.lastName(),
            address1: fakerAddress.streetAddress(),
            address2: fakerAddress.secondaryAddress(),
            city: fakerAddress.cityName().replace(' ', '-'),
            country: 'United States',
            region: 'Alabama',
            zip: fakerAddress.zipCode(),
            phone: phone.phoneNumber(),
            default: true
        };
        await addressForm.addNewAddress(address);
        return address;
    }

    async getAllAddressesDetails(): Promise<Address[]> {
        const addresses: ElementHandle[] = await this.addressesCards();
        const addressList: Address[] = [];
        for (const addressCard of addresses) {
            const isDefault = await (await addressCard.$('h3.h4')).isVisible();
            const addressBody = await addressCard.$('address');
            const address = (await addressBody.textContent()).replace(/(\r\n|\n|\r)/gm, "").split("  ").filter(line => line != "");
            
            addressList.push({
                firstName: address[0].split(" ")[0],
                lastName: address[0].split(" ")[1],
                address1: address[1],
                address2: address[2],
                zip: address[3].split(" ")[0],
                city: address[3].split(" ")[1],
                region: address[3].split(" ")[2],
                country: address[4],
                default: isDefault
            });
        }
        
        return addressList;
    }
}
