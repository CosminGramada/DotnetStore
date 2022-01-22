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
exports.AccountProfilePage = void 0;
const account_page_1 = require("./account.page");
class AccountProfilePage extends account_page_1.AccountPage {
    constructor(page) {
        super(page);
        this.saveProfileButton = () => this.page.locator('#update-profile-button');
        this.usernameText = () => this.page.locator('#Username');
        this.phoneNumberField = () => this.page.locator('#Input_PhoneNumber');
    }
    getUsername() {
        return __awaiter(this, void 0, void 0, function* () {
            return this.usernameText().textContent();
        });
    }
    saveProfileChanges(phoneNumber) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.phoneNumberField().fill(phoneNumber);
            yield this.saveProfileButton().click();
        });
    }
}
exports.AccountProfilePage = AccountProfilePage;
