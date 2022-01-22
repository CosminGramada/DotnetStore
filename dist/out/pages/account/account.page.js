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
exports.AccountPage = void 0;
const address_page_1 = require("./address.page");
const header_page_1 = require("../header.page");
const account_menu_1 = require("../../enums/account-menu");
const account_profile_page_1 = require("./account-profile.page");
const account_email_page_1 = require("./account-email.page");
const account_password_page_1 = require("./account-password.page");
class AccountPage {
    constructor(page) {
        this.editUserButton = () => this.page.locator('#edit_user');
        this.userDetailsText = () => this.page.locator('#user-details address p');
        this.viewAddressesButton = () => this.page.locator('#view_addresses');
        this.addressDetailsText = () => this.page.locator('#account-details address p');
        this.profileMenuItem = () => this.page.locator('#profile');
        this.emailMenuItem = () => this.page.locator('#email');
        this.passwordMenuItem = () => this.page.locator('#change-password');
        this.addressesMenuItem = () => this.page.locator('#address');
        this.ordersMenuItem = () => this.page.locator('#orders');
        this.header = () => new header_page_1.Header(this.page);
        this.page = page;
    }
    getUserDetails() {
        return __awaiter(this, void 0, void 0, function* () {
            const userDetails = (yield this.userDetailsText().textContent()).split(/\s+/g).filter(line => line != "");
            return {
                firstName: userDetails[0],
                lastName: userDetails[1],
                email: userDetails[2],
                username: userDetails[3]
            };
        });
    }
    getAddressDetails() {
        return __awaiter(this, void 0, void 0, function* () {
            const abc = yield this.addressDetailsText().textContent();
            const def = abc.replace(/\\n/g, '');
            const address = (yield this.addressDetailsText().textContent()).replace(/(\r\n|\n|\r)/gm, "").split("  ").filter(line => line != "");
            return {
                firstName: address[0].split(" ")[0],
                lastName: address[0].split(" ")[1],
                address1: address[1],
                address2: address[2],
                zip: address[3].split(" ")[0],
                city: address[3].split(" ")[1],
                region: address[3].split(" ")[2],
                country: address[4]
            };
        });
    }
    openAccountMenuItem(menuItem) {
        return __awaiter(this, void 0, void 0, function* () {
            switch (menuItem) {
                case account_menu_1.AccountMenu.Profile: {
                    this.profileMenuItem().click();
                    return new account_profile_page_1.AccountProfilePage(this.page);
                }
                case account_menu_1.AccountMenu.Email: {
                    this.emailMenuItem().click();
                    return new account_email_page_1.AccountEmailPage(this.page);
                }
                case account_menu_1.AccountMenu.Password: {
                    this.passwordMenuItem().click();
                    return new account_password_page_1.AccountPasswordPage(this.page);
                }
                case account_menu_1.AccountMenu.Addresses: {
                    this.addressesMenuItem().click();
                    return new address_page_1.AccountAddressesPage(this.page);
                }
                case account_menu_1.AccountMenu.Orders: {
                    this.ordersMenuItem().click();
                    return new account_profile_page_1.AccountProfilePage(this.page);
                }
            }
        });
    }
}
exports.AccountPage = AccountPage;
