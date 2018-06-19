using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LokacijaController : ApiController
    {
        [ResponseType(typeof(Vozac))]
        public IHttpActionResult Post(Lokacija lokacija)
        {
            Random r = new Random();
            foreach (Vozac vozac in Korisnici.Vozaci)
            {
                if (UlogovaniKorisnici.Vozac.KorisnickoIme.Equals(vozac.KorisnickoIme))
                {
                    vozac.Lokacija.XKoordinata = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));
                    vozac.Lokacija.YKoordinata = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));
                    vozac.Lokacija.Adresa.Broj = lokacija.Adresa.Broj;
                    vozac.Lokacija.Adresa.NaseljenoMesto = lokacija.Adresa.NaseljenoMesto;
                    vozac.Lokacija.Adresa.PozivniBrojMesta = lokacija.Adresa.PozivniBrojMesta;
                    vozac.Lokacija.Adresa.Ulica = lokacija.Adresa.Ulica;
                    return Ok(vozac);
                }
            }

            return BadRequest("Niste ulogovani");
        }

        public Vozac Get()
        {
            return UlogovaniKorisnici.Vozac;
        }
    }
}
