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
    public class KomentarVozacController : ApiController
    {
        public IHttpActionResult Post(Komentar komentar)
        {
            Komentar retKom = new Komentar(komentar.Opis, DateTime.Now, UlogovaniKorisnici.Vozac.KorisnickoIme, DateTime.Now, komentar.OcenaVoznje);

            foreach (Voznja voznja in UlogovaniKorisnici.Vozac.Voznje)
            {
                if (voznja.StatusVoznje.Equals(StatusVoznje.Obradjena) || voznja.StatusVoznje.Equals(StatusVoznje.Formirana) || voznja.StatusVoznje.Equals(StatusVoznje.Prihvacena))
                {
                    foreach(Vozac vozac in Korisnici.Vozaci)
                    {
                        if (vozac.KorisnickoIme.Equals(UlogovaniKorisnici.Vozac.KorisnickoIme))
                            vozac.Slobodan = true;
                    }
                    voznja.StatusVoznje = StatusVoznje.Neuspesna;
                    retKom.VoznjaNaKojuJeKomentarOstavljen = voznja.DatumIVremePorudzbine;
                    voznja.Komentar = retKom;

                    foreach(Voznja v in Voznje.SveVoznje)
                    {
                        if(v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(voznja.LokacijaNaKojuTaksiDolazi.Adresa.Ulica) && v.LokacijaNaKojuTaksiDolazi.Adresa.Broj == voznja.LokacijaNaKojuTaksiDolazi.Adresa.Broj)
                        {
                            v.StatusVoznje = StatusVoznje.Neuspesna;
                            v.Komentar = retKom;
                        }
                    }

                    /*foreach (Voznja v1 in UlogovaniKorisnici.Dispecer.Voznje)
                    {
                        if (v1.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(voznja.LokacijaNaKojuTaksiDolazi.Adresa.Ulica) && v1.LokacijaNaKojuTaksiDolazi.Adresa.Broj == voznja.LokacijaNaKojuTaksiDolazi.Adresa.Broj)
                        {
                            v1.StatusVoznje = StatusVoznje.Neuspesna;
                            v1.Komentar = retKom;
                        }
                    }*/

                    /*foreach (Voznja v2 in UlogovaniKorisnici.Musterija.Voznje)
                    {
                        if (v2.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(voznja.LokacijaNaKojuTaksiDolazi.Adresa.Ulica) && v2.LokacijaNaKojuTaksiDolazi.Adresa.Broj == voznja.LokacijaNaKojuTaksiDolazi.Adresa.Broj)
                        {
                            v2.StatusVoznje = StatusVoznje.Neuspesna;
                            v2.Komentar = retKom;
                        }
                    }*/
                }
            }

            return Ok("Uspesno");
        }
    }
}
