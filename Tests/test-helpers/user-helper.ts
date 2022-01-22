import {HomePage} from "../pages/home.page";
import {internet, name} from "faker";
import {User} from "../interfaces/user";
import {LoginPage} from "../pages/login.page";
import {ProductsPage} from "../pages/products.page";
import {Page} from "@playwright/test";

export class UserTestHelper {
    static async registerUser(page) {
        const homepage = new HomePage(page);
        const registerPage = await homepage.goToRegister();

        const firstName = name.firstName();
        const lastName = name.lastName();

        const user: User = {
            email: internet.email(firstName, lastName),
            firstName: firstName,
            lastName: lastName,
            username: internet.userName(firstName, lastName),
            password: 'Test123!',
            confirmPassword: 'Test123!'
        };
        await registerPage.register(user);
        
        const loginPage = await homepage.goToLogin();
        await loginPage.login(user.email, user.password);

        return user;
    }

    static async loginWithAdminUser(page: Page) {
        const homepage = new HomePage(page);
        const loginPage = await homepage.goToLogin();
        await loginPage.login('admin@dotnetstore.com', 'Test123!');
        return new HomePage(page);
    }
}
