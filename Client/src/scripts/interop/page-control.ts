/**
 * Function to clear the <body> tag of all classes
 */
export function clearBodyClasses() {
  var body = document.querySelector("body");
  // console.log('body classes before', body.className);
  body.removeAttribute("class");
}

/**
 * Function to set the body class
 * @param bodyClass Classes to add to the body
 */
export function setBodyClass(bodyClass: string, clearFirst: boolean) {
  if (clearFirst) clearBodyClasses();
  var body = document.body; //.querySelector("body");
  body.className = bodyClass;
}
