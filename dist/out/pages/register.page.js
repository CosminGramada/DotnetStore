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
exports.RegisterPage = void 0;
const register_confirmation_page_1 = require("./register-confirmation.page");
class RegisterPage {
    constructor(page) {
        this.registerButton = () => this.page.locator('#registerSubmit');
        this.emailInput = () => this.page.locator('#Input_Email');
        this.usernameInput = () => this.page.locator('#Input_Username');
        this.firstNameInput = () => this.page.locator('#Input_FirstName');
        this.lastNameInput = () => this.page.locator('#Input_LastName');
        this.passwordInput = () => this.page.locator('#Input_Password');
        this.confirmPasswordInput = () => this.page.locator('#Input_ConfirmPassword');
        this.page = page;
    }
    register(user) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.emailInput().fill(user.email);
            yield this.usernameInput().fill(user.username);
            yield this.firstNameInput().fill(user.firstName);
            yield this.lastNameInput().fill(user.lastName);
            yield this.passwordInput().fill(user.password);
            yield this.confirmPasswordInput().fill(user.confirmPassword);
            yield this.registerButton().click();
            const registerConfirmationPage = new register_confirmation_page_1.RegisterConfirmationPage(this.page);
            yield registerConfirmationPage.confirmRegistration();
        });
    }
}
exports.RegisterPage = RegisterPage;
