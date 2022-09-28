import { prefix, debug, prefixBreadcrumbs } from '../shared/constants';

/* 
  IMPORTANT: this probably doesn't really work

  I just copied the stuff here from Daias code, but I think it's completely non-functional

  TODO: @2ro 
  - pls fix ;)
  - make sure it's in an export function and called from the background.ts
*/

//const prefixBreadcrumbs = `${prefix}-page-breadcrumb`;
const baseSelector = `.${prefixBreadcrumbs}`;



if (debug) console.log("init breadcrumbs - probably doesn't work!");

// -----------------------------
// Above is DNN below is Oqtane

const observer = new MutationObserver(mutations => {
  //ToShineBreadcrumbTrigger
  var breadcrumbTrigger = document.querySelector(`${baseSelector}-trigger`);
  // TODO: something is missing here for the breadcrumb-trigger
  //ToShineBreadcrumbTrigger end
  
});

observer.observe(document, {
  attributes: true
});




/*Sticky breadcrumbs*/
window.addEventListener("resize", breadcrumbsAttributes);
document.addEventListener('scroll', breadcrumbsAttributes);
var counter = 0;

function breadcrumbsAttributes() {
  var header = document.getElementById(`${prefix}-page-navigation`);
  var headerHeight = header.offsetHeight -1;

/*Get header Pane height*/
  var headerPane = document.getElementById(`${prefix}-page-header-pane`);

  var headerPaneStyle = getComputedStyle(headerPane);
  var headerPaneHeight = parseInt(headerPaneStyle.height);
  var headerPaneMarginBottom = parseInt(headerPaneStyle.marginTop);
  var headerPaneMarginTop = parseInt(headerPaneStyle.marginBottom);
  var totalHeight = headerPaneMarginBottom + headerPaneMarginTop + headerPaneHeight;
  
  var breadcrumbs = document.querySelector(`.${prefixBreadcrumbs}`);

  (breadcrumbs as HTMLElement).style["top"] = headerHeight + "px";
  
  if (counter == 0 && scrollY > totalHeight) {
      breadcrumbs.classList.add("bg-light", "shadow");
      counter = 1;
  }

  if (counter == 1 && scrollY <= totalHeight) {
      breadcrumbs.classList.remove("bg-light", "shadow");
      counter = 0;
  }
}

document.querySelector(`${baseSelector}-trigger`).addEventListener('click', () => {
  document.querySelector(`${baseSelector}`).classList.toggle(`${prefixBreadcrumbs}-shortened`)
})

if (document.querySelector(`.${prefixBreadcrumbs}`) != null) {
  //document.querySelector('.to-shine-page-breadcrumb span a:last-child').classList.add('last');
  //document.querySelector('.to-shine-page-breadcrumb span:last-child').classList.add('last');
  //if (document.querySelector('.to-shine-page-breadcrumb span .to-shine-page-breadcrumb-link:nth-last-child(3)') != null) {
  //    document.querySelector('.to-shine-page-breadcrumb span .to-shine-page-breadcrumb-link:nth-last-child(3)').classList.add('second-last');
  //}
  document
    .querySelector(baseSelector)
    .classList.toggle(`${prefixBreadcrumbs}-shortened`, (document.querySelector(`${baseSelector}-link`) != null || document.querySelectorAll(`${baseSelector}-link`).length > 2))
}
