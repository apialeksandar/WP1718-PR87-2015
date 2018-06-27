using System;
using System.Collections.Generic;
using System.IO;
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

                    string[] linesVoznja = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt");
                    for (int i = 0; i < linesVoznja.Count(); i++)
                    {
                        string[] line = linesVoznja[i].Split(',');

                        if (voznja.DatumIVremePorudzbine.Equals(DateTime.Parse(line[0])))
                        {
                            var file = new List<string>(System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"));
                            file.RemoveAt(i);
                            File.WriteAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", file.ToArray());
                        }
                    }

                    string lineSendVoznja = String.Empty;
                    /*lineSendVoznja = voznja.DatumIVremePorudzbine.ToString() + "," + voznja.LokacijaNaKojuTaksiDolazi.XKoordinata + "," + voznja.LokacijaNaKojuTaksiDolazi.YKoordinata + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.Ulica + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.Broj + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.NaseljenoMesto + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.PozivniBrojMesta + "," + voznja.ZeljeniTipAutomobila.ToString() + "," + voznja.MusterijaZaKojuJeKreiranaVoznja + "," + voznja.Odrediste.XKoordinata + "," + voznja.Odrediste.YKoordinata + "," + voznja.Odrediste.Adresa.Ulica + "," + voznja.Odrediste.Adresa.Broj + "," + voznja.Odrediste.Adresa.NaseljenoMesto + "," + voznja.Odrediste.Adresa.PozivniBrojMesta + "," + voznja.Dispecer + "," + voznja.Vozac + "," + voznja.Iznos + "," + voznja.Komentar.Opis + "," + voznja.Komentar.DatumObjave + "," + voznja.Komentar.KorisnikKojiJeOstavioKomentar + "," + voznja.Komentar.KorisnikKojiJeOstavioKomentar + "," + voznja.Komentar.OcenaVoznje.ToString() + "," + voznja.StatusVoznje.ToString() + "," + voznja.Pomoc + Environment.NewLine;

                    if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"))
                    {
                        File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
                    }
                    else
                    {
                        File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
                    }*/

                    foreach (Voznja v in Voznje.SveVoznje)
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
