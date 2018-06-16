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
    public class MusterijaController : ApiController
    {
        public RedirectResult Post([FromBody]Korisnik korisnik)
        {
            UlogovaniKorisnici.Musterija = korisnik as Musterija;
            return Redirect("http://localhost:10482/HtmlMusterija.html");
        }

        public Musterija Get()
        {
            return UlogovaniKorisnici.Musterija;
        }
    }
}
