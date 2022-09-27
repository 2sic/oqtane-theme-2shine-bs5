import { debug, prefix } from './../shared/constants';
import { initMailDecrypt } from './mail-encrypt';
import { initOffCanvasEvents } from './menu';
import { openPdfInNewWindow } from './pdf-in-new-window';
import { initToTop } from './to-top';


import './breadcrumbs';

initToTop();

openPdfInNewWindow();

initMailDecrypt();




initOffCanvasEvents();