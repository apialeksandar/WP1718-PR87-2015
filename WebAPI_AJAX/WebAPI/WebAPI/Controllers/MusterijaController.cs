using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class MusterijaController : ApiController
    {
        [ResponseType(typeof(Musterija))]
        public IHttpActionResult Post(Musterija korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UlogovaniKorisnici.Musterija = new Musterija(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga);
            
            foreach(Musterija musterija in Korisnici.Musterije)
            {
                if (musterija.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    Korisnici.Musterije.Remove(musterija);

                    string[] linesMusterija = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaKorisnici.txt");
                    for (int i = 0; i < linesMusterija.Count(); i++)
                    {
                        string[] line = linesMusterija[i].Split(',');

                        if (musterija.KorisnickoIme.Equals(line[0]))
                        {
                            var file = new List<string>(System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaKorisnici.txt"));
                            file.RemoveAt(i);
                            File.WriteAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaKorisnici.txt", file.ToArray());
                        }
                    }

                    Korisnici.Musterije.Add(korisnik);

                    string lineSendMusterija = String.Empty;
                    lineSendMusterija = korisnik.KorisnickoIme + "," + korisnik.Lozinka + "," + korisnik.Ime + "," + korisnik.Prezime + "," + korisnik.Pol.ToString() + "," + korisnik.Jmbg + "," + korisnik.KontaktTelefon + "," + korisnik.Email + "," + korisnik.Uloga.ToString() + Environment.NewLine;

                    if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaKorisnici.txt"))
                    {
                        File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaKorisnici.txt", lineSendMusterija);
                    }
                    else
                    {
                        File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaKorisnici.txt", lineSendMusterija);
                    }

                    break;
                }
            }

            return CreatedAtRoute("DefaultApi", new { korisnickoIme = korisnik.KorisnickoIme }, korisnik);
        }

        public Musterija Get()
        {
            return UlogovaniKorisnici.Musterija;
        }
    }
}
