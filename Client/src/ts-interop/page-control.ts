import * as _ from "lodash";

export function setBodyClass(bodyClass: string): void {
    let body = document.querySelector("body");
    body.className = bodyClass;
}

export function clearBodyClasses(): void  {
    console.log("lodash2: " + _.now());

    let body = document.querySelector("body");
    body.removeAttribute("class");

    //var offcanvas = document.getElementById("toggleMobileMenu");

    //var offcanvasStyle = getComputedStyle(offcanvas);
    //var bodyStyle = getComputedStyle(body);

    //if (offcanvasStyle.visibility == "hidden") {
    //    body.style["padding"] = "0";
    //    body.style["overflow"] = "visible";
    //}
}