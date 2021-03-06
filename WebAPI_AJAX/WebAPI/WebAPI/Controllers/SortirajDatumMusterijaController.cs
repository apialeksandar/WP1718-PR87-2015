﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SortirajDatumMusterijaController : ApiController
    {
        public List<Voznja> Post()
        {
            List<Voznja> ret = new List<Voznja>();

            foreach(Voznja voznja in Voznje.SveVoznje)
            {
                if (voznja.MusterijaZaKojuJeKreiranaVoznja.Equals(UlogovaniKorisnici.Musterija.KorisnickoIme))
                {
                    ret.Add(voznja);
                }
            }

            foreach(Voznja voznja in ret)
            {
                ret.Sort((x, y) => DateTime.Compare(y.DatumIVremePorudzbine, x.DatumIVremePorudzbine));
            }

            return ret;
        }
    }
}
