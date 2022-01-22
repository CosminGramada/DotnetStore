import {ProductVariant} from "./product-variant";
import {ProductCategory} from "../enums/product";
import {ElementHandle} from "playwright";

export interface Product {
    name: string;
    description?: string;
    category: ProductCategory;
    variants: ProductVariant[];
    price: number;
    discount?: string;
    imageName?: string;
}

export interface ProductInformation {
    element: ElementHandle;
    name: string;
    price: number;
    discountedPrice?: number;
    imageName: string;
    isOnSale?: boolean;
    isSoldOut?: boolean;
}
