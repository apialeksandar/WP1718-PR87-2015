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
    public class VoznjeController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> ret = new List<Voznja>();

            foreach(Voznja voznja in UlogovaniKorisnici.Musterija.Voznje)
            {
                if(voznja.StatusVoznje == StatusVoznje.NaCekanju)
                {
                    ret.Add(voznja);
                }
            }
            return ret;
        }

        /*[ResponseType(typeof(void))]
        public IHttpActionResult Post(Korisnik korisnik)
        {
            string temp = korisnik.Ime;
            Voznja tempVoznja = null;
            List<Voznja> lista = new List<Voznja>();

            int index = int.Parse(korisnik.Ime);

            
            foreach (Voznja voz in UlogovaniKorisnici.Musterija.Voznje)
            {
                if (voz.StatusVoznje.Equals(StatusVoznje.NaCekanju))
                {
                    lista.Add(voz);
                }
            }

            tempVoznja = lista[index];

            foreach (Voznja voz in UlogovaniKorisnici.Musterija.Voznje)
            {
                if (tempVoznja.DatumIVremePorudzbine.Equals(voz.DatumIVremePorudzbine))
                {
                    voz.StatusVoznje = StatusVoznje.Otkazana;
                    foreach (Voznja voz1 in Voznje.SveVoznje)
                    {
                        if (tempVoznja.DatumIVremePorudzbine.Equals(voz1.DatumIVremePorudzbine))
                        {
                            voz1.StatusVoznje = StatusVoznje.Otkazana;
                        }
                    }
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }*/
    }
}
