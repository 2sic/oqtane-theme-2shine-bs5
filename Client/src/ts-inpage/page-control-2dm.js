//Functions to set body classes
export function clearBodyClasses() {
    console.log("clearBodyClasses");
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
export function setBodyClass(bodyClass) {
    console.log("setBodyClass");
    var body = document.querySelector("body");
    body.className = bodyClass;
}
//# sourceMappingURL=page-control-2dm.js.map