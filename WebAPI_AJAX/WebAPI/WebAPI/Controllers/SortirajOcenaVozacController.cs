using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SortirajOcenaVozacController : ApiController
    {
        public List<Voznja> Post()
        {
            List<Voznja> temp = new List<Voznja>();
            temp = UlogovaniKorisnici.Vozac.Voznje;
            List<Voznja> ret = new List<Voznja>();

            for (int i = 5; i >= 0; i--)
            {
                foreach (Voznja voznja in temp)
                {
                    if (voznja.Komentar == null)
                    {

                    }
                    else
                    {
                        if ((int)voznja.Komentar.OcenaVoznje == i)
                        {
                            ret.Add(voznja);
                        }
                    }
                }
            }

            return ret;
        }
    }
}
