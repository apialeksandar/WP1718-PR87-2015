using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.Temp;

namespace WebAPI.Controllers
{
    public class FiltrirajVozacController : ApiController
    {
        public List<Voznja> Post(FormirajVoznju forma)
        {
            List<Voznja> ret = new List<Voznja>();

            foreach (Voznja voznja in UlogovaniKorisnici.Vozac.Voznje)
            {
                if (voznja.StatusVoznje.Equals(forma.StatusVoznje))
                    ret.Add(voznja);
            }

            return ret;
        }
    }
}
