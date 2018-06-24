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
    public class PretragaImeIPrezimeController : ApiController
    {
        public List<Voznja> Post(FormirajVoznju temp)
        {
            string pom = "";
            List<Voznja> ret = new List<Voznja>();

            if (!String.IsNullOrEmpty(temp.OdOcena))
            {
                if (!String.IsNullOrEmpty(temp.DoOcena))
                {
                    pom = "od-do";
                }
                else
                    pom = "od";
            }
            else
            {
                if (!String.IsNullOrEmpty(temp.DoOcena))
                {
                    pom = "do";
                }
                else
                {
                    ret = new List<Voznja>();
                }
            }

            if (pom.Equals("od"))
            {
                foreach (Vozac vozac in Korisnici.Vozaci)
                {
                    if (vozac.Ime.Equals(temp.OdOcena))
                    {
                        foreach (Voznja voznja in Voznje.SveVoznje)
                        {
                            if (voznja.Vozac.Equals(vozac.KorisnickoIme))
                                ret.Add(voznja);
                        }
                    }
                }

                foreach (Musterija vozac in Korisnici.Musterije)
                {
                    if (vozac.Ime.Equals(temp.OdOcena))
                    {
                        foreach (Voznja voznja in Voznje.SveVoznje)
                        {
                            if (voznja.MusterijaZaKojuJeKreiranaVoznja.Equals(vozac.KorisnickoIme))
                                ret.Add(voznja);
                        }
                    }
                }
            }
            else if (pom.Equals("do"))
            {
                foreach (Vozac vozac in Korisnici.Vozaci)
                {
                    if (vozac.Prezime.Equals(temp.DoOcena))
                    {
                        foreach (Voznja voznja in Voznje.SveVoznje)
                        {
                            if (voznja.Vozac.Equals(vozac.KorisnickoIme))
                                ret.Add(voznja);
                        }
                    }
                }

                foreach (Musterija vozac in Korisnici.Musterije)
                {
                    if (vozac.Prezime.Equals(temp.DoOcena))
                    {
                        foreach (Voznja voznja in Voznje.SveVoznje)
                        {
                            if (voznja.MusterijaZaKojuJeKreiranaVoznja.Equals(vozac.KorisnickoIme))
                                ret.Add(voznja);
                        }
                    }
                }
            }
            else if (pom.Equals("od-do"))
            {
                foreach (Vozac vozac in Korisnici.Vozaci)
                {
                    if (vozac.Prezime.Equals(temp.DoOcena) && vozac.Ime.Equals(temp.OdOcena))
                    {
                        foreach (Voznja voznja in Voznje.SveVoznje)
                        {
                            if (voznja.Vozac.Equals(vozac.KorisnickoIme))
                                ret.Add(voznja);
                        }
                    }
                }

                foreach (Musterija vozac in Korisnici.Musterije)
                {
                    if (vozac.Prezime.Equals(temp.DoOcena) && vozac.Ime.Equals(temp.OdOcena))
                    {
                        foreach (Voznja voznja in Voznje.SveVoznje)
                        {
                            if (voznja.MusterijaZaKojuJeKreiranaVoznja.Equals(vozac.KorisnickoIme))
                                ret.Add(voznja);
                        }
                    }
                }
            }
                

            return ret;
        }
    }
}
