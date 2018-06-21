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
    public class VozaciController : ApiController
    {
        public List<Vozac> Get()
        {
            List<Vozac> ret = new List<Vozac>();

            foreach(Vozac vozac in Korisnici.Vozaci)
            {
                if (vozac.Slobodan)
                    ret.Add(vozac);
            }

            return ret;
        }

        [ResponseType(typeof(Vozac))]
        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            Adresa a = new Adresa(voznja.Ulica, int.Parse(voznja.Broj), voznja.NaseljenoMesto, voznja.PozivniBrojMesta);
            Lokacija l = new Lokacija("", "", a);
            Voznja v = new Voznja(DateTime.Now, l, voznja.ZeljeniTipAutomobila, "", null, UlogovaniKorisnici.Dispecer.KorisnickoIme, voznja.Vozac, -1, null, StatusVoznje.Formirana);

            foreach(Vozac vozac in Korisnici.Vozaci)
            {
                if (vozac.KorisnickoIme.Equals(voznja.Vozac))
                {
                    vozac.Slobodan = false;
                    return Ok(vozac);
                }   
            }
            return Ok(v);
        }
    }
}
