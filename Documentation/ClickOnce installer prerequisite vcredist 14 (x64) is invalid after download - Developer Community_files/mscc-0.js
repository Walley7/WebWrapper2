var mscc;!function(e){function t(e){for(var t=[],n=1;n<arguments.length;n++)t[n-1]=arguments[n];S[e]&&S[e].forEach(function(e){e.apply(null,t)})}function n(e,t){S[e]?S[e].push(t):S[e]=[t]}function o(e){if(e)for(var t=0,n=x.getCookie().split("; ");t<n.length;t++){var o=n[t],i=o.indexOf("="),a=o.substring(0,i);if(a===e)return o.substring(a.length+1)}return null}function i(e,t,n){var i=new Date;i.setDate(i.getDate()+n);var a=_.getHostname().split("."),r=a.pop(),s=e+"="+t+";path=/";if(N()&&(s+=";samesite=none;secure"),"localhost"==r)0===n?x.setCookie(s):x.setCookie(s+";expires="+i.toUTCString());else for(;o(e)!==t&&0!==a.length;)r=a.pop()+"."+r,0===n?x.setCookie(s+";domain=."+r):x.setCookie(s+";domain=."+r+";expires="+i.toUTCString())}function a(e,t){return e.classList?e.classList.contains(t):new RegExp("(^| )"+t+"( |$)","gi").test(e.className)}function r(e,t){e.classList?e.classList.add(t):e.className+=" "+t}function s(e,t){e.classList?e.classList.remove(t):e.className=e.className.replace(new RegExp("(^|\\b)"+t.split(" ").join("|")+"(\\b|$)","gi")," ")}function c(e,t){e.hasAttribute(t)&&e.removeAttribute(t)}function u(e){return 13===e.which||13===e.keyCode}function d(){return void 0!=I&&a(I,B)}function m(e,t,n){if(!e&&!t)return!1;var o=e&&e.target||t;return(!o||0!==b(o))&&(o&&"A"===o.tagName?o!==M:m(null,o.parentElement,n))}function l(e,t,n){e.addEventListener?e.addEventListener(t,n):e.attachEvent("on"+t,function(){n.call(e)})}function f(e){if(H&&!K){var t=new Image,n=I.getAttribute("data-site-name"),o=I.getAttribute("data-nver"),i=I.getAttribute("data-sver"),a=n?"&s="+n:"",r=o?"&nv="+o:"",s=i?"&sv="+i:"",c=e?"&m="+e:"";t.src=L+"?o=mscc"+a+c+r+s,K=!0}}function g(){c(I,T),r(I,B),t("show"),f("show")}function v(){s(I,B),t("hide")}function p(e){return Math.floor(e/1e3)}function h(n){void 0===n&&(n=!1);var o=e.hasConsent();I&&v(),o||(i(e.cookieName,""+p(Date.now()),n?0:390),t("consent"))}function C(){var t={hasConsent:e.hasConsent(),consentDate:null};return t.hasConsent?(t.consentDate=new Date(1e3*+o(e.cookieName)),t):t}function k(){return!!o(e.cookieName)}function b(e){if(e&&e.getAttribute){var t=e.getAttribute(O);if("false"===t)return 0;if("true"===t)return 1}return-1}function w(t){var n=b(t.target),o=t.button;e.interactiveConsentEnabled&&0!==n&&(u(t)||0===o||1===o)&&(1===n||m(t,null,_.getHostname()))&&h()}function E(){I=document.getElementById("msccBanner"),M=document.getElementById("msccLearnMore");var t=k();!I||t||d()||g(),I&&t&&d()&&v(),t||(l(document.body,"mouseup",w),l(document.body,"keyup",w),l(document.body,"submit",h));var n=o(e.cookieName);n&&parseInt(n)<D&&l(window,"beforeunload",function(){i(e.cookieName,"0",-1)})}function N(){if(!/https/i.test(_.getProtocol()))return!1;var e=U.getUserAgent();if(/\(iP.+; CPU .*OS 12[_\d]*.*\) AppleWebKit\//.test(e))return!1;if(/\(Macintosh;.*Mac OS X 10_14[_\d]*.*\) AppleWebKit\//.test(e))return!(/Version\/.* Safari\//.test(e)&&!/Chrom(e|ium)/.test(e))&&!/^Mozilla\/[\.\d]+ \(Macintosh;.*Mac OS X [_\d]+\) AppleWebKit\/[\.\d]+ \(KHTML, like Gecko\)$/.test(e);if(/UCBrowser\/(\d+)\.(\d+)\.(\d+)[\.\d]* /.test(e)){var t=/UCBrowser\/(\d+)\.(\d+)\.(\d+)[\.\d]* /.exec(e);return!(1e4*(1e4*parseInt(t[1])+parseInt(t[2]))+parseInt(t[3])<1200130002)}if(/Chrom(e|ium)[^ \/]*\/(\d+)[\.\d]* /.test(e)){var t=/Chrom(e|ium)[^ \/]*\/(\d+)[\.\d]* /.exec(e);return!(parseInt(t[2])>=51&&parseInt(t[2])<=66)}return!0}function y(){var t=o(e.cookieName);t&&parseInt(t)<0&&(x.setCookie(e.cookieName+"=0;expires="+new Date(0).toUTCString()+";path=/;"),i(e.cookieName,"0",-1))}function A(t,n,i){t&&(_=t),n&&(x=n),i&&(U=i);o(e.cookieName);y(),null!=document.getElementById("msccBanner")||"complete"===document.readyState?E():document.addEventListener?document.addEventListener("DOMContentLoaded",E):document.attachEvent("onreadystatechange",function(){"complete"===document.readyState&&(E(),document.detachEvent("onreadystatechange",arguments.callee))})}e.cookieName="MSCC",e.version="0.4.2";var L="https://uhf.microsoft.com/_log",D=p(new Date("Sun, 01 Jan 2016 08:00:00 GMT").getTime());e.interactiveConsentEnabled=!0;var I,M,S={},_={getHostname:function(){return window.location.hostname},getProtocol:function(){return window.location.protocol}},x={getCookie:function(){return document.cookie},setCookie:function(e){document.cookie=e}},U={getUserAgent:function(){return navigator.userAgent}},B="active",O="data-mscc-ic",T="style",H=!0,K=!1;e._emit=t,e.on=n,e._getCookie=o,e._setCookieOnRootDomain=i,e.isVisible=d,e.setConsent=h,e.getConsentData=C,e.hasConsent=k,e._clearNegativeCookie=y,e._init=A,A()}(mscc||(mscc={}));