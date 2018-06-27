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
    public class PretragaSveDispecerController : ApiController
    {
        public List<Voznja> Post(FormirajVoznju temp)
        {
            int a = 0;
            string statusVoznje = "";
            string ocena = "";
            string datum = "";
            DateTime value = new DateTime(1, 1, 1);
            string cena = "";
            string ime = "";
            List<Voznja> ret = new List<Voznja>();
            List<Voznja> re1 = new List<Voznja>();
            List<string> pomoc = new List<string>();

            // STATUS VOZNJE
            if (temp.StatusVoznje1.Equals("Izaberi..."))
            {
                statusVoznje = "nema";
            }
            else
            {
                statusVoznje = "ima";
                pomoc.Add("statusVoznje");
            }

            // OCENA
            if (!temp.OdOcena.Equals("Izaberi..."))
            {
                if (!temp.DoOcena.Equals("Izaberi..."))
                {
                    ocena = "od-do";
                    pomoc.Add("ocenaOdDo");
                }
                else
                {
                    ocena = "od";
                    pomoc.Add("ocenaOd");
                }
            }
            else
            {
                if (!temp.DoOcena.Equals("Izaberi..."))
                {
                    ocena = "do";
                    pomoc.Add("ocenaDo");
                }
            }

            // DATUM
            if (!temp.Od.Equals(value))
            {
                if (!temp.Do.Equals(value))
                {
                    datum = "od-do";
                    pomoc.Add("datumOdDo");
                }
                else
                {
                    datum = "od";
                    pomoc.Add("datumOd");
                }
            }
            else
            {
                if (!temp.Do.Equals(value))
                {
                    datum = "do";
                    pomoc.Add("datumDo");
                }
                else
                {
                    ret = new List<Voznja>();
                }
            }

            // CENA
            if (!String.IsNullOrEmpty(temp.OdCena))
            {
                if (!String.IsNullOrEmpty(temp.DoCena))
                {
                    cena = "od-do";
                    pomoc.Add("cenaOdDo");
                }
                else
                {
                    cena = "od";
                    pomoc.Add("cenaOd");
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(temp.DoCena))
                {
                    cena = "do";
                    pomoc.Add("cenaDo");
                }
            }

            // IME
            if (!String.IsNullOrEmpty(temp.Ime))
            {
                if (!String.IsNullOrEmpty(temp.Prezime))
                {
                    ime = "imeIPrezime";
                    pomoc.Add("imeIPrezime");
                }
                else
                {
                    ime = "ime";
                    pomoc.Add("ime");
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(temp.Prezime))
                {
                    ime = "prezime";
                    pomoc.Add("prezime");
                }
            }

            // STATUS VOZNJE
            if (statusVoznje.Equals("ima"))
            {
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (voznja.StatusVoznje.ToString().Equals(temp.StatusVoznje1))
                    {
                        ret.Add(voznja);
                    }
                }
            }
            else
            {
                ret = new List<Voznja>();
            }


            // OCENA
            if (ocena.Equals("od"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (!(voznja.Komentar == null))
                    {
                        if (ret.Count > 0)
                        {
                            foreach (Voznja v in ret)
                            {
                                if ((int)voznja.Komentar.OcenaVoznje >= int.Parse(temp.OdOcena))
                                {
                                    if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                        a++;
                                }
                            }
                            if (a == ret.Count)
                            {
                                ret.Add(voznja);
                                a = 0;
                            }
                        }
                        else
                        {
                            if ((int)voznja.Komentar.OcenaVoznje >= int.Parse(temp.OdOcena))
                            {
                                ret.Add(voznja);
                            }
                        }
                    }
                }
            }
            else if (ocena.Equals("do"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (!(voznja.Komentar == null))
                    {
                        if (ret.Count > 0)
                        {
                            foreach (Voznja v in ret)
                            {
                                if ((int)voznja.Komentar.OcenaVoznje <= int.Parse(temp.DoOcena))
                                {
                                    if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                        a++;
                                }
                            }
                            if (a == ret.Count)
                            {
                                ret.Add(voznja);
                                a = 0;
                            }
                        }
                        else
                        {
                            if ((int)voznja.Komentar.OcenaVoznje <= int.Parse(temp.DoOcena))
                            {
                                ret.Add(voznja);
                            }
                        }
                    }
                }
            }
            else if (ocena.Equals("od-do"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (!(voznja.Komentar == null))
                    {
                        if (ret.Count > 0)
                        {
                            foreach (Voznja v in ret)
                            {
                                if ((int)voznja.Komentar.OcenaVoznje >= int.Parse(temp.OdOcena) && (int)voznja.Komentar.OcenaVoznje <= int.Parse(temp.DoOcena))
                                {
                                    if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                        a++;
                                }
                            }

                            if (a == ret.Count)
                            {
                                ret.Add(voznja);
                                a = 0;
                            }
                        }
                        else
                        {
                            if ((int)voznja.Komentar.OcenaVoznje >= int.Parse(temp.OdOcena) && (int)voznja.Komentar.OcenaVoznje <= int.Parse(temp.DoOcena))
                            {
                                ret.Add(voznja);
                            }
                        }
                    }
                }
            }


            // DATUM
            if (datum.Equals("od"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (ret.Count > 0)
                    {
                        foreach (Voznja v in ret)
                        {
                            if (voznja.DatumIVremePorudzbine >= temp.Od)
                            {
                                if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                    a++;
                            }
                        }
                        if (a == ret.Count)
                        {
                            ret.Add(voznja);
                            a = 0;
                        }
                    }
                    else
                    {
                        if (voznja.DatumIVremePorudzbine >= temp.Od)
                        {
                            ret.Add(voznja);
                        }
                    }
                }
            }
            else if (datum.Equals("do"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (ret.Count > 0)
                    {
                        foreach (Voznja v in ret)
                        {
                            if (voznja.DatumIVremePorudzbine <= temp.Do)
                            {
                                if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                    a++;
                            }
                        }
                        if (a == ret.Count)
                        {
                            ret.Add(voznja);
                            a = 0;
                        }
                    }
                    else
                    {
                        if (voznja.DatumIVremePorudzbine <= temp.Do)
                        {
                            ret.Add(voznja);
                        }
                    }
                }
            }
            else if (datum.Equals("od-do"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (ret.Count > 0)
                    {
                        foreach (Voznja v in ret)
                        {
                            if (voznja.DatumIVremePorudzbine >= temp.Od && voznja.DatumIVremePorudzbine <= temp.Do)
                            {
                                if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                    a++;
                            }
                        }
                        if (a == ret.Count)
                        {
                            ret.Add(voznja);
                            a = 0;
                        }
                    }
                    else
                    {
                        if (voznja.DatumIVremePorudzbine >= temp.Od && voznja.DatumIVremePorudzbine <= temp.Do)
                        {
                            ret.Add(voznja);
                        }
                    }
                }
            }

            // CENA
            if (cena.Equals("od"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (ret.Count > 0)
                    {
                        foreach (Voznja v in ret)
                        {
                            if ((int)voznja.Iznos >= int.Parse(temp.OdCena))
                            {
                                if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                    a++;
                            }
                        }
                        if (a == ret.Count)
                        {
                            ret.Add(voznja);
                            a = 0;
                        }
                    }
                    else
                    {
                        if ((int)voznja.Iznos >= int.Parse(temp.OdCena))
                        {
                            ret.Add(voznja);
                        }
                    }
                }
            }
            else if (cena.Equals("do"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (ret.Count > 0)
                    {
                        foreach (Voznja v in ret)
                        {
                            if ((int)voznja.Iznos <= int.Parse(temp.DoCena))
                            {
                                if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                    a++;
                            }
                        }
                        if (a == ret.Count)
                        {
                            ret.Add(voznja);
                            a = 0;
                        }
                    }
                    else
                    {
                        if ((int)voznja.Iznos <= int.Parse(temp.DoCena))
                        {
                            ret.Add(voznja);
                        }
                    }
                }
            }
            else if (cena.Equals("od-do"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if (ret.Count > 0)
                    {
                        foreach (Voznja v in ret)
                        {
                            if ((int)voznja.Iznos >= int.Parse(temp.OdCena) && (int)voznja.Iznos <= int.Parse(temp.DoCena))
                            {
                                if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                    a++;
                            }
                        }
                        if (a == ret.Count)
                        {
                            ret.Add(voznja);
                            a = 0;
                        }
                    }
                    else
                    {
                        if ((int)voznja.Iznos >= int.Parse(temp.OdCena) && (int)voznja.Iznos <= int.Parse(temp.DoCena))
                        {
                            ret.Add(voznja);
                        }
                    }
                }
            }

            // IME
            if (ime.Equals("ime"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    foreach(Korisnik k in Korisnici.Musterije)
                    {
                        if(voznja.MusterijaZaKojuJeKreiranaVoznja.Equals(k.KorisnickoIme))
                        {
                            if(k.Ime.Equals(temp.Ime))
                            {
                                if (ret.Count > 0)
                                {
                                    foreach (Voznja v in ret)
                                    {
                                        if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                            a++;
                                    }

                                    if (a == ret.Count)
                                    {
                                        ret.Add(voznja);
                                        a = 0;
                                    }
                                }
                                else
                                {
                                    ret.Add(voznja);
                                }   
                            }
                        }
                    }
                    a = 0;
                    foreach (Korisnik k in Korisnici.Vozaci)
                    {
                        if (voznja.Vozac.Equals(k.KorisnickoIme))
                        {
                            if (k.Ime.Equals(temp.Ime))
                            {
                                if (ret.Count > 0)
                                {
                                    foreach (Voznja v in ret)
                                    {
                                        if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                            a++;
                                    }

                                    if (a == ret.Count)
                                    {
                                        ret.Add(voznja);
                                        a = 0;
                                    }
                                }
                                else
                                {
                                    ret.Add(voznja);
                                }
                            }
                        }
                    }
                }
            }
            else if(ime.Equals("prezime"))
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    foreach (Korisnik k in Korisnici.Musterije)
                    {
                        if (voznja.MusterijaZaKojuJeKreiranaVoznja.Equals(k.KorisnickoIme))
                        {
                            if (k.Prezime.Equals(temp.Prezime))
                            {
                                if (ret.Count > 0)
                                {
                                    foreach (Voznja v in ret)
                                    {
                                        if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                            a++;
                                    }

                                    if (a == ret.Count)
                                    {
                                        ret.Add(voznja);
                                        a = 0;
                                    }
                                }
                                else
                                {
                                    ret.Add(voznja);
                                }
                            }
                        }
                    }
                    a = 0;
                    foreach (Korisnik k in Korisnici.Vozaci)
                    {
                        if (voznja.Vozac.Equals(k.KorisnickoIme))
                        {
                            if (k.Prezime.Equals(temp.Prezime))
                            {
                                if (ret.Count > 0)
                                {
                                    foreach (Voznja v in ret)
                                    {
                                        if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                            a++;
                                    }

                                    if (a == ret.Count)
                                    {
                                        ret.Add(voznja);
                                        a = 0;
                                    }
                                }
                                else
                                {
                                    ret.Add(voznja);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                a = 0;
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    foreach (Korisnik k in Korisnici.Musterije)
                    {
                        if (voznja.MusterijaZaKojuJeKreiranaVoznja.Equals(k.KorisnickoIme))
                        {
                            if (k.Prezime.Equals(temp.Prezime) && k.Ime.Equals(temp.Ime))
                            {
                                if (ret.Count > 0)
                                {
                                    foreach (Voznja v in ret)
                                    {
                                        if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                            a++;
                                    }

                                    if (a == ret.Count)
                                    {
                                        ret.Add(voznja);
                                        a = 0;
                                    }
                                }
                                else
                                {
                                    ret.Add(voznja);
                                }
                            }
                        }
                    }
                    a = 0;
                    foreach (Korisnik k in Korisnici.Vozaci)
                    {
                        if (voznja.MusterijaZaKojuJeKreiranaVoznja.Equals(k.KorisnickoIme))
                        {
                            if (k.Prezime.Equals(temp.Prezime) && k.Ime.Equals(temp.Ime))
                            {
                                if (ret.Count > 0)
                                {
                                    foreach (Voznja v in ret)
                                    {
                                        if (!v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                                            a++;
                                    }

                                    if (a == ret.Count)
                                    {
                                        ret.Add(voznja);
                                        a = 0;
                                    }
                                }
                                else
                                {
                                    ret.Add(voznja);
                                }
                            }
                        }
                    }
                }
            }

            int aaa = 0;

            foreach (Voznja voznja in ret)
            {
                foreach (string opcija in pomoc)
                {

                    if (opcija.Equals("statusVoznje"))
                    {
                        if (voznja.StatusVoznje.ToString().Equals(temp.StatusVoznje1))
                            aaa++;
                    }

                    if (opcija.Equals("ocenaOdDo"))
                    {
                        if ((int)voznja.Komentar.OcenaVoznje >= int.Parse(temp.OdOcena) && (int)voznja.Komentar.OcenaVoznje <= int.Parse(temp.DoOcena))
                            aaa++;
                    }

                    if (opcija.Equals("ocenaOd"))
                    {
                        if ((int)voznja.Komentar.OcenaVoznje >= int.Parse(temp.OdOcena))
                            aaa++;
                    }

                    if (opcija.Equals("ocenaDo"))
                    {
                        if ((int)voznja.Komentar.OcenaVoznje <= int.Parse(temp.DoOcena))
                            aaa++;
                    }

                    if (opcija.Equals("cenaOdDo"))
                    {
                        if ((int)voznja.Iznos >= int.Parse(temp.OdCena) && (int)voznja.Iznos <= int.Parse(temp.DoCena))
                            aaa++;
                    }

                    if (opcija.Equals("cenaOd"))
                    {
                        if ((int)voznja.Iznos >= int.Parse(temp.OdCena))
                            aaa++;
                    }

                    if (opcija.Equals("cenaDo"))
                    {
                        if ((int)voznja.Iznos <= int.Parse(temp.DoCena))
                            aaa++;
                    }

                    if (opcija.Equals("datumOdDo"))
                    {
                        if (voznja.DatumIVremePorudzbine >= temp.Od && voznja.DatumIVremePorudzbine <= temp.Do)
                            aaa++;
                    }

                    if (opcija.Equals("datumOd"))
                    {
                        if (voznja.DatumIVremePorudzbine >= temp.Od)
                            aaa++;
                    }

                    if (opcija.Equals("datumDo"))
                    {
                        if (voznja.DatumIVremePorudzbine <= temp.Do)
                            aaa++;
                    }

                    if(opcija.Equals("ime"))
                    {
                        foreach(Voznja v in Voznje.SveVoznje)
                        {
                            if(v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                            {
                                foreach(Korisnik k in Korisnici.Musterije)
                                {
                                    if(v.MusterijaZaKojuJeKreiranaVoznja.Equals(k.KorisnickoIme))
                                    {
                                        if (k.Ime.Equals(temp.Ime))
                                        {
                                            aaa++;
                                            break;
                                        }  
                                    }
                                }

                                foreach (Korisnik k in Korisnici.Vozaci)
                                {
                                    if (v.Vozac.Equals(k.KorisnickoIme))
                                    {
                                        if (k.Ime.Equals(temp.Ime))
                                        {
                                            aaa++;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (opcija.Equals("prezime"))
                    {
                        foreach (Voznja v in Voznje.SveVoznje)
                        {
                            if (v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                            {
                                foreach(Korisnik k in Korisnici.Musterije)
                                {
                                    if (v.MusterijaZaKojuJeKreiranaVoznja.Equals(k.KorisnickoIme))
                                    {
                                        if (k.Prezime.Equals(temp.Prezime))
                                        {
                                            aaa++;
                                            break;
                                        }
                                    }
                                }

                                foreach (Korisnik k in Korisnici.Vozaci)
                                {
                                    if (v.Vozac.Equals(k.KorisnickoIme))
                                    {
                                        if (k.Prezime.Equals(temp.Prezime))
                                        {
                                            aaa++;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (opcija.Equals("imeIPrezime"))
                    {
                        foreach (Voznja v in Voznje.SveVoznje)
                        {
                            if (v.DatumIVremePorudzbine.Equals(voznja.DatumIVremePorudzbine))
                            {
                                foreach (Korisnik k in Korisnici.Musterije)
                                {
                                    if (v.MusterijaZaKojuJeKreiranaVoznja.Equals(k.KorisnickoIme))
                                    {
                                        if (k.Ime.Equals(temp.Ime) && k.Prezime.Equals(temp.Prezime))
                                        {
                                            aaa++;
                                            break;
                                        }
                                    }
                                }

                                foreach (Korisnik k in Korisnici.Vozaci)
                                {
                                    if (v.Vozac.Equals(k.KorisnickoIme))
                                    {
                                        if (k.Ime.Equals(temp.Ime) && k.Prezime.Equals(temp.Prezime))
                                        {
                                            aaa++;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (aaa == pomoc.Count)
                {
                    re1.Add(voznja);
                }
                aaa = 0;
            }


            return re1;
        }
    }
}
