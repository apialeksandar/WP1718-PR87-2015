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
    public class LoginController : ApiController
    {
        public RedirectResult Post([FromBody]Korisnik korisnik)
        {

            foreach (Korisnik k in Korisnici.Musterije)
            {
                if (k.KorisnickoIme.Equals(korisnik.KorisnickoIme) && k.Lozinka.Equals(korisnik.Lozinka))
                {
                    UlogovaniKorisnici.Musterija = k as Musterija;
                    return Redirect("http://localhost:10482/HtmlMusterija.html");
                }
            }

            foreach(Dispecer d in Korisnici.Dispeceri)
            {
                if(d.KorisnickoIme.Equals(korisnik.KorisnickoIme) && d.Lozinka.Equals(korisnik.Lozinka))
                {
                    UlogovaniKorisnici.Dispecer = d as Dispecer;
                    return Redirect("http://localhost:10482/HtmlDispecer.html");
                }
            }

            foreach (Vozac v in Korisnici.Vozaci)
            {
                if (v.KorisnickoIme.Equals(korisnik.KorisnickoIme) && v.Lozinka.Equals(korisnik.Lozinka))
                {
                    UlogovaniKorisnici.Vozac = v as Vozac;
                    return Redirect("http://localhost:10482/HtmlVozac.html");
                }
            }

            return Redirect("http://localhost:10482/HtmlError.html");
        }
    }
}
