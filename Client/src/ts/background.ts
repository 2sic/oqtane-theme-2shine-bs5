//To-shine-to-top button 

document.addEventListener("scroll", ToTopButton);
function ToTopButton() {
    var toTopButton = document.getElementById("to-shine-to-top");
    toTopButton.addEventListener("click", scrollTop);
    if (document.body.scrollTop > 100 || document.documentElement.scrollTop > 100) {
        toTopButton.style["opacity"] = "1";
    } else {
        toTopButton.style["opacity"] = "0";
    }
}

function scrollTop(){
    window.scrollTo({ top: 0, behavior: 'smooth' });
}

//Sticky breadcrumbs
window.addEventListener("resize", BreadcrumbsAttributes);
document.addEventListener('scroll', BreadcrumbsAttributes);
var counter = 0;

function BreadcrumbsAttributes() {
    var header = document.getElementById("to-shine-page-header");
    var headerHeight = header.offsetHeight;

    //Get header Pane height
    var headerPane = document.getElementById("to-shine-page-headerpane");
    
    var headerPaneStyle = getComputedStyle(headerPane);
    var headerPaneHeight = parseInt(headerPaneStyle.height);
    var headerPaneMarginBottom = parseInt(headerPaneStyle.marginTop);
    var headerPaneMarginTop = parseInt(headerPaneStyle.marginBottom);
    var totalHeight = headerPaneMarginBottom + headerPaneMarginTop + headerPaneHeight;

    var breadcrumbs = document.getElementById("breadcrumbs");
    breadcrumbs.style["top"] = headerHeight + "px";
    
    if (counter == 0 && scrollY > totalHeight) {
        breadcrumbs.classList.add("shadow");
        breadcrumbs.classList.add("bg-light");
        counter = 1;
    }

    if (counter == 1 && scrollY <= totalHeight) {
        breadcrumbs.classList.remove("shadow");
        breadcrumbs.classList.remove("bg-light");
        counter = 0;
    }
}