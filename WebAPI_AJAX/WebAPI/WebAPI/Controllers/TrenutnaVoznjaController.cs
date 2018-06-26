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
                        return "unos";
                    }
                }
            }

            return "";
        }
    }
}
