using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SortirajDatumVozacController : ApiController
    {
        public List<Voznja> Post()
        {
            List<Voznja> ret = new List<Voznja>();
            ret = UlogovaniKorisnici.Vozac.Voznje;

            foreach (Voznja voznja in ret)
            {
                ret.Sort((x, y) => DateTime.Compare(y.DatumIVremePorudzbine, x.DatumIVremePorudzbine));
            }

            return ret;
        }
    }
}
