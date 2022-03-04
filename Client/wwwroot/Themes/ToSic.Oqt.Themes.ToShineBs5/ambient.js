/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 1);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */,
/* 1 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(2);


/***/ }),
/* 2 */
/***/ (function(module, exports) {

////import { hide, show, toggle } from 'slidetoggle';
////import "bootstrap";
////const slidetoggle = require('slidetoggle');
/////* Open all PDF links in a new window */
////document.querySelectorAll('a').forEach((linkElem: Element, index) => {
////	if (linkElem.hasAttribute('href') && linkElem.getAttribute('href').endsWith('.pdf')) {
////		linkElem.setAttribute('target', '_blank');
////	}
////});
/////* mailencrypting */
////setTimeout(function () {
////	let mailElement = document.querySelectorAll('[data-madr1]:not(.madr-done)');
////	mailElement.forEach((mail: HTMLElement, index) => {
////		const maddr = mail.getAttribute('data-madr1') + '@' + mail.getAttribute('data-madr2') + '.' + mail.getAttribute('data-madr3');
////		const linktext = mail.getAttribute('data-linktext') ? mail.getAttribute('data-linktext') : maddr;
////		const a = document.createElement('a')
////		a.setAttribute('href', `mailto:${maddr}`)
////		a.innerHTML = linktext;
////		if (mail.parentElement) mail.parentElement.appendChild(a);
////		mail.classList.add('madr-done');
////		mail.style.display = 'none';
////	});
////}, 500);
/////* Go to top button */
////if (document.querySelector('#to-shine-to-top')) {
////	document.querySelector('#to-shine-to-top').addEventListener('click', (e) => {
////		e.preventDefault();
////		window.scrollTo({
////			top: 0,
////			left: 0,
////			behavior: 'smooth'
////		});
////	})
////}
////const navheader = document.querySelector('header');
////const navheight = navheader.offsetHeight;
////window.addEventListener('scroll', function (event) {
////	const bc = document.querySelector('.to-shine-page-breadcrumb');
////	if (bc != null) {
////		(bc as HTMLElement).style.top = `${navheader.offsetHeight - 1}px`;
////		if (window.scrollY > navheight) {
////			bc.classList.add('bg-light', 'shadow');
////		} else {
////			bc.classList.remove('bg-light', 'shadow');
////		}
////	}
////	const toTop = document.querySelector("#to-shine-to-top");
////	if (toTop != null) {
////		/* show / hide scroll to top button */
////		if (window.scrollY > 200) {
////			toTop.classList.add('to-shine-top-visible');
////		} else {
////			toTop.classList.remove('to-shine-top-visible');
////		}
////	}
////}, false);
//// //breadcrumb
//// //opens sub navs and mobile navs
////document.querySelectorAll('.to-shine-navopener').forEach((openerElem: HTMLElement, index) => {
////	openerElem.addEventListener('click', (e) => {
////		const targetElem = e.currentTarget as HTMLElement;
////		const targetParent = targetElem.parentElement.parentElement;
////		if (!targetParent.classList.contains('to-shine-active')) {
////			if (targetElem.closest('.has-child').classList.contains('to-shine-active')) {
////				document.querySelector('.to-shine-active').classList.remove('to-shine-active')
////				hide(document.querySelector('.to-shine-active ul') as HTMLElement, {});
////			}
////			targetParent.classList.toggle('to-shine-active');
////			show(targetParent.querySelector('ul') as HTMLElement, {});
////		} else {
////			targetParent.classList.toggle('to-shine-active');
////			hide(targetParent.querySelector('ul') as HTMLElement, {});
////		}
////	})
////})
////const bc = document.querySelector('.to-shine-page-breadcrumb');
////if (bc != null) {
////	document.querySelector('.to-shine-page-breadcrumb span a:last-child').classList.add('last');
////	document.querySelector('.to-shine-page-breadcrumb span:last-child').classList.add('last');
////	if (document.querySelector('.to-shine-page-breadcrumb span .to-shine-page-breadcrumb-link:nth-last-child(3)') != null) {
////		document.querySelector('.to-shine-page-breadcrumb span .to-shine-page-breadcrumb-link:nth-last-child(3)').classList.add('second-last');
////	}
////	bc.classList.toggle('to-shine-page-breadcrumb-shortened', (document.querySelector('.to-shine-page-breadcrumb-link') != null || document.querySelectorAll('.to-shine-page-breadcrumb-link').length > 2))
////	document.querySelector('.to-shine-page-breadcrumb-trigger').addEventListener('click', () => {
////		bc.classList.toggle('to-shine-page-breadcrumb-shortened')
////	})
////}
// -----------------------------------------------------------------------------------------------------------------------------
//Before DNN copy rework
const ToShineBody = document.querySelector("body");
const observer = new MutationObserver(mutations => {
    //ToShineToTopButton
    var toTopButton = document.getElementById("to-shine-to-top");
    toTopButton.addEventListener("click", scrollTop);
    //ToShineToTopButton end
    //ToShineBreadcrumbTrigger
    var breadcrumbTrigger = document.querySelector(".to-shine-page-breadcrumb-trigger");
    breadcrumbTrigger.addEventListener("click", breadcrumbButtonDisplay);
    breadcrumbTrigger.addEventListener("click", breadcrumbButtonDisplay);
    //ToShineBreadcrumbTrigger end
});
observer.observe(ToShineBody, {
    attributes: true
});
//To-shine-to-top button
document.addEventListener("scroll", ToTopButton);
function ToTopButton() {
    var toTopButton = document.getElementById("to-shine-to-top");
    if (document.body.scrollTop > 1 || document.documentElement.scrollTop > 1) {
        toTopButton.style["opacity"] = "1";
    }
    else {
        toTopButton.style["opacity"] = "0";
    }
}
function scrollTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
}
/*Sticky breadcrumbs*/
window.addEventListener("resize", BreadcrumbsAttributes);
document.addEventListener('scroll', BreadcrumbsAttributes);
var counter = 0;
function BreadcrumbsAttributes() {
    var header = document.getElementById("to-shine-page-header");
    var headerHeight = header.offsetHeight - 1;
    /*Get header Pane height*/
    var headerPane = document.getElementById("to-shine-page-header-pane");
    var headerPaneStyle = getComputedStyle(headerPane);
    var headerPaneHeight = parseInt(headerPaneStyle.height);
    var headerPaneMarginBottom = parseInt(headerPaneStyle.marginTop);
    var headerPaneMarginTop = parseInt(headerPaneStyle.marginBottom);
    var totalHeight = headerPaneMarginBottom + headerPaneMarginTop + headerPaneHeight;
    var breadcrumbs = document.querySelector(".to-shine-page-breadcrumb");
    console.log(breadcrumbs);
    breadcrumbs.style["top"] = headerHeight + "px";
    if (counter == 0 && scrollY > totalHeight) {
        breadcrumbs.classList.add("bg-light", "shadow");
        counter = 1;
    }
    if (counter == 1 && scrollY <= totalHeight) {
        breadcrumbs.classList.remove("bg-light", "shadow");
        counter = 0;
    }
}
//Breadcrumb button
function breadcrumbButtonDisplay() {
    var bcHomeLink = document.querySelector(".to-shine-page-breadcrumb-home");
    bcHomeLink.style["display"] = "inline!important";
}


/***/ })
/******/ ]);
//# sourceMappingURL=ambient.js.map