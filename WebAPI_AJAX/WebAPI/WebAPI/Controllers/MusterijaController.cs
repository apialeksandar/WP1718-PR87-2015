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
    public class MusterijaController : ApiController
    {
        public RedirectResult Post([FromBody]Korisnik korisnik)
        {
            UlogovaniKorisnici.Musterija = new Musterija(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga);
            
            foreach(Musterija musterija in Korisnici.Musterije)
            {
                if (musterija.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    Korisnici.Musterije.Remove(musterija);
                    Korisnici.Musterije.Add(korisnik);
                    break;
                }
            }

            return Redirect("http://localhost:10482/HtmlMusterija.html");
        }

        public Musterija Get()
        {
            return UlogovaniKorisnici.Musterija;
        }
    }
}
