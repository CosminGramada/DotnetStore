import {ProductColor, ProductSize} from "../enums/product";

export interface ProductVariant {
    color: ProductColor;
    size: ProductSize;
    quantity: number;
}
