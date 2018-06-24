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
    public class PretragaOcenaMusterijaController : ApiController
    {
        public List<Voznja> Post(FormirajVoznju temp)
        {
            string pom = "";
            List<Voznja> ret = new List<Voznja>();

            if (!temp.OdOcena.Equals("Izaberi..."))
            {
                if (!temp.DoOcena.Equals("Izaberi..."))
                {
                    pom = "od-do";
                }
                else
                    pom = "od";
            }
            else
            {
                if (!temp.DoOcena.Equals("Izaberi..."))
                {
                    pom = "do";
                }
                else
                {
                    ret = new List<Voznja>();
                }
            }

            if (pom.Equals("od"))
            {
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if ((int)voznja.Komentar.OcenaVoznje >= int.Parse(temp.OdOcena))
                        ret.Add(voznja);
                }
            }
            else if (pom.Equals("do"))
            {
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if ((int)voznja.Komentar.OcenaVoznje <= int.Parse(temp.DoOcena))
                        ret.Add(voznja);
                }
            }
            else if (pom.Equals("od-do"))
            {
                foreach (Voznja voznja in Voznje.SveVoznje)
                {
                    if ((int)voznja.Komentar.OcenaVoznje >= int.Parse(temp.OdOcena) && (int)voznja.Komentar.OcenaVoznje <= int.Parse(temp.DoOcena))
                        ret.Add(voznja);
                }
            }

            return ret;
        }
    }
}
