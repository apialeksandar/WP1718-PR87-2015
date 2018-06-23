using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SveVoznjeDispeceraController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> ret = new List<Voznja>();

            foreach (Voznja voznja in Voznje.SveVoznje)
            {
                if (voznja.Dispecer.Equals(UlogovaniKorisnici.Dispecer.KorisnickoIme))
                {
                    ret.Add(voznja);
                }
            }

            return ret;
        }
    }
}
