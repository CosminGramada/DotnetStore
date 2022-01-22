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
test_1.test.describe('Register', () => {
    test_1.test.beforeEach(({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        yield page.goto('https://localhost:7177/');
    }));
    (0, test_1.test)('user should be able to create a new account', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        const user = yield user_helper_1.UserTestHelper.registerUser(page);
        const homepage = new home_page_1.HomePage(page);
        const loginPage = yield homepage.goToLogin();
        yield loginPage.login(user.email, user.password);
        const greetingText = (yield homepage.getLoggedInUser()).join();
        (0, test_1.expect)(greetingText).toBe(`Hi, ${user.firstName}`);
    }));
    (0, test_1.test)('new user should be able to see his information on the account page', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        const user = yield user_helper_1.UserTestHelper.registerUser(page);
        const homepage = new home_page_1.HomePage(page);
        const loginPage = yield homepage.goToLogin();
        yield loginPage.login(user.email, user.password);
        const accountPage = yield homepage.goToAccount();
        const userDetails = yield accountPage.getUserDetails();
        (0, test_1.expect)(userDetails.firstName).toBe(user.firstName);
        (0, test_1.expect)(userDetails.lastName).toBe(user.lastName);
        (0, test_1.expect)(userDetails.username).toBe(user.username);
        (0, test_1.expect)(userDetails.email).toBe(user.email);
    }));
});
