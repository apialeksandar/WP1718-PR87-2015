using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

            foreach(Vozac v in Korisnici.Vozaci)
            {
                if(v.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    a = v.Automobil;
                }
            }

            UlogovaniKorisnici.Vozac = new Vozac(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga, korisnik.Lokacija, a);
            return CreatedAtRoute("DefaultApi", new { korisnickoIme = korisnik.KorisnickoIme }, korisnik);
        }

        public Vozac Get()
        {
            return UlogovaniKorisnici.Vozac;
        }
    }
}
