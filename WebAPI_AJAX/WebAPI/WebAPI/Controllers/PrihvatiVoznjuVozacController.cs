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
    public class PrihvatiVoznjuVozacController : ApiController
    {
        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            if(UlogovaniKorisnici.Vozac.Slobodan)
            {
                foreach (Voznja v in Voznje.SveVoznje)
                {
                    if (v.LokacijaNaKojuTaksiDolazi.Adresa.Broj == int.Parse(voznja.Broj) && v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(voznja.Ulica))
                    {
                        v.Vozac = UlogovaniKorisnici.Vozac.KorisnickoIme;
                        v.StatusVoznje = StatusVoznje.Prihvacena;
                        UlogovaniKorisnici.Vozac.Lokacija = v.LokacijaNaKojuTaksiDolazi;
                        UlogovaniKorisnici.Vozac.Voznje.Add(v);
                        UlogovaniKorisnici.Vozac.Slobodan = false;

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
                return Ok("OK");
            }
            else
            {
                return BadRequest("ERROR: Trenutno ste zauzeti!");
            }
        }
    }
}
