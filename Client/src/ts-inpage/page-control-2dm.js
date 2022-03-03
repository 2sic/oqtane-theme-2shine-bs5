//Functions to set body classes
(function (factory) {
    if (typeof module === "object" && typeof module.exports === "object") {
        var v = factory(require, exports);
        if (v !== undefined) module.exports = v;
    }
    else if (typeof define === "function" && define.amd) {
        define(["require", "exports"], factory);
    }
})(function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    exports.setBodyClass = exports.clearBodyClasses = void 0;
    function clearBodyClasses() {
        var body = document.querySelector("body");
        body.removeAttribute("class");
        //var offcanvas = document.getElementById("toggleMobileMenu");
        //var offcanvasStyle = getComputedStyle(offcanvas);
        //var bodyStyle = getComputedStyle(body);
        //if (offcanvasStyle.visibility == "hidden") {
        //    body.style["padding"] = "0";
        //    body.style["overflow"] = "visible";
        //}
    }
    exports.clearBodyClasses = clearBodyClasses;
    function setBodyClass(bodyClass) {
        var body = document.querySelector("body");
        body.className = bodyClass;
    }
    exports.setBodyClass = setBodyClass;
});
//# sourceMappingURL=page-control-2dm.js.map