using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI.Enumerations;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DodajVozacaController : ApiController
    {
        [ResponseType(typeof(Vozac))]
        public IHttpActionResult Post(Vozac vozac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vozac vozacP = new Vozac(vozac.KorisnickoIme, vozac.Lozinka, vozac.Ime, vozac.Prezime, vozac.Pol, vozac.Jmbg, vozac.KontaktTelefon, vozac.Email, Uloga.Vozac, null, null, true, 0);
            foreach (Automobil automobil in Automobili.Vozila)
            {
                if (automobil.Slobodan)
                {
                    vozacP.Automobil = automobil;
                    automobil.Slobodan = false;
                    automobil.Vozac = vozacP.KorisnickoIme;
                    vozacP.Automobil = automobil;
                    break;
                }
                else
                {
                    return BadRequest("Ne postoje slobodna vozila!");
                }
            }

            vozacP.Lokacija = new Lokacija("15.0365984136987125", "15.0365984136987125", new Adresa("PocetnaUlica", 5, "Novi Sad", "21000"));

            string lineSendVozac = String.Empty;
            lineSendVozac = vozacP.KorisnickoIme + "," + vozacP.Lozinka + "," + vozacP.Ime + "," + vozacP.Prezime + "," + vozacP.Pol.ToString() + "," + vozacP.Jmbg + "," + vozacP.KontaktTelefon + "," + vozacP.Email + "," + vozacP.Uloga.ToString() + "," + vozacP.Lokacija.XKoordinata + "," + vozacP.Lokacija.YKoordinata + "," + vozacP.Lokacija.Adresa.Ulica + "," + vozacP.Lokacija.Adresa.Broj + "," + vozacP.Lokacija.Adresa.NaseljenoMesto + "," + vozacP.Lokacija.Adresa.PozivniBrojMesta + "," + vozacP.Automobil.Vozac + "," + vozacP.Automobil.GodisteAutomobila + "," + vozacP.Automobil.BrojRegistarskeOznake + "," + vozacP.Automobil.BrojTaksiVozila + "," + vozacP.Automobil.TipAutomobila + "," + vozacP.Slobodan.ToString() + "," + vozacP.Rastojanje + Environment.NewLine;

            if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt"))
            {
                File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt", lineSendVozac);
            }
            else
            {
                File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt", lineSendVozac);
            }

            Korisnici.Vozaci.Add(vozacP);
            return CreatedAtRoute("DefaultApi", new { korisnickoIme = vozac.KorisnickoIme }, vozac);
        }
    }
}
