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
    public class Komentar2Controller : ApiController
    {
        public IHttpActionResult Post(Komentar komentar)
        {
            Komentar retKom = new Komentar(komentar.Opis, DateTime.Now, UlogovaniKorisnici.Musterija.KorisnickoIme, DateTime.Now, komentar.OcenaVoznje);
            List<Voznja> temp = new List<Voznja>();
            int index = int.Parse(komentar.KorisnikKojiJeOstavioKomentar);

            foreach (Voznja voznja in UlogovaniKorisnici.Musterija.Voznje)
            {
                 temp.Add(voznja);
            }
            retKom.VoznjaNaKojuJeKomentarOstavljen = temp[index].DatumIVremePorudzbine;

            string[] linesVoznja = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt");
            for (int i = 0; i < linesVoznja.Count(); i++)
            {
                string[] line = linesVoznja[i].Split(',');

                if (temp[index].DatumIVremePorudzbine.Equals(DateTime.Parse(line[0])))
                {
                    var file = new List<string>(System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"));
                    file.RemoveAt(i);
                    File.WriteAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", file.ToArray());
                }
            }

            Voznje.SveVoznje.Remove(temp[index]);
            UlogovaniKorisnici.Musterija.Voznje.Remove(temp[index]);
            temp[index].Komentar = retKom;
            temp[index].Pomoc = 0;

            Voznje.SveVoznje.Add(temp[index]);
            UlogovaniKorisnici.Musterija.Voznje.Add(temp[index]);

            string lineSendVoznja = String.Empty;
            lineSendVoznja = temp[index].DatumIVremePorudzbine.ToString() + "," + temp[index].LokacijaNaKojuTaksiDolazi.XKoordinata + "," + temp[index].LokacijaNaKojuTaksiDolazi.YKoordinata + "," + temp[index].LokacijaNaKojuTaksiDolazi.Adresa.Ulica + "," + temp[index].LokacijaNaKojuTaksiDolazi.Adresa.Broj + "," + temp[index].LokacijaNaKojuTaksiDolazi.Adresa.NaseljenoMesto + "," + temp[index].LokacijaNaKojuTaksiDolazi.Adresa.PozivniBrojMesta + "," + temp[index].ZeljeniTipAutomobila.ToString() + "," + temp[index].MusterijaZaKojuJeKreiranaVoznja + "," + temp[index].Odrediste.XKoordinata + "," + temp[index].Odrediste.YKoordinata + "," + temp[index].Odrediste.Adresa.Ulica + "," + temp[index].Odrediste.Adresa.Broj + "," + temp[index].Odrediste.Adresa.NaseljenoMesto + "," + temp[index].Odrediste.Adresa.PozivniBrojMesta + "," + temp[index].Dispecer + "," + temp[index].Vozac + "," + temp[index].Iznos + "," + temp[index].Komentar.Opis + "," + temp[index].Komentar.DatumObjave + "," + temp[index].Komentar.KorisnikKojiJeOstavioKomentar + "," + temp[index].Komentar.KorisnikKojiJeOstavioKomentar + "," + temp[index].Komentar.OcenaVoznje.ToString() + "," + temp[index].StatusVoznje.ToString() + "," + temp[index].Pomoc + Environment.NewLine;

            if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"))
            {
                File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
            }
            else
            {
                File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
            }

            return Ok("Uspesno");
        }
    }
}
