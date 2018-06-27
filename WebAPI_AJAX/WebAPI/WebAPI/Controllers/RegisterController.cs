using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RegisterController : ApiController
    {
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult Post(Musterija korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int dPom = 0;
            int vPom = 0;
            int mPom = 0;

            foreach(Dispecer dispecer in Korisnici.Dispeceri)
            {
                if (!dispecer.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                    dPom++;
            }

            foreach (Vozac vozac in Korisnici.Vozaci)
            {
                if (!vozac.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                    vPom++;
            }

            foreach (Musterija musterija in Korisnici.Musterije)
            {
                if (!musterija.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                    mPom++;
            }

            if(Korisnici.Dispeceri.Count == dPom)
            {
                if(Korisnici.Vozaci.Count == vPom)
                {
                    if(Korisnici.Musterije.Count == mPom)
                    {
                        korisnik.Voznje = new List<Voznja>();
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

                        return CreatedAtRoute("DefaultApi", new { korisnickoIme = korisnik.KorisnickoIme }, korisnik);
                    }
                    else
                        return BadRequest("Korisnik vec postoji");
                }
                else
                    return BadRequest("Korisnik vec postoji");
            }
            else
                return BadRequest("Korisnik vec postoji");
        }
    }
}
