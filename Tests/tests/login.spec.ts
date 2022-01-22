import {test, expect} from '@playwright/test';
import {HomePage} from "../pages/home.page";
import {LoginPage} from "../pages/login.page";

test.describe('Login', () => {
    let homepage: HomePage;
    let loginPage: LoginPage;

    test.beforeEach(async({page}) => {
        await page.goto('https://localhost:7177/');
        homepage = new HomePage(page);
        loginPage = await homepage.goToLogin();
    });

    test('regular user should be able to login successfully', async ({page}) => {
        await loginPage.login('Bernadette.Champlin@hotmail.com', 'Test123!');

        const greetingText = (await homepage.getLoggedInUser()).join();
        expect(greetingText).toBe('Hi, Bernadette');
    });

    test('user should get an error message for invalid credentials', async ({page}) => {
        await loginPage.login('Bernadette.Champlin@hotmail.com', 'test123456');

        const errorMessage = await loginPage.getErrorMessage();
        expect(errorMessage).toBe('Invalid login attempt.');
    });

    test('admin user should be able to login successfully and land on Products page', async ({page}) => {
        await loginPage.login('admin@dotnetstore.com', 'Test123!');

        const greetingText = (await homepage.getLoggedInUser()).join();
        expect(greetingText).toBe('Hi, Administrator');
    });
});
