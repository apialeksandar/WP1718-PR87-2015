using System;
using System.Collections.Generic;
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

            UlogovaniKorisnici.Vozac = new Vozac(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga, l, a);
            return CreatedAtRoute("DefaultApi", new { korisnickoIme = korisnik.KorisnickoIme }, korisnik);
        }

        public Vozac Get()
        {
            return (Vozac)HttpContext.Current.Session["ulogovan"];
        }
    }
}
