using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Enumerations;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class VoznjeController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> ret = new List<Voznja>();

            foreach(Voznja voznja in UlogovaniKorisnici.Musterija.Voznje)
            {
                if(voznja.StatusVoznje == StatusVoznje.NaCekanju)
                {
                    ret.Add(voznja);
                }
            }
            return ret;
        }
    }
}
