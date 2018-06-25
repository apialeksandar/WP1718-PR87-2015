using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Enumerations;
using WebAPI.Models;
using WebAPI.Models.Temp;

namespace WebAPI.Controllers
{
    public class ZahtevVoznjeController : ApiController
    {
        [ResponseType(typeof(Musterija))]
        public IHttpActionResult Post(FormirajVoznju v)
        {
            Random r = new Random();
            Voznja voznja = new Voznja(DateTime.Now, new Lokacija(string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130)), string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130)), new Adresa(v.Ulica, int.Parse(v.Broj), "Novi Sad", "21000")), v.ZeljeniTipAutomobila, UlogovaniKorisnici.Musterija.KorisnickoIme, null, "", "", -1, null, StatusVoznje.NaCekanju);

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
