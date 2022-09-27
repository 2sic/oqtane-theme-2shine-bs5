import { initToTop } from './to-top';

initToTop();

const prefix = "to-shine";



/* Open all PDF links in a new window */
document.querySelectorAll('a').forEach((linkElem: Element, index) => {
	if (linkElem.hasAttribute('href') && linkElem.getAttribute('href').endsWith('.pdf')) {
		linkElem.setAttribute('target', '_blank');
	}
});

/* mailencrypting */
setTimeout(function () {
	let mailElement = document.querySelectorAll('[data-madr1]:not(.madr-done)');

	mailElement.forEach((mail: HTMLElement, index) => {
		const maddr = mail.getAttribute('data-madr1') + '@' + mail.getAttribute('data-madr2') + '.' + mail.getAttribute('data-madr3');
		const linktext = mail.getAttribute('data-linktext') ? mail.getAttribute('data-linktext') : maddr;

		const a = document.createElement('a')
		a.setAttribute('href', `mailto:${maddr}`)
		a.innerHTML = linktext;

		if (mail.parentElement) mail.parentElement.appendChild(a);
		mail.classList.add('madr-done');
		mail.style.display = 'none';
	});
}, 500);

// -----------------------------
// Above is DNN below is Oqtane

const ToShineBody = document; //.querySelector("body");

const observer = new MutationObserver(mutations => {

    //ToShineToTopButton
    var toTopButton = document.getElementById(`${prefix}-to-top`);
    toTopButton.addEventListener("click", scrollTop);
    //ToShineToTopButton end

    //ToShineBreadcrumbTrigger
    var breadcrumbTrigger = document.querySelector(`.${prefix}-page-breadcrumb-trigger`);
    // TODO: something is missing here for the breadcrumb-trigger
    //ToShineBreadcrumbTrigger end
    
});

observer.observe(ToShineBody, {
    attributes: true
});

// to-top button
document.addEventListener("scroll", toTopButtonVisibility);
function toTopButtonVisibility() {
    var toTopButton = document.getElementById(`${prefix}-to-top`);
    if (document.body.scrollTop > 200 || document.documentElement.scrollTop > 200) {
        toTopButton.classList.add(`${prefix}-top-visible`);
    } else {
        toTopButton.classList.remove(`${prefix}-to-visible`);
    }
}

function scrollTop(){
    window.scrollTo({ top: 0, behavior: 'smooth' });
}


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
    
    var breadcrumbs = document.querySelector(`.${prefix}-page-breadcrumb`);

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

document.querySelector(`.${prefix}-page-breadcrumb-trigger`).addEventListener('click', () => {
    document.querySelector(`.${prefix}-page-breadcrumb`).classList.toggle(`${prefix}-page-breadcrumb-shortened`)
})

if (document.querySelector(`.${prefix}-page-breadcrumb`) != null) {
    //document.querySelector('.to-shine-page-breadcrumb span a:last-child').classList.add('last');
    //document.querySelector('.to-shine-page-breadcrumb span:last-child').classList.add('last');
    //if (document.querySelector('.to-shine-page-breadcrumb span .to-shine-page-breadcrumb-link:nth-last-child(3)') != null) {
    //    document.querySelector('.to-shine-page-breadcrumb span .to-shine-page-breadcrumb-link:nth-last-child(3)').classList.add('second-last');
    //}
    document
      .querySelector(`.${prefix}-page-breadcrumb`)
      .classList.toggle(`${prefix}-page-breadcrumb-shortened`, (document.querySelector(`.${prefix}-page-breadcrumb-link`) != null || document.querySelectorAll(`.${prefix}-page-breadcrumb-link`).length > 2))
}

//Offcanvas close on link click
var links = document.querySelectorAll(".mobile-navigation-link");
var myOffcanvas = document.getElementById('offcanvasNavbar')
var bsOffcanvas = new bootstrap.Offcanvas(myOffcanvas)
 
links.forEach(element => {
    element.addEventListener('click', () => {
        bsOffcanvas.hide();
    })
});