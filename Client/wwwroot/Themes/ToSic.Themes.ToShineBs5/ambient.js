(()=>{"use strict";var e={565:(e,t,o)=>{const r=o(77),n=o(231),i=o(758),d=o(657);o(693),(0,d.initToTop)(),(0,i.openPdfInNewWindow)(),(0,r.initMailDecrypt)(),(0,n.initOffCanvasEvents)()},693:(e,t,o)=>{Object.defineProperty(t,"__esModule",{value:!0});const r=o(353),n=`.${r.prefixBreadcrumbs}`;r.debug&&console.log("init breadcrumbs - probably doesn't work!"),new MutationObserver((e=>{document.querySelector(`${n}-trigger`)})).observe(document,{attributes:!0}),window.addEventListener("resize",d),document.addEventListener("scroll",d);var i=0;function d(){var e=document.getElementById(`${r.prefix}-page-navigation`).offsetHeight-1,t=document.getElementById(`${r.prefix}-page-header-pane`),o=getComputedStyle(t),n=parseInt(o.height),d=parseInt(o.marginTop)+parseInt(o.marginBottom)+n,a=document.querySelector(`.${r.prefixBreadcrumbs}`);a.style.top=e+"px",0==i&&scrollY>d&&(a.classList.add("bg-light","shadow"),i=1),1==i&&scrollY<=d&&(a.classList.remove("bg-light","shadow"),i=0)}document.querySelector(`${n}-trigger`).addEventListener("click",(()=>{document.querySelector(`${n}`).classList.toggle(`${r.prefixBreadcrumbs}-shortened`)})),null!=document.querySelector(`.${r.prefixBreadcrumbs}`)&&document.querySelector(n).classList.toggle(`${r.prefixBreadcrumbs}-shortened`,null!=document.querySelector(`${n}-link`)||document.querySelectorAll(`${n}-link`).length>2)},77:(e,t,o)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.initMailDecrypt=void 0;const r=o(353);t.initMailDecrypt=function(){r.debug&&console.log("initMailDecrypt"),setTimeout((function(){document.querySelectorAll("[data-madr1]:not(.madr-done)").forEach(((e,t)=>{const o=e.getAttribute("data-madr1")+"@"+e.getAttribute("data-madr2")+"."+e.getAttribute("data-madr3"),r=e.getAttribute("data-linktext")?e.getAttribute("data-linktext"):o,n=document.createElement("a");n.setAttribute("href",`mailto:${o}`),n.innerHTML=r,e.parentElement&&e.parentElement.appendChild(n),e.classList.add("madr-done"),e.style.display="none"}))}),500)}},231:(e,t,o)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.initOffCanvasEvents=void 0,o(353),t.initOffCanvasEvents=function(){}},758:(e,t)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.openPdfInNewWindow=void 0,t.openPdfInNewWindow=function(){document.querySelectorAll("a").forEach(((e,t)=>{e.hasAttribute("href")&&e.getAttribute("href").endsWith(".pdf")&&e.setAttribute("target","_blank")}))}},657:(e,t,o)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.initToTop=void 0;const r=o(353),n=`${r.prefix}-to-top`,i="visible";function d(){var e=document.getElementById(n);if(!e)return;e.addEventListener("click",a);const t=document.body.scrollTop>200||document.documentElement.scrollTop>200;r.debugDetailed&&console.log("show"),t?e.classList.add(i):e.classList.remove(i)}function a(){window.scrollTo({top:0,behavior:"smooth"})}t.initToTop=function(){console.log("init to top"),r.debug&&console.log("toTopShowHideOnScroll"),document.addEventListener("scroll",d)}},353:(e,t)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.prefixLanguages=t.prefixBreadcrumbs=t.prefix=t.debugDetailed=t.debug=void 0,t.debug=!0,t.debugDetailed=t.debug&&!1,t.prefix="theme",t.prefixBreadcrumbs=`${t.prefix}-breadcrumbs`,t.prefixLanguages=`${t.prefix}-languages`}},t={};function o(r){var n=t[r];if(void 0!==n)return n.exports;var i=t[r]={exports:{}};return e[r](i,i.exports,o),i.exports}o(565),o(693),o(77),o(231),o(758),o(657)})();
//# sourceMappingURL=ambient.js.map