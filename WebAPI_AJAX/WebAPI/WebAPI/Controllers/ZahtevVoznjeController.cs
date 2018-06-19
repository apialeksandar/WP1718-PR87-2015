using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Enumerations;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ZahtevVoznjeController : ApiController
    {
        [ResponseType(typeof(Musterija))]
        public IHttpActionResult Post(Vozac korisnik)
        {
            Voznja voznja = new Voznja(DateTime.Now, korisnik.Lokacija, korisnik.Automobil.TipAutomobila, UlogovaniKorisnici.Musterija.KorisnickoIme, null, "", "", -1, null, StatusVoznje.NaCekanju);

            foreach(Musterija musterija in Korisnici.Musterije)
            {
                if(musterija.KorisnickoIme.Equals(UlogovaniKorisnici.Musterija.KorisnickoIme))
                {
                    musterija.Voznje.Add(voznja);
                    Voznje.SveVoznje.Add(voznja);
                    return Ok(musterija);
                }
            }

            return BadRequest("GRESKA");
        }
    }
}
