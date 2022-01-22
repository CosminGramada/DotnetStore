import { Locator, Page } from '@playwright/test';
import {LoginPage} from "./login.page";
import {Header} from "./header.page";

export class HomePage extends Header{

    constructor(page: Page) {
        super(page);
    }

    static async delay(ms: number): Promise<void> {
        return new Promise(resolve => setTimeout(resolve, ms));
    }
}
