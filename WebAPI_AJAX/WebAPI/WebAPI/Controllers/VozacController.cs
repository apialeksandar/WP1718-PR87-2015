using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class VozacController : ApiController
    {
        [ResponseType(typeof(Vozac))]
        public IHttpActionResult Post(Vozac korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Automobil a = new Automobil();
            Lokacija l = new Lokacija();

            foreach(Vozac v in Korisnici.Vozaci)
            {
                if(v.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    a = v.Automobil;
                }
            }

            foreach(Vozac v in Korisnici.Vozaci)
            {
                if (v.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    l = v.Lokacija;
                }
            }

            UlogovaniKorisnici.Vozac = new Vozac(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga, l, a, korisnik.Slobodan, korisnik.Rastojanje);

            string lineSendVozac = String.Empty;
            lineSendVozac = UlogovaniKorisnici.Vozac.KorisnickoIme + "," + UlogovaniKorisnici.Vozac.Lozinka + "," + UlogovaniKorisnici.Vozac.Ime + "," + UlogovaniKorisnici.Vozac.Prezime + "," + UlogovaniKorisnici.Vozac.Pol.ToString() + "," + UlogovaniKorisnici.Vozac.Jmbg + "," + UlogovaniKorisnici.Vozac.KontaktTelefon + "," + UlogovaniKorisnici.Vozac.Email + "," + UlogovaniKorisnici.Vozac.Uloga.ToString() + "," + UlogovaniKorisnici.Vozac.Lokacija.XKoordinata + "," + UlogovaniKorisnici.Vozac.Lokacija.YKoordinata + "," + UlogovaniKorisnici.Vozac.Lokacija.Adresa.Ulica + "," + UlogovaniKorisnici.Vozac.Lokacija.Adresa.Broj + "," + UlogovaniKorisnici.Vozac.Lokacija.Adresa.NaseljenoMesto + "," + UlogovaniKorisnici.Vozac.Lokacija.Adresa.PozivniBrojMesta + "," + UlogovaniKorisnici.Vozac.Automobil.Vozac + "," + UlogovaniKorisnici.Vozac.Automobil.GodisteAutomobila + "," + UlogovaniKorisnici.Vozac.Automobil.BrojRegistarskeOznake + "," + UlogovaniKorisnici.Vozac.Automobil.BrojTaksiVozila + "," + UlogovaniKorisnici.Vozac.Automobil.TipAutomobila.ToString() + "," + UlogovaniKorisnici.Vozac.Slobodan.ToString() + "," + UlogovaniKorisnici.Vozac.Rastojanje + Environment.NewLine;

            if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt"))
            {
                File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt", lineSendVozac);
            }
            else
            {
                File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt", lineSendVozac);
            }

            return CreatedAtRoute("DefaultApi", new { korisnickoIme = korisnik.KorisnickoIme }, korisnik);
        }

        public Vozac Get()
        {
            return UlogovaniKorisnici.Vozac;
        }
    }
}
