using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Models.Temp;

namespace WebAPI.Controllers
{
    public class LokacijaController : ApiController
    {
        [ResponseType(typeof(Vozac))]
        public IHttpActionResult Post(FormirajVoznju lokacija)
        {
            Random r = new Random();
            foreach (Vozac vozac in Korisnici.Vozaci)
            {
                if (UlogovaniKorisnici.Vozac.KorisnickoIme.Equals(vozac.KorisnickoIme))
                {
                    vozac.Lokacija.XKoordinata = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));
                    vozac.Lokacija.YKoordinata = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));
                    vozac.Lokacija.Adresa.Broj = int.Parse(lokacija.Broj);
                    vozac.Lokacija.Adresa.Ulica = lokacija.Ulica;
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
