using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Enumerations;
using WebAPI.Models;
using WebAPI.Models.Temp;

namespace WebAPI.Controllers
{
    public class VozaciController : ApiController
    {
        public List<Vozac> Get()
        {
            List<Vozac> ret = new List<Vozac>();

            foreach(Vozac vozac in Korisnici.Vozaci)
            {
                if (vozac.Slobodan)
                    ret.Add(vozac);
            }

            return ret;
        }

        [ResponseType(typeof(Vozac))]
        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            Adresa a = new Adresa(voznja.Ulica, int.Parse(voznja.Broj), voznja.NaseljenoMesto, voznja.PozivniBrojMesta);
            Lokacija l = new Lokacija("", "", a);
            Voznja v = new Voznja(DateTime.Now, l, voznja.ZeljeniTipAutomobila, "", null, UlogovaniKorisnici.Dispecer.KorisnickoIme, voznja.Vozac, -1, null, StatusVoznje.Formirana, 0);
            UlogovaniKorisnici.Dispecer.Voznje.Add(v);
            Voznje.SveVoznje.Add(v);

            string lineSendVoznja = String.Empty;
            /*lineSendVoznja = v.DatumIVremePorudzbine.ToString() + "," + v.LokacijaNaKojuTaksiDolazi.XKoordinata + "," + v.LokacijaNaKojuTaksiDolazi.YKoordinata + "," + v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica + "," + v.LokacijaNaKojuTaksiDolazi.Adresa.Broj + "," + v.LokacijaNaKojuTaksiDolazi.Adresa.NaseljenoMesto + "," + v.LokacijaNaKojuTaksiDolazi.Adresa.PozivniBrojMesta + "," + v.ZeljeniTipAutomobila.ToString() + "," + v.MusterijaZaKojuJeKreiranaVoznja + "," + v.Odrediste.XKoordinata + "," + v.Odrediste.YKoordinata + "," + v.Odrediste.Adresa.Ulica + "," + v.Odrediste.Adresa.Broj + "," + v.Odrediste.Adresa.NaseljenoMesto + "," + v.Odrediste.Adresa.PozivniBrojMesta + "," + v.Dispecer + "," + v.Vozac + "," + v.Iznos + "," + v.Komentar.Opis + "," + v.Komentar.DatumObjave + "," + v.Komentar.KorisnikKojiJeOstavioKomentar + "," + v.Komentar.KorisnikKojiJeOstavioKomentar + "," + v.Komentar.OcenaVoznje.ToString() + "," + v.StatusVoznje.ToString() + "," + v.Pomoc + Environment.NewLine;

            if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"))
            {
                File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
            }
            else
            {
                File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
            }*/

            foreach (Vozac vozac in Korisnici.Vozaci)
            {
                if (vozac.KorisnickoIme.Equals(voznja.Vozac))
                {
                    vozac.Slobodan = false;
                    vozac.Voznje.Add(v);

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
            return Ok(v);
        }
    }
}
