import {expect, test} from '@playwright/test';
import {HomePage} from "../pages/home.page";
import {UserTestHelper} from "../test-helpers/user-helper";

test.describe('Register', () => {
    test.beforeEach(async ({page}) => {
        await page.goto('https://localhost:7177/');
    });

    test('user should be able to create a new account', async ({page}) => {
        const user = await UserTestHelper.registerUser(page);

        const homepage = new HomePage(page);

        const greetingText = (await homepage.getLoggedInUser()).join();
        expect(greetingText).toBe(`Hi, ${user.firstName}`);
    });
});
