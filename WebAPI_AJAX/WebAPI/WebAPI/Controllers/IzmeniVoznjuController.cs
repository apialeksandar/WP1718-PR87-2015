using System;
using System.Collections.Generic;
using System.IO;
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

            string[] linesVoznja = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt");
            for (int i = 0; i < linesVoznja.Count(); i++)
            {
                string[] line = linesVoznja[i].Split(',');

                /*if(temp[id].DatumIVremePorudzbine.Equals(DateTime.Parse(line[i])))
                {
                    var file = new List<string>(System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt"));
                    file.RemoveAt(i);
                    File.WriteAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt", file.ToArray());
                }*/
            }

            UlogovaniKorisnici.Musterija.Voznje.Remove(temp[id]);
            Voznje.SveVoznje.Remove(temp[id]);

            return temp[id];
        }
    }
}
