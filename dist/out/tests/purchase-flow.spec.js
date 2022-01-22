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
const product_details_page_1 = require("../pages/product-details.page");
const checkout_1 = require("../enums/checkout");
const account_menu_1 = require("../enums/account-menu");
test_1.test.describe('Purchase', () => {
    (0, test_1.test)('new user should be able to place an order for multiple products', ({ page }) => __awaiter(void 0, void 0, void 0, function* () {
        yield page.goto('https://localhost:7177/');
        const user = yield user_helper_1.UserTestHelper.registerUser(page);
        const homepage = new home_page_1.HomePage(page);
        let accountPage = yield homepage.goToAccount();
        const addressesPage = yield accountPage.openAccountMenuItem(account_menu_1.AccountMenu.Addresses);
        const address = yield addressesPage.addNewAddress();
        const accountAddress = yield accountPage.getAddressDetails();
        const allProductsPage = yield accountPage.header().goToAllProducts();
        const allProducts = yield allProductsPage.getAllProducts();
        const product = allProducts.find(p => !p.isSoldOut);
        yield product.element.click();
        let productDetailsPage = new product_details_page_1.ProductDetailsPage(page);
        productDetailsPage = yield productDetailsPage.addProductToCart();
        const cartPage = yield productDetailsPage.header().goToCartPage();
        const checkoutShippingPage = yield cartPage.goToCheckout();
        const checkoutPaymentPage = yield checkoutShippingPage.goToPayment(checkout_1.ShippingMethod.Standard);
        yield checkoutPaymentPage.payAndSubmitOrder();
    }));
});
