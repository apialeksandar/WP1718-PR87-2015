using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Enumerations;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class Komentar2Controller : ApiController
    {
        public IHttpActionResult Post(Komentar komentar)
        {
            Komentar retKom = new Komentar(komentar.Opis, DateTime.Now, UlogovaniKorisnici.Musterija.KorisnickoIme, DateTime.Now, komentar.OcenaVoznje);
            List<Voznja> temp = new List<Voznja>();
            int index = int.Parse(komentar.KorisnikKojiJeOstavioKomentar);

            foreach (Voznja voznja in UlogovaniKorisnici.Musterija.Voznje)
            {
                 temp.Add(voznja);
            }
            retKom.VoznjaNaKojuJeKomentarOstavljen = temp[index].DatumIVremePorudzbine;

            Voznje.SveVoznje.Remove(temp[index]);
            UlogovaniKorisnici.Musterija.Voznje.Remove(temp[index]);
            temp[index].Komentar = retKom;
            temp[index].Pomoc = 0;

            Voznje.SveVoznje.Add(temp[index]);
            UlogovaniKorisnici.Musterija.Voznje.Add(temp[index]);

            return Ok("Uspesno");
        }
    }
}
