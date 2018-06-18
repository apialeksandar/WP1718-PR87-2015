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
    public class LoginController : ApiController
    {
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult Post(Korisnik korisnik)
        {

            foreach (Musterija k in Korisnici.Musterije)
            {
                if (k.KorisnickoIme.Equals(korisnik.KorisnickoIme) && k.Lozinka.Equals(korisnik.Lozinka))
                {
                    UlogovaniKorisnici.Musterija = k as Musterija;
                    return Ok(k);
                }
            }

            foreach(Dispecer d in Korisnici.Dispeceri)
            {
                if(d.KorisnickoIme.Equals(korisnik.KorisnickoIme) && d.Lozinka.Equals(korisnik.Lozinka))
                {
                    UlogovaniKorisnici.Dispecer = d as Dispecer;
                    return Ok(d);
                }
            }

            foreach (Vozac v in Korisnici.Vozaci)
            {
                if (v.KorisnickoIme.Equals(korisnik.KorisnickoIme) && v.Lozinka.Equals(korisnik.Lozinka))
                {
                    UlogovaniKorisnici.Vozac = v as Vozac;
                    return Ok(v);
                }
            }

            return BadRequest("Neispravan username ili lozinka");
        }
    }
}
