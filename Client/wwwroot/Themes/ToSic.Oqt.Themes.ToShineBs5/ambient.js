!function(e){var t={};function n(o){if(t[o])return t[o].exports;var r=t[o]={i:o,l:!1,exports:{}};return e[o].call(r.exports,r,r.exports,n),r.l=!0,r.exports}n.m=e,n.c=t,n.d=function(e,t,o){n.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:o})},n.r=function(e){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},n.t=function(e,t){if(1&t&&(e=n(e)),8&t)return e;if(4&t&&"object"==typeof e&&e&&e.__esModule)return e;var o=Object.create(null);if(n.r(o),Object.defineProperty(o,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var r in e)n.d(o,r,function(t){return e[t]}.bind(null,r));return o},n.n=function(e){var t=e&&e.__esModule?function(){return e.default}:function(){return e};return n.d(t,"a",t),t},n.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},n.p="",n(n.s=1)}([,function(e,t,n){e.exports=n(2)},function(e,t){const n=document.querySelector("body");function o(){window.scrollTo({top:0,behavior:"smooth"})}new MutationObserver(e=>{document.getElementById("to-shine-to-top").addEventListener("click",o);var t=document.querySelector(".to-shine-page-breadcrumb-trigger");t.addEventListener("click",c),t.addEventListener("click",c)}).observe(n,{attributes:!0}),document.addEventListener("scroll",(function(){var e=document.getElementById("to-shine-to-top");document.body.scrollTop>1||document.documentElement.scrollTop>1?e.style.opacity="1":e.style.opacity="0"})),window.addEventListener("resize",i),document.addEventListener("scroll",i);var r=0;function i(){var e=document.getElementById("to-shine-page-header").offsetHeight-1,t=document.getElementById("to-shine-page-header-pane"),n=getComputedStyle(t),o=parseInt(n.height),i=parseInt(n.marginTop)+parseInt(n.marginBottom)+o,c=document.querySelector(".to-shine-page-breadcrumb");console.log(c),c.style.top=e+"px",0==r&&scrollY>i&&(c.classList.add("bg-light","shadow"),r=1),1==r&&scrollY<=i&&(c.classList.remove("bg-light","shadow"),r=0)}function c(){document.querySelector(".to-shine-page-breadcrumb-home").style.display="inline!important"}}]);
//# sourceMappingURL=ambient.js.map