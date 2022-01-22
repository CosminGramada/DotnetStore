"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.BasePage = void 0;
class BasePage {
    constructor(page) {
        this.toastElementSelector = 'div.awn-toast-content';
        this.page = page;
    }
}
exports.BasePage = BasePage;
