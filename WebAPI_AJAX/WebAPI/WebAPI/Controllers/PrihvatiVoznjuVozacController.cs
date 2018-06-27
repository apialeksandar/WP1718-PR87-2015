using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Enumerations;
using WebAPI.Models;
using WebAPI.Models.Temp;

namespace WebAPI.Controllers
{
    public class PrihvatiVoznjuVozacController : ApiController
    {
        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            if(UlogovaniKorisnici.Vozac.Slobodan)
            {
                foreach (Voznja v in Voznje.SveVoznje)
                {
                    if (v.LokacijaNaKojuTaksiDolazi.Adresa.Broj == int.Parse(voznja.Broj) && v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(voznja.Ulica))
                    {
                        v.Vozac = UlogovaniKorisnici.Vozac.KorisnickoIme;
                        v.StatusVoznje = StatusVoznje.Prihvacena;
                        UlogovaniKorisnici.Vozac.Lokacija = v.LokacijaNaKojuTaksiDolazi;
                        UlogovaniKorisnici.Vozac.Voznje.Add(v);
                        UlogovaniKorisnici.Vozac.Slobodan = false;
                    }
                }
                return Ok("OK");
            }
            else
            {
                return BadRequest("ERROR: Trenutno ste zauzeti!");
            }
        }
    }
}
