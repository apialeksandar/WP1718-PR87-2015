using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Models.Temp;

namespace WebAPI.Controllers
{
    public class LokacijaController : ApiController
    {
        [ResponseType(typeof(Vozac))]
        public IHttpActionResult Post(FormirajVoznju lokacija)
        {
            Random r = new Random();
            foreach (Vozac vozac in Korisnici.Vozaci)
            {
                if (UlogovaniKorisnici.Vozac.KorisnickoIme.Equals(vozac.KorisnickoIme))
                {
                    vozac.Lokacija.XKoordinata = string.Format("{0}.{1}", r.Next(0, 50), r.Next(0, 1000000000));
                    vozac.Lokacija.YKoordinata = string.Format("{0}.{1}", r.Next(0, 50), r.Next(0, 1000000000));
                    vozac.Lokacija.Adresa.Broj = int.Parse(lokacija.Broj);
                    vozac.Lokacija.Adresa.Ulica = lokacija.Ulica;

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

                    return Ok(vozac);
                }
            }

            return BadRequest("Niste ulogovani");
        }

        public Vozac Get()
        {
            return UlogovaniKorisnici.Vozac;
        }
    }
}
