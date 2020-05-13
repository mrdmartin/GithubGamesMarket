'use strict';

var initPage_onDomContentLoaded = function () {

    var pageName = document.querySelector("html").getAttribute("data-page");


    if (pageName !== 'cookie-usage') {
        var cookiesWarning = document.querySelector("[data-widget='cookies-warning']");
        var btnAcceptCookies = cookiesWarning.querySelector("[data-widget='cookiesAceptar']");
        var btnRefuseCookie = cookiesWarning.querySelector("[data-widget='cookiesDenegar']");

        var initCookie = function () {

            if (Cookies.get('COOKIES_USAGE')) {
                cookiesWarning.style.display = "none";
            } else {
                cookiesWarning.style.display = "block";
            }
        }
        initCookie();

        var acceptCookie = function () {

            Cookies.set('COOKIES_USAGE', 1, { expires: 365 });
            cookiesWarning.style.display = "none";
        }
        btnAcceptCookies.addEventListener("click", acceptCookie);

        var refuseCookie = function () {

            Cookies.set('COOKIES_USAGE', 0, { expires: 365 });

        }
        btnRefuseCookie.addEventListener("click", refuseCookie);
    }

    if (pageName === 'Game') {

        var formPost = document.getElementById('formPost');

        var checkLog = function (event) {
            console.log(document.getElementById('userLogged'));
            if (document.getElementById('userLogged') === null) {
                event.preventDefault();
                alert('Debes iniciar sesión');
                return true;
            }
        }
        formPost.addEventListener("submit", checkLog);

    }
}
window.addEventListener('DOMContentLoaded', initPage_onDomContentLoaded);