import { prefix, debug, prefixBreadcrumbs } from '../shared/constants';

export function initBreadcrumb() {
  if (debug) console.log("init breadcrumbs");

  setBreadcrumbsStyling() 
  window.addEventListener("resize", setBreadcrumbsStyling);
  document.addEventListener('scroll', setBreadcrumbsStyling);

  var breadCrumbTrigger = document.querySelector(`.${prefixBreadcrumbs}-trigger`);
  if(breadCrumbTrigger != null) {
    breadCrumbTrigger.addEventListener('click', () => {
      console.log(document.querySelector(`.${prefixBreadcrumbs}`))
      document.querySelector(`.${prefixBreadcrumbs}`).classList.toggle(`${prefixBreadcrumbs}-open`)
    })
  }
}

function setBreadcrumbsStyling() {
  var header = document.getElementById(`${prefix}-page-navigation`);
  if(header != null) {
    var headerHeight = header.offsetHeight;

    var breadcrumbs = document.querySelector(`.${prefixBreadcrumbs}`) as HTMLElement;
    breadcrumbs.style.top = headerHeight + "px";
    var breadcrumbsOffsetTop = breadcrumbs.getBoundingClientRect().top;

    if (breadcrumbsOffsetTop <= headerHeight && scrollY != 0) {
      breadcrumbs.classList.add("bg-light", "shadow");
    } else {
      breadcrumbs.classList.remove("bg-light", "shadow");
    }
  }
}
