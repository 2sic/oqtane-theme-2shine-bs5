import { debug } from '../shared/constants';

declare const bootstrap: any;

// TODO: I (2dm) turned this off, as it appears to be completely not needed
// @2ro pls verify
export function initOffCanvasEvents() {

  return;

  if (debug) console.log('initOffCanvasEvents');

  //Offcanvas close on link click
  var links = document.querySelectorAll(".mobile-navigation-link");
  var myOffcanvas = document.getElementById('offcanvasNavbar')
  var bsOffcanvas = new bootstrap.Offcanvas(myOffcanvas)
  
  links.forEach(element => {
      element.addEventListener('click', () => {
          bsOffcanvas.hide();
      })
  });

}
