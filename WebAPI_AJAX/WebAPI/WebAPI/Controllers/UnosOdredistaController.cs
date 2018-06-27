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
    public class UnosOdredistaController : ApiController
    {
        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            Random r = new Random();
            foreach(Voznja v in UlogovaniKorisnici.Vozac.Voznje)
            {
                if(v.StatusVoznje.Equals(StatusVoznje.Formirana) || v.StatusVoznje.Equals(StatusVoznje.Obradjena) || v.StatusVoznje.Equals(StatusVoznje.Prihvacena))
                {
                    v.Iznos = double.Parse(voznja.Iznos);
                    v.Odrediste = new Lokacija();
                    v.Odrediste.Adresa = new Adresa();
                    v.Odrediste.Adresa.Broj = int.Parse(voznja.Broj);
                    v.Odrediste.Adresa.Ulica = voznja.Ulica;
                    v.Odrediste.XKoordinata = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));
                    v.Odrediste.YKoordinata = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));
                    v.StatusVoznje = StatusVoznje.Uspesna;
                    v.Pomoc = 1;

                    foreach(Vozac vozac in Korisnici.Vozaci)
                    {
                        if (vozac.KorisnickoIme.Equals(UlogovaniKorisnici.Vozac.KorisnickoIme))
                            vozac.Slobodan = true;
                    }

                    foreach(Voznja v1 in Voznje.SveVoznje)
                    {
                        if(v1.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica) && v1.LokacijaNaKojuTaksiDolazi.Adresa.Broj == v.LokacijaNaKojuTaksiDolazi.Adresa.Broj)
                        {
                            v1.Iznos = double.Parse(voznja.Iznos);
                            v1.Odrediste.Adresa.Broj = int.Parse(voznja.Broj);
                            v1.Odrediste.Adresa.Ulica = voznja.Ulica;
                            v1.Odrediste.XKoordinata = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));
                            v1.Odrediste.YKoordinata = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));
                            v1.StatusVoznje = StatusVoznje.Uspesna;
                            v1.Pomoc = 1;
                        }
                    }

                    foreach (Voznja v1 in Voznje.SveVoznje)
                    {
                        if (v1.Odrediste.Adresa.Broj == int.Parse(voznja.Broj) && v1.Odrediste.Adresa.Ulica.Equals(voznja.Ulica))
                        {
                            UlogovaniKorisnici.Vozac.Lokacija.Adresa.Ulica = voznja.Ulica;
                            UlogovaniKorisnici.Vozac.Lokacija.Adresa.Broj = int.Parse(voznja.Broj);
                            UlogovaniKorisnici.Vozac.Lokacija.XKoordinata = v1.Odrediste.XKoordinata;
                            UlogovaniKorisnici.Vozac.Lokacija.YKoordinata = v1.Odrediste.YKoordinata;

                            foreach (Vozac k in Korisnici.Vozaci)
                            {
                                if (k.KorisnickoIme.Equals(UlogovaniKorisnici.Vozac.KorisnickoIme))
                                {
                                    k.Lokacija = UlogovaniKorisnici.Vozac.Lokacija;
                                }
                            }
                        }
                    }

                    /*foreach (Voznja v2 in UlogovaniKorisnici.Dispecer.Voznje)
                    {
                        if (v2.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica) && v2.LokacijaNaKojuTaksiDolazi.Adresa.Broj == v.LokacijaNaKojuTaksiDolazi.Adresa.Broj)
                        {
                            v2.Iznos = double.Parse(voznja.Iznos);
                            v2.Odrediste.Adresa.Broj = int.Parse(voznja.Broj);
                            v2.Odrediste.Adresa.Ulica = voznja.Ulica;
                            v2.StatusVoznje = StatusVoznje.Uspesna;
                            v2.Pomoc = 1;
                        }
                    }*/

                    /*foreach (Voznja v3 in UlogovaniKorisnici.Musterija.Voznje)
                    {
                        if (v3.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica) && v3.LokacijaNaKojuTaksiDolazi.Adresa.Broj == v.LokacijaNaKojuTaksiDolazi.Adresa.Broj)
                        {
                            v3.Iznos = double.Parse(voznja.Iznos);
                            v3.Odrediste.Adresa.Broj = int.Parse(voznja.Broj);
                            v3.Odrediste.Adresa.Ulica = voznja.Ulica;
                            v3.StatusVoznje = StatusVoznje.Uspesna;
                        }
                    }*/
                }
            }

            return Ok("OK");
        }
    }
}
