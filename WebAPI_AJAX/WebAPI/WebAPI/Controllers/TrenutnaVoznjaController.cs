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
    public class TrenutnaVoznjaController : ApiController
    {
        public Voznja Get()
        {
            foreach(Voznja voznja in UlogovaniKorisnici.Vozac.Voznje)
            {
                if (voznja.StatusVoznje.Equals(StatusVoznje.Obradjena) || voznja.StatusVoznje.Equals(StatusVoznje.Formirana) || voznja.StatusVoznje.Equals(StatusVoznje.Prihvacena))
                    return voznja;
            }

            return null;
        }

        public string Post(FormirajVoznju voznja)
        {
            foreach(Voznja v in Voznje.SveVoznje)
            {
                if(v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(voznja.Ulica) &&v.LokacijaNaKojuTaksiDolazi.Adresa.Broj == int.Parse(voznja.Broj))
                {
                    if(voznja.StatusVoznje.Equals(StatusVoznje.Neuspesna))
                    {
                        return "komentar";
                    }
                    else if(voznja.StatusVoznje.Equals(StatusVoznje.Uspesna))
                    {
                        foreach(Voznja v1 in Voznje.SveVoznje)
                        {
                            if(v1.LokacijaNaKojuTaksiDolazi.Adresa.Broj == int.Parse(voznja.Broj) && v1.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(voznja.Ulica))
                            {
                                UlogovaniKorisnici.Vozac.Lokacija.Adresa.Ulica = voznja.Ulica;
                                UlogovaniKorisnici.Vozac.Lokacija.Adresa.Broj = int.Parse(voznja.Broj);
                                UlogovaniKorisnici.Vozac.Lokacija.XKoordinata = v1.LokacijaNaKojuTaksiDolazi.XKoordinata;
                                UlogovaniKorisnici.Vozac.Lokacija.YKoordinata = v1.LokacijaNaKojuTaksiDolazi.YKoordinata;

                                foreach(Vozac k in Korisnici.Vozaci)
                                {
                                    if(k.KorisnickoIme.Equals(UlogovaniKorisnici.Vozac.KorisnickoIme))
                                    {
                                        k.Lokacija = UlogovaniKorisnici.Vozac.Lokacija;
                                    }
                                }
                            }
                        }
                        return "unos";
                    }
                }
            }

            return "";
        }
    }
}
