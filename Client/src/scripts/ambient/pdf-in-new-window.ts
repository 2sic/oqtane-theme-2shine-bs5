
// TODO: THIS PROBABLY doesn't work reliably, as it would need to be called again when the page changes
// will probably need to be moved to the interop and called on every reload
// or use a timeout similar to mail-decrypt

/* Open all PDF links in a new window */
export function openPdfInNewWindow() {
  document.querySelectorAll('a').forEach((linkElem: Element, index) => {
    if (linkElem.hasAttribute('href') && linkElem.getAttribute('href').endsWith('.pdf')) {
      linkElem.setAttribute('target', '_blank');
    }
  });
}