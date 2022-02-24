//Functions to set body classes

export function clearBodyClasses() {
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
    var body = document.querySelector("body");
    body.className = bodyClass;
}