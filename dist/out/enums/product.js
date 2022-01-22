"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ProductSize = exports.ProductColor = exports.ProductCategory = void 0;
var ProductCategory;
(function (ProductCategory) {
    ProductCategory[ProductCategory["Women"] = 0] = "Women";
    ProductCategory[ProductCategory["Men"] = 1] = "Men";
    ProductCategory[ProductCategory["Unisex"] = 2] = "Unisex";
})(ProductCategory = exports.ProductCategory || (exports.ProductCategory = {}));
var ProductColor;
(function (ProductColor) {
    ProductColor["Blue"] = "Blue";
    ProductColor["Black"] = "Black";
    ProductColor["Red"] = "Red";
    ProductColor["Green"] = "Green";
    ProductColor["Yellow"] = "Yellow";
})(ProductColor = exports.ProductColor || (exports.ProductColor = {}));
var ProductSize;
(function (ProductSize) {
    ProductSize["Small"] = "Small";
    ProductSize["Medium"] = "Medium";
    ProductSize["Large"] = "Large";
    ProductSize["ExtraLarge"] = "Extra Large";
})(ProductSize = exports.ProductSize || (exports.ProductSize = {}));
