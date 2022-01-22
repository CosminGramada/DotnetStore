import {test} from '@playwright/test';
import {HomePage} from "../pages/home.page";
import {UserTestHelper} from "../test-helpers/user-helper";
import {ProductDetailsPage} from "../pages/product-details.page";
import {ShippingMethod} from "../enums/checkout";
import {AccountMenu} from "../enums/account-menu";
import {AccountAddressesPage} from "../pages/account/address.page";

test.describe('Purchase', () => {

    test('new user should be able to place an order for multiple products', async ({page}) => {
        await page.goto('https://localhost:7177/');
        const user = await UserTestHelper.registerUser(page);

        const homepage = new HomePage(page);
        let accountPage = await homepage.goToAccount();
        const addressesPage = await accountPage.openAccountMenuItem(AccountMenu.Addresses) as AccountAddressesPage;
        const address = await addressesPage.addNewAddress();

        const allProductsPage = await accountPage.header().goToAllProducts();
        const allProducts = await allProductsPage.getAllProducts();

        const product = allProducts.find(p => !p.isSoldOut);
        await product.element.click();
        let productDetailsPage = new ProductDetailsPage(page);
        productDetailsPage = await productDetailsPage.addProductToCart();

        const cartPage = await productDetailsPage.header().goToCartPage();
        const checkoutInformationPage = await cartPage.goToCheckout();
        const checkoutShippingPage = await checkoutInformationPage.goToShipping();
        const checkoutPaymentPage = await checkoutShippingPage.goToPayment(ShippingMethod.Standard);

        await checkoutPaymentPage.payAndSubmitOrder();
    });
});
