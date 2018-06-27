function loadStart()
{
    $("#logdiv").load("./Htmls/HtmlLogin.html");
    $("#regdiv").load("./Htmls/HtmlRegistracija.html");
}

function loadMusterija()
{
    $("#regdiv").hide();
    $("#errdiv").hide();
    $("#logdiv").load("./Htmls/HtmlMusterija.html");
}

function loadDispecer() {
    $("#regdiv").hide();
    $("#errdiv").hide();
    $("#logdiv").load("./Htmls/HtmlDispecer.html");
}

function loadVozac() {
    $("#regdiv").hide();
    $("#errdiv").hide();
    $("#logdiv").load("./Htmls/HtmlVozac.html");
}

function loadKomentar(pom) {
    $("#regdiv").hide();
    $("#errdiv").hide();
    $("#logdiv").load("./Htmls/HtmlKomentar.html");
}

function loadKomentarVozac() {
    $("#regdiv").hide();
    $("#errdiv").hide();
    $("#logdiv").load("./Htmls/HtmlKomentarVozac.html");
}

function loadKomentarMusterija() {
    $("#regdiv").hide();
    $("#errdiv").hide();
    $("#logdiv").load("./Htmls/HtmlKomentarMusterija.html");
}

function loadUnosOdredista()
{
    $("#regdiv").hide();
    $("#errdiv").hide();
    $("#logdiv").load("./Htmls/HtmlUnosOdredista.html");
}

function addVozac()
{
    let vozac =
        {
            KorisnickoIme: `${$('#korisnickoIme2').val()}`,
            Lozinka: `${$('#lozinka2').val()}`,
            Ime: `${$('#ime2').val()}`,
            Prezime: `${$('#prezime2').val()}`,
            Pol: `${$('#pol2').val()}`,
            Jmbg: `${$('#jmbg2').val()}`,
            KontaktTelefon: `${$('#kontaktTelefon2').val()}`,
            Email: `${$('#email2').val()}`,
        }

    $.ajax({
        url: '/api/dodajVozaca/post',
        method: 'POST',
        data: JSON.stringify(vozac),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("INFO: Uspesno ste dodali vozaca.");
            loadDispecer();
        },
        error: function (jqXHR) {
            alert(jqXHR.responseJSON["Message"]);
        }
    })
}

function register()
{
    let korisnik =
        {
            KorisnickoIme: `${$('#username').val()}`,
            Lozinka: `${$('#password').val()}`,
            Ime: `${$('#ime1').val()}`,
            Prezime: `${$('#prezime1').val()}`,
            Pol: `${$('#pol1').val()}`,
            Jmbg: `${$('#jmbg1').val()}`,
            KontaktTelefon: `${$('#kontaktTelefon1').val()}`,
            Email: `${$('#email1').val()}`,
        }

    $.ajax({
        url: '/api/register/post',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("INFO: Uspesno ste se registrovali.");
            loadStart();
        },
        error: function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        }
    })
}

function validateRegister() {
    $("#reg").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { register() }
    });
}

function zahtevVoznje() {

    let voznja =
        {
            Ulica: `${$('#ulica').val()}`,
            Broj: `${$('#broj').val()}`,
            ZeljeniTipAutomobila: `${$('#tipAutomobila').val()}`,
            XK: `${$('#xKoridnata').val()}`,
            YK: `${$('#yKoridnata').val()}`,
            PomocZaMapu: `${$('#pomoccc').val()}`,
        }

    $.ajax({
        url: '/api/zahtevVoznje/post',
        method: 'POST',
        data: JSON.stringify(voznja),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("INFO: Uspesno ste zatrazili voznju.");
            loadMusterija();
            document.getElementById("pomoc").value = 0;
        },
        error: function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        }
    })
}

function validateZahtevVoznje() {
    $("#zahtevVoznje").validate({
        rules: {
            ulica: "required",
            broj: "required"
        },
        messages: {
            ulica: {
                required: "Obavezno polje",
            },
            broj: {
                required: "Obavezno polje",
            }
        },
        submitHandler: function (form) { zahtevVoznje() }
    });
}

function logIn()
{
    let korisnik =
        {
            KorisnickoIme: `${$('#korisnickoIme1').val()}`,
            Lozinka: `${$('#lozinka1').val()}`,
        }

    $.ajax({
        url: '/api/login/post',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("INFO: Uspesno ste se prijavili.");
            localStorage.setItem("ulogovan", JSON.stringify(data));
            let recievedObject = JSON.parse(localStorage.getItem("ulogovan"));
            if (recievedObject.Uloga == 0)
                loadMusterija()
            else if (recievedObject.Uloga == 1)
                loadDispecer();
            else
                loadVozac();
        },
        error: function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        }
    })
}

function validateLogin()
{
    $("#logIn").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            }
        },
        messages: {
            korisnickoIme: {
                required: "Morate uneti ovo polje",
                minlength: "Korisnicko ime mora biti minimum 4 slova dugacak"
            },
            lozinka: {
                required: "Morate uneti ovo polje",
                minlength: "Lozinka mora biti minimum 5 slova dugacak"
            }
        },
        submitHandler: function (form) { logIn() }

    });
}

function editLokacijaVozac()
{

    let lokacija =
        {
            Ulica: `${$('#ulica').val()}`,
            Broj: `${$('#broj').val()}`,
        }

    $.ajax({
        url: '/api/lokacija/post',
        method: 'POST',
        data: JSON.stringify(lokacija),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("INFO: Uspesno ste promenuli lokaciju.");
            loadVozac();
        },
        error: function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        }
    })
}

