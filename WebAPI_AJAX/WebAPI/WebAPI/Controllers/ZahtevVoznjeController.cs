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
    public class ZahtevVoznjeController : ApiController
    {
        [ResponseType(typeof(Musterija))]
        public IHttpActionResult Post(FormirajVoznju v)
        {

            if (v.PomocZaMapu == 0)
            {
                Random r = new Random();
                Voznja voznja = new Voznja(DateTime.Now, new Lokacija(string.Format("{0}.{1}", r.Next(0, 50), r.Next(0, 1000000000)), string.Format("{0}.{1}", r.Next(0, 50), r.Next(0, 1000000000)), new Adresa(v.Ulica, int.Parse(v.Broj), "Novi Sad", "21000")), v.ZeljeniTipAutomobila, UlogovaniKorisnici.Musterija.KorisnickoIme, null, "", "", -1, null, StatusVoznje.NaCekanju, 0);

                foreach (Musterija musterija in Korisnici.Musterije)
                {
                    if (musterija.KorisnickoIme.Equals(UlogovaniKorisnici.Musterija.KorisnickoIme))
                    {
                        voznja.Komentar = new Komentar();
                        voznja.Odrediste = new Lokacija();
                        voznja.Odrediste.Adresa = new Adresa();
                        musterija.Voznje.Add(voznja);
                        Voznje.SveVoznje.Add(voznja);

                        string lineSendVoznja = String.Empty;
                        lineSendVoznja = voznja.DatumIVremePorudzbine.ToString() + "," + voznja.LokacijaNaKojuTaksiDolazi.XKoordinata + "," + voznja.LokacijaNaKojuTaksiDolazi.YKoordinata + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.Ulica + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.Broj + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.NaseljenoMesto + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.PozivniBrojMesta + "," + voznja.ZeljeniTipAutomobila.ToString() + "," + voznja.MusterijaZaKojuJeKreiranaVoznja + "," + voznja.Odrediste.XKoordinata + "," + voznja.Odrediste.YKoordinata + "," + voznja.Odrediste.Adresa.Ulica + "," + voznja.Odrediste.Adresa.Broj + "," + voznja.Odrediste.Adresa.NaseljenoMesto + "," + voznja.Odrediste.Adresa.PozivniBrojMesta + "," + voznja.Dispecer + "," + voznja.Vozac + "," + voznja.Iznos + "," + voznja.Komentar.Opis + "," + voznja.Komentar.DatumObjave + "," + voznja.Komentar.KorisnikKojiJeOstavioKomentar + "," + voznja.Komentar.KorisnikKojiJeOstavioKomentar + "," + voznja.Komentar.OcenaVoznje.ToString() + "," + voznja.StatusVoznje.ToString() + "," + voznja.Pomoc + Environment.NewLine;

                        if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"))
                        {
                            File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
                        }
                        else
                        {
                            File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
                        }

                        return Ok(musterija);
                    }
                }
            }
            else if(v.PomocZaMapu == 1)
            {
                Random r = new Random();
                Voznja voznja = new Voznja(DateTime.Now, new Lokacija(v.XK.ToString(), v.YK.ToString(), new Adresa(v.Ulica, int.Parse(v.Broj), "Novi Sad", "21000")), v.ZeljeniTipAutomobila, UlogovaniKorisnici.Musterija.KorisnickoIme, null, "", "", -1, null, StatusVoznje.NaCekanju, 0);

                foreach (Musterija musterija in Korisnici.Musterije)
                {
                    if (musterija.KorisnickoIme.Equals(UlogovaniKorisnici.Musterija.KorisnickoIme))
                    {
                        voznja.Komentar = new Komentar();
                        voznja.Odrediste = new Lokacija();
                        voznja.Odrediste.Adresa = new Adresa();
                        musterija.Voznje.Add(voznja);
                        Voznje.SveVoznje.Add(voznja);

                        string lineSendVoznja = String.Empty;
                        lineSendVoznja = voznja.DatumIVremePorudzbine.ToString() + "," + voznja.LokacijaNaKojuTaksiDolazi.XKoordinata + "," + voznja.LokacijaNaKojuTaksiDolazi.YKoordinata + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.Ulica + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.Broj + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.NaseljenoMesto + "," + voznja.LokacijaNaKojuTaksiDolazi.Adresa.PozivniBrojMesta + "," + voznja.ZeljeniTipAutomobila.ToString() + "," + voznja.MusterijaZaKojuJeKreiranaVoznja + "," + voznja.Odrediste.XKoordinata + "," + voznja.Odrediste.YKoordinata + "," + voznja.Odrediste.Adresa.Ulica + "," + voznja.Odrediste.Adresa.Broj + "," + voznja.Odrediste.Adresa.NaseljenoMesto + "," + voznja.Odrediste.Adresa.PozivniBrojMesta + "," + voznja.Dispecer + "," + voznja.Vozac + "," + voznja.Iznos + "," + voznja.Komentar.Opis + "," + voznja.Komentar.DatumObjave + "," + voznja.Komentar.KorisnikKojiJeOstavioKomentar + "," + voznja.Komentar.KorisnikKojiJeOstavioKomentar + "," + voznja.Komentar.OcenaVoznje.ToString() + "," + voznja.StatusVoznje.ToString() + "," + voznja.Pomoc + Environment.NewLine;

                        if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"))
                        {
                            File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
                        }
                        else
                        {
                            File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", lineSendVoznja);
                        }

                        return Ok(musterija);
                    }
                }
            }

            return BadRequest("GRESKA");
        }
    }
}
