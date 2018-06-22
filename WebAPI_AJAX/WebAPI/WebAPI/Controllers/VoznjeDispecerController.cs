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
    public class VoznjeDispecerController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> ret = new List<Voznja>();

            foreach (Voznja voznja in Voznje.SveVoznje)
            {
                if (voznja.StatusVoznje == StatusVoznje.NaCekanju)
                {
                    ret.Add(voznja);
                }
            }
            return ret;
        }

        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            foreach(Voznja v in Voznje.SveVoznje)
            {
                if(v.LokacijaNaKojuTaksiDolazi.Adresa.Broj == int.Parse(voznja.Broj) && v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(voznja.Ulica))
                {
                    v.Dispecer = UlogovaniKorisnici.Dispecer.KorisnickoIme;
                    v.Vozac = voznja.Vozac;
                    v.StatusVoznje = StatusVoznje.Obradjena;
                    UlogovaniKorisnici.Dispecer.Voznje.Add(v);
                    foreach(Vozac vozac in Korisnici.Vozaci)
                    {
                        if(vozac.KorisnickoIme.Equals(voznja.Vozac))
                        {
                            vozac.Slobodan = false;
                            vozac.Voznje.Add(v);
                            return Ok("OK");
                        }
                    }
                }
            }

            return Ok("OK");
        }
    }
}
