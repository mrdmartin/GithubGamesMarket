'use strict';

var initPage_onDomContentLoaded = function () {

    var pageName = document.querySelector("html").getAttribute("data-page");
    var cookiesWarning = document.querySelector("[data-widget='cookies-warning']");
    var btnAcceptCookies = cookiesWarning.querySelector("[data-widget='cookiesAceptar']");
    var btnRefuseCookie = cookiesWarning.querySelector("[data-widget='cookiesDenegar']");

    var checkLog = function (event) {
        if (document.getElementById('userLogged') === null) {
            event.preventDefault();
            alert('Debes iniciar sesión');
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
        if (formBuy != undefined) {
            formBuy.addEventListener("submit", checkLog);
        }
        

    }
    if (pageName === 'Buy') {

        var formBuying = document.getElementById('formBuying');
        var input_tarj = document.getElementById('tarj');
        var input_tarj_mes = document.getElementById('tarj_mes');
        var input_tarj_ano = document.getElementById('tarj_ano');
        var input_cod_seg = document.getElementById('cod_seg');

        var checkForm = function (event) {

            var tarj = input_tarj.value;
            var tarj_mes = input_tarj_mes.value;
            var tarj_ano = input_tarj_ano.value;
            var cod_seg = input_cod_seg.value;

            var msg = "";
            if (tarj.length != 16) {
                msg = msg.concat("La tarjeta debe contener 16 car\u00E1cteres. \n");
            }
            if (tarj_mes > 12 || tarj_mes < 0 || tarj_mes.length != 2) {
                msg = msg.concat("El mes de la tarjeta debe contener 2 car\u00E1cteres y estar entre 01 y 12. \n");
            }
            if (tarj_ano > 99 || tarj_ano < 0 || tarj_ano.length != 2) {
                msg = msg.concat("El a\u00f1o de la tarjeta debe contener 2 car\u00E1cteres y estar entre 00 y 99. \n");
            }
            if (cod_seg > 999 || cod_seg < 0 || tarj_ano.length != 3) {
                msg = msg.concat("El c\u00F3digo de seguridad de la tarjeta debe contener 3 car\u00E1cteres y estar entre 000 y 999. \n");
            }
            if (msg != "") {
                alert(msg)
                event.preventDefault();
            }

        }
        formBuying.addEventListener("submit", checkLog);
        formBuying.addEventListener("submit", checkForm);

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
            precio = precio.replace('.',',');

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