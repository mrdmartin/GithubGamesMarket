'use strict';

var initPage_onDomContentLoaded = function () {

    var pageName = document.querySelector("html").getAttribute("data-page");
    var cookiesWarning = document.querySelector("[data-widget='cookies-warning']");
    var btnAcceptCookies = cookiesWarning.querySelector("[data-widget='cookiesAceptar']");
    var btnRefuseCookie = cookiesWarning.querySelector("[data-widget='cookiesDenegar']");

    var checkLog = function (event) {
        if (document.getElementById('userLogged') === null) {
            event.preventDefault();
            alert('Debes iniciar sesi�n');
            return true;
        }
    }

    if (pageName === "Cookies") {
        cookiesWarning.style.display = "none";
    }

    if (pageName != "Cookies") {

        var initCookie = function () {

            if (Cookies.get('COOKIES_USAGE')=="1") {
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
        var formBuy = document.getElementById('formBuy');

        formPost.addEventListener("submit", checkLog);
        //formBuy.addEventListener("submit", checkLog);

    }
    if (pageName === 'Buy') {

        var formBuying = document.getElementById('formBuying');

        //formBuying.addEventListener("submit", checkLog);

    }
    if (pageName === 'List') {

        var formFilter = document.getElementById("formFilter");
        var inputName = document.getElementById("inputName");
        var selectGender = document.getElementById("selectGender");
        var selectPlatform = document.getElementById("selectPlatform");

        var AJAX = function (event) {
            event.preventDefault();
            var nameValue = inputName.value;
            var genderValue = selectGender.value;
            var platformValue = selectPlatform.value;

            var url = '/ApiSearch/Index';
            fetch(url, {
                method: 'POST',
                body: JSON.stringify({ name: nameValue, gender: genderValue, platform: platformValue })
            })

                .then(function (response) {
                    return response.json();
                })

                .then(function (myJson) {
                    updatelist(myJson.games);
                })
        }
        formFilter.addEventListener("submit", AJAX);

        var updatelist = function (games) {
            var games_list = document.getElementById("games_list");
            games_list.innerHTML = "";
            for (var i = 0; i < games.length; i++) {
                addGame(games[i]);
            }
        }

        var addGame = function (game) {
            var game_template = document.querySelector('[data-hook="game_template"]')
            var item = document.importNode(game_template.content, true);

            var precio = String(game.precio);
            precio.replace('.', ',');

            item.querySelector('[data-hook="img_link"]').href = "Game/" + game.id_juego;
            item.querySelector('[data-hook="img_game"]').src = "/Client/shared/img/gamescover/" + game.img_ruta;
            item.querySelector('[data-hook="img_platform"]').src = "/Client/shared/img/logos/" + game.img_rutaPlataforma;
            item.querySelector('[data-hook="name_link"]').href = "Game/" + game.id_juego;
            item.querySelector('[data-hook="name_game"]').textContent = game.nombre;
            item.querySelector('[data-hook="name_distributor"]').textContent = game.distribuidora;
            item.querySelector('[data-hook="release_date"]').textContent = game.fecha_lanzamiento_string;
            item.querySelector('[data-hook="name_distributor"]').textContent = game.distribuidora;
            item.querySelector('[data-hook="price"]').textContent = precio + "\u20ac";
            item.querySelector('[data-hook="discount"]').textContent = game.descuento + "%";

            games_list.appendChild(item);
        }

    }
}
window.addEventListener('DOMContentLoaded', initPage_onDomContentLoaded);