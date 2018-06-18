function loadStart()
{
    $("#logdiv").load("./Htmls/HtmlLogin.html");
    $("#regdiv").load("./Htmls/HtmlRegistracija.html");
}

function loadMusterija()
{
    $("#regdiv").hide();
    $("#logdiv").load("./Htmls/HtmlMusterija.html");
}

function loadDispecer() {
    $("#regdiv").hide();
    $("#logdiv").load("./Htmls/HtmlDispecer.html");
}

function loadVozac() {
    $("#regdiv").hide();
    $("#logdiv").load("./Htmls/HtmlVozac.html");
}

function addVozac() {
    $.post('/api/dodajVozaca/', $('form#addVozac').serialize())
    .done(function (status, data, xhr) {
        alert(data);
        loadDispecer();
    })
    .fail(function (jqXHR, textStatus) {
        alert(jqXHR.responseJSON["Message"]);
    });
}

function register()
{
    $.post('/api/register/', $('form#reg').serialize())
    .done(function (status, data, xhr)
    {
        alert(data);
        loadStart();
    })
    .fail(function (jqXHR, textStatus)
    {
        alert(jqXHR.responseJSON["Message"]);
    });
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

function logIn()
{
    $.post('/api/login', $('form#logIn').serialize())
        .done(function (data, status, xhr) {
            localStorage.setItem("ulogovan", JSON.stringify(data));
            let recievedObject = JSON.parse(localStorage.getItem("ulogovan"));
            if (recievedObject.Uloga == 0)
                loadMusterija()
            else if (recievedObject.Uloga == 1)
                loadDispecer();
            else if(recievedObject.Uloga == 2)
                loadVozac();
        })
        .fail(function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        });
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

function editMus() {
    $.post('/api/musterija/', $('form#editMus').serialize())
    .done(function (status, data, xhr) {
        alert(data);
        loadMusterija();
    })
    .fail(function (jqXHR, textStatus) {
        alert(jqXHR.responseJSON["Message"]);
    });
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
    $.post('/api/dispecer/', $('form#editDis').serialize())
    .done(function (status, data, xhr) {
        alert(data);
        loadDispecer();
    })
    .fail(function (jqXHR, textStatus) {
        alert(jqXHR.responseJSON["Message"]);
    });
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
    $.post('/api/vozac/', $('form#editVoz').serialize())
    .done(function (status, data, xhr) {
        alert(data);
        loadVozac();
    })
    .fail(function (jqXHR, textStatus) {
        alert(jqXHR.responseJSON["Message"]);
    });
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