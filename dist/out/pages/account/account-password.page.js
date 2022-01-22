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
exports.AccountPasswordPage = void 0;
const account_page_1 = require("./account.page");
class AccountPasswordPage extends account_page_1.AccountPage {
    constructor(page) {
        super(page);
        this.updatePasswordButton = () => this.page.locator('#change-password-form button[type=submit]');
        this.currentPasswordField = () => this.page.locator('#Input_OldPassword');
        this.newPasswordField = () => this.page.locator('#Input_NewPassword');
        this.confirmNewPasswordField = () => this.page.locator('#Input_ConfirmPassword');
    }
    updatePassword(oldPassword, newPassword) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.currentPasswordField().fill(oldPassword);
            yield this.newPasswordField().fill(newPassword);
            yield this.confirmNewPasswordField().fill(newPassword);
            yield this.updatePasswordButton().click();
        });
    }
}
exports.AccountPasswordPage = AccountPasswordPage;
