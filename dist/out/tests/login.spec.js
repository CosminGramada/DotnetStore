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
test_1.test.describe('Login', () => {
    let homepage;
    let loginPage;
    test_1.test.beforeEach(({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        yield page.goto('https://localhost:7177/');
        homepage = new home_page_1.HomePage(page);
        loginPage = yield homepage.goToLogin();
    }));
    (0, test_1.test)('regular user should be able to login successfully', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        yield loginPage.login('Bernadette.Champlin@hotmail.com', 'Test123!');
        const greetingText = (yield homepage.getLoggedInUser()).join();
        (0, test_1.expect)(greetingText).toBe('Hi, Bernadette');
    }));
    (0, test_1.test)('user should get an error message for invalid credentials', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        yield loginPage.login('Bernadette.Champlin@hotmail.com', 'test123456');
        const errorMessage = yield loginPage.getErrorMessage();
        (0, test_1.expect)(errorMessage).toBe('Invalid login attempt.');
    }));
    (0, test_1.test)('admin user should be able to login successfully and land on Products page', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        yield loginPage.login('admin@dotnetstore.com', 'Test123!');
        const greetingText = (yield homepage.getLoggedInUser()).join();
        (0, test_1.expect)(greetingText).toBe('Hi, Administrator');
    }));
});
