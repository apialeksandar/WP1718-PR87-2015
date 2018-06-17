using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class VozacController : ApiController
    {
        public RedirectResult Post([FromBody]Korisnik korisnik)
        {
           // UlogovaniKorisnici.Vozac = new Vozac(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga);
            return Redirect("http://localhost:10482/HtmlMusterija.html");
        }

        public Vozac Get()
        {
            return UlogovaniKorisnici.Vozac;
        }

        public RedirectResult NapraviVozaca([FromBody]Vozac vozac)
        {
            Vozac vozacP = new Vozac(vozac.KorisnickoIme, vozac.Lozinka, vozac.Ime, vozac.Prezime, vozac.Pol, vozac.Jmbg, vozac.KontaktTelefon, vozac.Email, vozac.Uloga, null, null);
            foreach(Automobil automobil in Automobili.Vozila)
            {
                if(automobil.Slobodan)
                {
                    vozacP.Automobil = automobil;
                    automobil.Slobodan = false;
                }
            }

            vozacP.Lokacija = new Lokacija("44°49'04.127", "44°49'04.127", new Adresa("PocetnaUlica", 5, "Novi Sad", "21000"));

            Vozaci.Vozacii.Add(vozacP);
            return Redirect("http://localhost:10482/HtmlDispecer.html");
        }
    }
}
