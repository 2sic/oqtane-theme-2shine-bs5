import { debug } from '../shared/constants';

declare const bootstrap: any;

// Takes care of closing the offcanvas when clicking on a navigation link
// The page is not reloaded, so the offcanvas does not close
export function initOffCanvasEvents() {  

  if (debug) console.log('initOffCanvasEvents');

  //Offcanvas close on link click
  var navLinks = document.querySelectorAll(".mobile-navigation-link");
  var navOffcanvas = document.getElementById('offcanvasNavbar')
  var bsNavOffcanvas = new bootstrap.Offcanvas(navOffcanvas)
  
  navLinks.forEach(element => {
    element.addEventListener('click', () => {
      bsNavOffcanvas.hide();
    })
  });

}
