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
    public class IzmeniVoznjuController : ApiController
    {
        public Voznja Post(Korisnik korisnik)
        {
            int id = int.Parse(korisnik.Ime);

            List<Voznja> temp = new List<Voznja>();

            foreach(Voznja voznja in UlogovaniKorisnici.Musterija.Voznje)
            {
                if(voznja.StatusVoznje.Equals(StatusVoznje.NaCekanju))
                {
                    temp.Add(voznja);
                }
            }

            UlogovaniKorisnici.Musterija.Voznje.Remove(temp[id]);
            Voznje.SveVoznje.Remove(temp[id]);

            return temp[id];
        }
    }
}
