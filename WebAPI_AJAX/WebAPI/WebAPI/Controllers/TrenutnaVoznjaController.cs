using System;
using System.Collections.Generic;
using System.IO;
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

                                string[] linesVozac = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt");
                                for (int i = 0; i < linesVozac.Count(); i++)
                                {
                                    string[] line = linesVozac[i].Split(',');

                                    if (UlogovaniKorisnici.Vozac.KorisnickoIme.Equals(line[0]))
                                    {
                                        var file = new List<string>(System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt"));
                                        file.RemoveAt(i);
                                        File.WriteAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt", file.ToArray());
                                    }
                                }

                                string lineSendVozac = String.Empty;
                                lineSendVozac = UlogovaniKorisnici.Vozac.KorisnickoIme + "," + UlogovaniKorisnici.Vozac.Lozinka + "," + UlogovaniKorisnici.Vozac.Ime + "," + UlogovaniKorisnici.Vozac.Prezime + "," + UlogovaniKorisnici.Vozac.Pol.ToString() + "," + UlogovaniKorisnici.Vozac.Jmbg + "," + UlogovaniKorisnici.Vozac.KontaktTelefon + "," + UlogovaniKorisnici.Vozac.Email + "," + UlogovaniKorisnici.Vozac.Uloga.ToString() + "," + UlogovaniKorisnici.Vozac.Lokacija.XKoordinata + "," + UlogovaniKorisnici.Vozac.Lokacija.YKoordinata + "," + UlogovaniKorisnici.Vozac.Lokacija.Adresa.Ulica + "," + UlogovaniKorisnici.Vozac.Lokacija.Adresa.Broj + "," + UlogovaniKorisnici.Vozac.Lokacija.Adresa.NaseljenoMesto + "," + UlogovaniKorisnici.Vozac.Lokacija.Adresa.PozivniBrojMesta + "," + UlogovaniKorisnici.Vozac.Automobil.Vozac + "," + UlogovaniKorisnici.Vozac.Automobil.GodisteAutomobila + "," + UlogovaniKorisnici.Vozac.Automobil.BrojRegistarskeOznake + "," + UlogovaniKorisnici.Vozac.Automobil.BrojTaksiVozila + "," + UlogovaniKorisnici.Vozac.Automobil.TipAutomobila.ToString() + "," + UlogovaniKorisnici.Vozac.Slobodan.ToString() + "," + UlogovaniKorisnici.Vozac.Rastojanje + Environment.NewLine;

                                if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt"))
                                {
                                    File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt", lineSendVozac);
                                }
                                else
                                {
                                    File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt", lineSendVozac);
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
