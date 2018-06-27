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
                    v.Odrediste.XKoordinata = string.Format("{0}.{1}", r.Next(0, 50), r.Next(0, 1000000000));
                    v.Odrediste.YKoordinata = string.Format("{0}.{1}", r.Next(0, 50), r.Next(0, 1000000000));
                    v.StatusVoznje = StatusVoznje.Uspesna;
                    v.Pomoc = 1;

                    string[] linesVoznja = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt");
                    for (int i = 0; i < linesVoznja.Count(); i++)
                    {
                        string[] line = linesVoznja[i].Split(',');

                        /*if (v.DatumIVremePorudzbine.Equals(DateTime.Parse(line[i])))
                        {
                            var file = new List<string>(System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"));
                            file.RemoveAt(i);
                            File.WriteAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", file.ToArray());
                        }*/
                    }

                    string lineSendVoznja = String.Empty;
                    lineSendVoznja = v.DatumIVremePorudzbine.ToString() + "," + v.LokacijaNaKojuTaksiDolazi.XKoordinata + "," + v.LokacijaNaKojuTaksiDolazi.YKoordinata + "," + v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica + "," + v.LokacijaNaKojuTaksiDolazi.Adresa.Broj + "," + v.LokacijaNaKojuTaksiDolazi.Adresa.NaseljenoMesto + "," + v.LokacijaNaKojuTaksiDolazi.Adresa.PozivniBrojMesta + "," + v.ZeljeniTipAutomobila.ToString() + "," + v.MusterijaZaKojuJeKreiranaVoznja + "," + v.Odrediste.XKoordinata + "," + v.Odrediste.YKoordinata + "," + v.Odrediste.Adresa.Ulica + "," + v.Odrediste.Adresa.Broj + "," + v.Odrediste.Adresa.NaseljenoMesto + "," + v.Odrediste.Adresa.PozivniBrojMesta + "," + v.Dispecer + "," + v.Vozac + "," + v.Iznos + "," + v.Komentar.Opis + "," + v.Komentar.DatumObjave + "," + v.Komentar.KorisnikKojiJeOstavioKomentar + "," + v.Komentar.KorisnikKojiJeOstavioKomentar + "," + v.Komentar.OcenaVoznje.ToString() + "," + v.StatusVoznje.ToString() + "," + v.Pomoc + Environment.NewLine;

                    if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"))
                    {
                        File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
                    }
                    else
                    {
                        File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
                    }

                    foreach (Vozac vozac in Korisnici.Vozaci)
                    {
                        if (vozac.KorisnickoIme.Equals(UlogovaniKorisnici.Vozac.KorisnickoIme))
                        {
                            vozac.Slobodan = true;

                            string[] linesVozac = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt");
                            for (int i = 0; i < linesVozac.Count(); i++)
                            {
                                string[] line = linesVozac[i].Split(',');

                                if (vozac.KorisnickoIme.Equals(line[0]))
                                {
                                    var file = new List<string>(System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt"));
                                    file.RemoveAt(i);
                                    File.WriteAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt", file.ToArray());
                                }
                            }

                            string lineSendVozac = String.Empty;
                            lineSendVozac = vozac.KorisnickoIme + "," + vozac.Lozinka + "," + vozac.Ime + "," + vozac.Prezime + "," + vozac.Pol.ToString() + "," + vozac.Jmbg + "," + vozac.KontaktTelefon + "," + vozac.Email + "," + vozac.Uloga.ToString() + "," + vozac.Lokacija.XKoordinata + "," + vozac.Lokacija.YKoordinata + "," + vozac.Lokacija.Adresa.Ulica + "," + vozac.Lokacija.Adresa.Broj + "," + vozac.Lokacija.Adresa.NaseljenoMesto + "," + vozac.Lokacija.Adresa.PozivniBrojMesta + "," + vozac.Automobil.Vozac + "," + vozac.Automobil.GodisteAutomobila + "," + vozac.Automobil.BrojRegistarskeOznake + "," + vozac.Automobil.BrojTaksiVozila + "," + vozac.Automobil.TipAutomobila.ToString() + "," + vozac.Slobodan.ToString() + "," + vozac.Rastojanje + Environment.NewLine;

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

                    foreach(Voznja v1 in Voznje.SveVoznje)
                    {
                        if(v1.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica) && v1.LokacijaNaKojuTaksiDolazi.Adresa.Broj == v.LokacijaNaKojuTaksiDolazi.Adresa.Broj)
                        {
                            v1.Iznos = double.Parse(voznja.Iznos);
                            v1.Odrediste = new Lokacija(string.Format("{0}.{1}", r.Next(0, 50), r.Next(0, 1000000000), r.Next(0, 130)), string.Format("{0}.{1}", r.Next(0, 50), r.Next(0, 1000000000)), new Adresa(voznja.Ulica, int.Parse(voznja.Broj), "Novi Sad", "21000"));
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

                            break;
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