function validateEditLokacijaVozac() {
    $("#editLokacija").validate({
        rules: {
            ulica: {
                required: true
            },
            broj: {
                required: true
            },
            naseljenoMesto: {
                required: true
            },
            pozivniBrojMesta: {
                required: true
            }
        },
        messages: {
            ulica: {
                required: "Obavezno polje",
            },
            broj: {
                required: "Obavezno polje",
            },
            naseljenoMesto: {
                required: "Obavezno polje",
            },
            pozivniBrojMesta: {
                required: "Obavezno polje",
            }
        },
        submitHandler: function (form) { editLokacijaVozac() }
    });
}

function editMus() {

    let korisnik =
        {
            KorisnickoIme: `${$('#korisnickoIme').val()}`,
            Lozinka: `${$('#lozinka').val()}`,
            Ime: `${$('#ime').val()}`,
            Prezime: `${$('#prezime').val()}`,
            Pol: `${$('#pol').val()}`,
            Jmbg: `${$('#jmbg').val()}`,
            KontaktTelefon: `${$('#kontaktTelefon').val()}`,
            Email: `${$('#email').val()}`,
        }

    $.ajax({
        url: '/api/musterija/post',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("INFO: Uspesno ste izmenili podatke.");
            loadMusterija();
        },
        error: function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        }
    })
}

function validateMusterija() {
    $("#editMus").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { editMus() }
    });
}

function editDispecer() {

    let korisnik =
        {
            KorisnickoIme: `${$('#korisnickoIme1').val()}`,
            Lozinka: `${$('#lozinka1').val()}`,
            Ime: `${$('#ime1').val()}`,
            Prezime: `${$('#prezime1').val()}`,
            Pol: `${$('#pol1').val()}`,
            Jmbg: `${$('#jmbg1').val()}`,
            KontaktTelefon: `${$('#kontaktTelefon1').val()}`,
            Email: `${$('#email1').val()}`,
        }

    $.ajax({
        url: '/api/dispecer/post',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("INFO: Uspesno ste izmenili podatke.");
            loadDispecer();
        },
        error: function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        }
    })
    /*$.post('/api/dispecer/', $('form#editDis').serialize())
    .done(function (status, data, xhr) {
        alert(data);
        loadDispecer();
    })
    .fail(function (jqXHR, textStatus) {
        alert(jqXHR.responseJSON["Message"]);
    });*/
}

function validateDispecer() {
    $("#editDis").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { editDispecer() }
    });
}

function editVozac() {
    let korisnik =
        {
            KorisnickoIme: `${$('#korisnickoIme2').val()}`,
            Lozinka: `${$('#lozinka2').val()}`,
            Ime: `${$('#ime2').val()}`,
            Prezime: `${$('#prezime2').val()}`,
            Pol: `${$('#pol2').val()}`,
            Jmbg: `${$('#jmbg2').val()}`,
            KontaktTelefon: `${$('#kontaktTelefon2').val()}`,
            Email: `${$('#email2').val()}`,
        }

    $.ajax({
        url: '/api/vozac/post',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("INFO: Uspesno ste izmenili podatke.");
            loadVozac();
        },
        error: function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        }
    })
}

function validateVozac() {
    $("#editVoz").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { editVozac() }
    });
}

function validateVozac2() {
    $("#addVozac").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { addVozac() }
    });
}

function displayLocation(latitude, longitude) {
    var request = new XMLHttpRequest();
    var method = 'GET';
    var url = 'http://maps.googleapis.com/maps/api/geocode/json?latlng='
        + latitude + ',' + longitude + '&sensor=true';
    var async = false;
    var address;
    request.open(method, url, async);
    request.onreadystatechange = function () {
        if (request.readyState == 4 && request.status == 200) {
            var data = JSON.parse(request.responseText);
            address = data.results[0];
            var value = address.formatted_address.split(",");
            count = value.length;
            country = value[count - 1];
            state = value[count - 2];
            city = value[count - 3];
        }
    };
    request.send();
    return address.formatted_address;
};

function placeMarker(map, location) {
    var marker = new google.maps.Marker({
        position: location,
        map: map
    });
    var fullAdresa = displayLocation(location.lat(), location.lng());
    var delovi = fullAdresa.split(",");
    var ulicaIbroj = delovi[0];
    var ulica = ulicaIbroj.split(" ");
    var newUlica = ulica.slice(0, -1);
    var broj = ulica[ulica.length - 1];
    var temp = newUlica.join(' ');
    var grad = delovi[1];
    var drzava = delovi[2];
    var fulAdresa = location.lat() + "," + location.lng() + "," + ulicaIbroj + "," + grad + "," + drzava;
    $("#ulica").val(temp);
    $("#broj").val(broj);
    $("#xKordinata").val(location.lat());
    $("#yKordinata").val(parseDouble(location.lng()));
    $("#pomoccc").val(1);
    var infowindow = new google.maps.InfoWindow({
        content: 'Latitude: ' + location.lat() + '<br>Longitude: ' + location.lng() + '<br>Ulica i broj: ' + ulicaIbroj + '<br>Grad: ' + grad + '<br>Drzava: ' + drzava + '<br>=' + displayLocation(location.lat(), location.lng())
    });
    infowindow.open(map, marker);
}

function myMap() {
    var mapCanvas = document.getElementById("map");
    var myCenter = new google.maps.LatLng(45.242630873254775, 19.842914435055945);
    var mapOptions = { center: myCenter, zoom: 15 };
    var map = new google.maps.Map(mapCanvas, mapOptions);
    google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(map, event.latLng);
    });
}