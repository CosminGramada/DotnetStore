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
exports.UserTestHelper = void 0;
const home_page_1 = require("../pages/home.page");
const faker_1 = require("faker");
class UserTestHelper {
    static registerUser(page) {
        return __awaiter(this, void 0, void 0, function* () {
            const homepage = new home_page_1.HomePage(page);
            const registerPage = yield homepage.goToRegister();
            const firstName = faker_1.name.firstName();
            const lastName = faker_1.name.lastName();
            const user = {
                email: faker_1.internet.email(firstName, lastName),
                firstName: firstName,
                lastName: lastName,
                username: faker_1.internet.userName(firstName, lastName),
                password: 'Test123!',
                confirmPassword: 'Test123!'
            };
            yield registerPage.register(user);
            const loginPage = yield homepage.goToLogin();
            yield loginPage.login(user.email, user.password);
            return user;
        });
    }
    static loginWithAdminUser(page) {
        return __awaiter(this, void 0, void 0, function* () {
            const homepage = new home_page_1.HomePage(page);
            const loginPage = yield homepage.goToLogin();
            yield loginPage.login('admin@dotnetstore.com', 'Test123!');
            return new home_page_1.HomePage(page);
        });
    }
}
exports.UserTestHelper = UserTestHelper;
