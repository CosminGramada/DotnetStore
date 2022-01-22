import {expect, test} from '@playwright/test';
import {HomePage} from "../pages/home.page";
import {UserTestHelper} from "../test-helpers/user-helper";
import {AccountMenu} from "../enums/account-menu";
import {AccountAddressesPage} from "../pages/account/address.page";

test.describe('Address', () => {
    test.beforeEach(async ({page}) => {
        await page.goto('https://localhost:7177/');
    });

    test('new user should be able to see his default address information on the account page', async ({page}) => {
        const user = await UserTestHelper.registerUser(page);

        const homepage = new HomePage(page);
        let accountPage = await homepage.goToAccount();
        const addressesPage = await accountPage.openAccountMenuItem(AccountMenu.Addresses) as AccountAddressesPage;
        const address = await addressesPage.addNewAddress();
        
        const accountAddress = await addressesPage.getAllAddressesDetails();
        const addressExists = accountAddress.find(a => 
            a.firstName == address.firstName &&
            a.lastName == address.lastName &&
            a.address1 == address.address1 &&
            a.address2 == address.address2 &&
            a.zip == address.zip &&
            a.city == address.city &&
            a.country == address.country &&
            a.default == address.default
        );

        expect(addressExists).toBeTruthy();
    });
});
