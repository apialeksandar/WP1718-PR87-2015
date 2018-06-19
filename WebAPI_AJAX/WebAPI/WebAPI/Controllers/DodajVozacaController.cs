using System;
using System.Collections.Generic;
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

            Vozac vozacP = new Vozac(vozac.KorisnickoIme, vozac.Lozinka, vozac.Ime, vozac.Prezime, vozac.Pol, vozac.Jmbg, vozac.KontaktTelefon, vozac.Email, Uloga.Vozac, null, null);
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

            vozacP.Lokacija = new Lokacija("44°49'04.127", "44°49'04.127", new Adresa("PocetnaUlica", 5, "Novi Sad", "21000"));

            Korisnici.Vozaci.Add(vozacP);
            return CreatedAtRoute("DefaultApi", new { korisnickoIme = vozac.KorisnickoIme }, vozac);
        }
    }
}
