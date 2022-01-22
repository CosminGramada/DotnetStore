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
exports.AccountEmailPage = void 0;
const account_page_1 = require("./account.page");
class AccountEmailPage extends account_page_1.AccountPage {
    constructor(page) {
        super(page);
        this.changeEmailButton = () => this.page.locator('#change-email-button');
        this.emailText = () => this.page.locator('#Email');
        this.emailField = () => this.page.locator('#Input_NewEmail');
    }
    getEmail() {
        return __awaiter(this, void 0, void 0, function* () {
            return this.emailText().textContent();
        });
    }
    saveEmailChanges(email) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.emailField().fill(email);
            yield this.changeEmailButton().click();
        });
    }
}
exports.AccountEmailPage = AccountEmailPage;
