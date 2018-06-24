using System;
using System.Collections.Generic;
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
