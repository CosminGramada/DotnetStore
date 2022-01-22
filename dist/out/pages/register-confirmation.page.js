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
exports.RegisterConfirmationPage = void 0;
const test_1 = require("@playwright/test");
class RegisterConfirmationPage {
    constructor(page) {
        this.registerConfirmLink = () => this.page.locator('#confirm-link');
        this.registerConfirmSuccessMessage = () => this.page.locator('div.alert');
        this.page = page;
    }
    confirmRegistration() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.registerConfirmLink().click();
            (0, test_1.expect)((yield this.registerConfirmSuccessMessage().textContent()).trim()).toBe('Thank you for confirming your email.');
        });
    }
}
exports.RegisterConfirmationPage = RegisterConfirmationPage;
