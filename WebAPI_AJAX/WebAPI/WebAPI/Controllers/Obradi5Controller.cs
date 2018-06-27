using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.Temp;

namespace WebAPI.Controllers
{
    public class Obradi5Controller : ApiController
    {
        public List<Vozac> Post(FormirajVoznju voznja)
        {
            List<Vozac> ret = new List<Vozac>();
            List<Vozac> ret1 = new List<Vozac>();

            for (int i = 0; i < Korisnici.Vozaci.Count; i++)
            {
                foreach (Voznja v in Voznje.SveVoznje)
                {
                    if (v.LokacijaNaKojuTaksiDolazi.Adresa.Broj == int.Parse(voznja.Broj) && v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(voznja.Ulica))
                    {
                        if (Korisnici.Vozaci[i].Slobodan)
                        {
                            Korisnici.Vozaci[i].Rastojanje = Math.Sqrt(Math.Pow(double.Parse(v.LokacijaNaKojuTaksiDolazi.XKoordinata) - double.Parse(Korisnici.Vozaci[i].Lokacija.XKoordinata), 2) - Math.Pow(double.Parse(v.LokacijaNaKojuTaksiDolazi.YKoordinata) - double.Parse(Korisnici.Vozaci[i].Lokacija.YKoordinata), 2));
                            ret.Add(Korisnici.Vozaci[i]);
                        }
                    }
                }
            }

            foreach (Vozac vozac in ret)
            {
                if (ret1.Count == 5)
                {
                    foreach (Vozac v in ret1)
                    {
                        if (vozac.Rastojanje < v.Rastojanje)
                        {
                            ret1.Remove(v);
                            ret1.Add(vozac);
                            break;
                        }
                    }
                }
                else
                {
                    ret1.Add(vozac);
                }
                
            }
            return ret1;
        }
    }
}
