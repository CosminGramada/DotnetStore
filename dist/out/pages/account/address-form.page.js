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
exports.AddressFormPage = void 0;
const address_page_1 = require("./address.page");
class AddressFormPage {
    constructor(page) {
        this.firstNameInput = () => this.page.locator('#address_form_new [name=address_first_name]');
        this.lastNameInput = () => this.page.locator('#address_form_new [name=address_last_name]');
        this.address1Input = () => this.page.locator('#address_form_new [name=address_address1]');
        this.address2Input = () => this.page.locator('#address_form_new [name=address_address2]');
        this.cityInput = () => this.page.locator('#address_form_new [name=address_city]');
        this.countrySelect = () => this.page.locator('#address_form_new [name=address_country]');
        this.regionInput = () => this.page.locator('#address_form_new [name=address_province]');
        this.zipInput = () => this.page.locator('#address_form_new [name=address_zip]');
        this.phoneInput = () => this.page.locator('#address_form_new [name=address_phone]');
        this.setDefaultCheckbox = () => this.page.locator('#address_form_new [name=address_default]');
        this.addAddressButton = () => this.page.locator('#address_form_new [type=submit]');
        this.addressesCards = () => this.page.locator('#addresses-list li');
        this.page = page;
    }
    addNewAddress(address) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.firstNameInput().fill(address.firstName);
            yield this.lastNameInput().fill(address.lastName);
            yield this.address1Input().fill(address.address1);
            yield this.address2Input().fill(address.address2);
            yield this.cityInput().fill(address.city);
            yield this.countrySelect().selectOption({ label: address.country });
            yield this.regionInput().selectOption({ label: address.region });
            yield this.zipInput().fill(address.zip);
            yield this.phoneInput().fill(address.phone);
            if (address.default) {
                yield this.setDefaultCheckbox().check();
            }
            yield this.addAddressButton().click();
            return new address_page_1.AccountAddressesPage(this.page);
        });
    }
}
exports.AddressFormPage = AddressFormPage;
