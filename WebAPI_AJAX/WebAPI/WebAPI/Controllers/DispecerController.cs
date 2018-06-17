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
    public class DispecerController : ApiController
    {
        public RedirectResult Post([FromBody]Korisnik korisnik)
        {
            UlogovaniKorisnici.Dispecer = new Dispecer(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga);
            return Redirect("http://localhost:10482/HtmlDispecer.html");
        }

        public Dispecer Get()
        {
            return UlogovaniKorisnici.Dispecer;
        }
    }
}
