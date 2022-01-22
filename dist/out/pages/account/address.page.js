"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.AccountAddressesPage = void 0;
const address_form_page_1 = require("./address-form.page");
const faker_1 = require("faker");
class AccountAddressesPage {
    constructor(page) {
        this.addAddressButton = () => this.page.locator('#add-address button');
        this.addressesCards = () => this.page.locator('#addresses-list li');
        this.page = page;
    }
    addNewAddress() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.addAddressButton().first().click();
            const addressForm = new address_form_page_1.AddressFormPage(this.page);
            const address = {
                firstName: faker_1.name.firstName(),
                lastName: faker_1.name.lastName(),
                address1: faker_1.address.streetAddress(),
                address2: faker_1.address.secondaryAddress(),
                city: faker_1.address.cityName().replace(' ', '-'),
                country: 'United States',
                region: 'Alabama',
                zip: faker_1.address.zipCode(),
                phone: faker_1.phone.phoneNumber(),
                default: true
            };
            yield addressForm.addNewAddress(address);
            return address;
        });
    }
}
exports.AccountAddressesPage = AccountAddressesPage;
