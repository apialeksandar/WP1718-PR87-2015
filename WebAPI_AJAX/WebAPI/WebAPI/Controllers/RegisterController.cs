using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RegisterController : ApiController
    {
        public RedirectResult Post([FromBody]Korisnik korisnik)
        {
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
                        Korisnici.Musterije.Add(korisnik);
                        return Redirect("http://localhost:10482/index.html");
                    }
                    else
                        return Redirect("http://localhost:10482/HtmlError.html");
                }
                else
                    return Redirect("http://localhost:10482/HtmlError.html");
            }
            else
                return Redirect("http://localhost:10482/HtmlError.html");













            if (!Korisnici.Dispeceri.Contains(korisnik))
            {
                if(!Korisnici.Vozaci.Contains(korisnik))
                {
                    if(!Korisnici.Musterije.Contains(korisnik))
                    {
                        
                    }
                        
                    else
                        return Redirect("http://localhost:10482/HtmlError.html");
                }
                return Redirect("http://localhost:10482/HtmlError.html");

            }
            else
                return Redirect("http://localhost:10482/HtmlError.html");
        }
    }
}
