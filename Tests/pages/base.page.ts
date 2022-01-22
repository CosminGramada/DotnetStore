import {Page} from "@playwright/test";

export abstract class BasePage {
    protected readonly page: Page;
    protected readonly toastElementSelector = 'div.awn-toast-content';

    protected constructor(page: Page) {
        this.page = page;
    }
}
