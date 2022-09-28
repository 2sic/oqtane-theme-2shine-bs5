import { debug, debugDetailed, prefix } from '../shared/constants';

const toTopElementId = `${prefix}-to-top`;
const visibleClass = `visible`;

export function initToTop() {
  console.log('init to top');
  toTopShowHideOnScroll();
}

function toTopShowHideOnScroll() {
  if (debug) console.log('toTopShowHideOnScroll');
  document.addEventListener("scroll", toTopButtonVisibility);
}




function toTopButtonVisibility() {
  var toTopButton = document.getElementById(toTopElementId);
  if (!toTopButton) return;

  // Ensure it has the event listener
  toTopButton.addEventListener("click", scrollTop);

  // Todo: unsure why it does body + documentElement...
  const show = document.body.scrollTop > 200 || document.documentElement.scrollTop > 200;
  if (debugDetailed) console.log('to-top' + show ? "show" : "hide");
  if (show) 
    toTopButton.classList.add(visibleClass);
  else
    toTopButton.classList.remove(visibleClass);
}

function scrollTop() {
  window.scrollTo({ top: 0, behavior: 'smooth' });
}