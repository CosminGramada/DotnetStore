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
exports.LoginPage = void 0;
const register_page_1 = require("./register.page");
class LoginPage {
    constructor(page) {
        this.signInButton = () => this.page.locator('#login-submit');
        this.usernameInput = () => this.page.locator('#Input_Email');
        this.passwordInput = () => this.page.locator('#Input_Password');
        this.registerNewUserLink = () => this.page.locator('#register-user');
        this.loginErrorText = () => this.page.locator('div.text-danger li');
        this.page = page;
    }
    login(username, password) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.enterUsername(username);
            yield this.enterPassword(password);
            yield this.clickSignInButton();
        });
    }
    getErrorMessage() {
        return __awaiter(this, void 0, void 0, function* () {
            return this.loginErrorText().textContent();
        });
    }
    goToRegistration() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.registerNewUserLink().click();
            return new register_page_1.RegisterPage(this.page);
        });
    }
    enterUsername(username) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.usernameInput().fill(username);
        });
    }
    enterPassword(password) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.passwordInput().fill(password);
        });
    }
    clickSignInButton() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.signInButton().first().click();
        });
    }
}
exports.LoginPage = LoginPage;
