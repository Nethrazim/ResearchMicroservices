"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.ChangePasswordResponse = void 0;
var EntityResponse_1 = require("../../EntityResponse");
var ChangePasswordResponse = /** @class */ (function (_super) {
    __extends(ChangePasswordResponse, _super);
    function ChangePasswordResponse() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return ChangePasswordResponse;
}(EntityResponse_1.EntityResponse));
exports.ChangePasswordResponse = ChangePasswordResponse;
//# sourceMappingURL=ChangePasswordResponse.js.map