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
    public class LoginController : ApiController
    {
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult Post(Korisnik korisnik)
        {
            foreach (Musterija k in Korisnici.Musterije)
            {
                if (k.KorisnickoIme.Equals(korisnik.KorisnickoIme) && k.Lozinka.Equals(korisnik.Lozinka))
                {
                    if(!k.Blokiran)
                    {
                        UlogovaniKorisnici.Musterija = k as Musterija;
                        HttpContext.Current.Session["ulogovan"] = UlogovaniKorisnici.Musterija;
                        return Ok(k);
                    }
                    else
                        return BadRequest("ERROR: Vas nalog je blokiran!");
                }
            }

            foreach(Dispecer d in Korisnici.Dispeceri)
            {
                if(d.KorisnickoIme.Equals(korisnik.KorisnickoIme) && d.Lozinka.Equals(korisnik.Lozinka))
                {
                    UlogovaniKorisnici.Dispecer = d as Dispecer;
                    HttpContext.Current.Session["ulogovan"] = UlogovaniKorisnici.Dispecer;
                    return Ok(d);
                }
            }

            foreach (Vozac v in Korisnici.Vozaci)
            {
                if (v.KorisnickoIme.Equals(korisnik.KorisnickoIme) && v.Lozinka.Equals(korisnik.Lozinka))
                {
                    if(!v.Blokiran)
                    {
                        UlogovaniKorisnici.Vozac = v as Vozac;
                        HttpContext.Current.Session["ulogovan"] = UlogovaniKorisnici.Vozac;
                        return Ok(v);
                    }
                    else
                        return BadRequest("ERROR: Vas nalog je blokiran!");
                }
            }

            return BadRequest("Neispravan username ili lozinka");
        }
    }
}
