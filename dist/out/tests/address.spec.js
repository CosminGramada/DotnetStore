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
const test_1 = require("@playwright/test");
const home_page_1 = require("../pages/home.page");
const user_helper_1 = require("../test-helpers/user-helper");
const account_menu_1 = require("../enums/account-menu");
test_1.test.describe('Address', () => {
    test_1.test.beforeEach(({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        yield page.goto('https://localhost:7177/');
    }));
    (0, test_1.test)('new user should be able to see his default address information on the account page', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        const user = yield user_helper_1.UserTestHelper.registerUser(page);
        const homepage = new home_page_1.HomePage(page);
        let accountPage = yield homepage.goToAccount();
        const addressesPage = yield accountPage.openAccountMenuItem(account_menu_1.AccountMenu.Addresses);
        const address = yield addressesPage.addNewAddress();
        const accountAddress = yield accountPage.getAddressDetails();
        (0, test_1.expect)(address.firstName).toBe(accountAddress.firstName);
        (0, test_1.expect)(address.lastName).toBe(accountAddress.lastName);
        (0, test_1.expect)(address.address1).toBe(accountAddress.address1);
        (0, test_1.expect)(address.address2).toBe(accountAddress.address2);
        (0, test_1.expect)(address.zip).toBe(accountAddress.zip);
        (0, test_1.expect)(address.city).toBe(accountAddress.city);
        (0, test_1.expect)(address.region).toBe(accountAddress.region);
        (0, test_1.expect)(address.country).toBe(accountAddress.country);
    }));
});
