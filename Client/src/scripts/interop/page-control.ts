//Functions to set body classes

export function clearBodyClasses() {
    var body = document.querySelector("body");
    body.removeAttribute("class");
}

export function setBodyClass(bodyClass : string) {
    var body = document.querySelector("body");
    body.className = bodyClass;
}