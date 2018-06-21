using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enumerations;

namespace WebAPI.Models
{
    public class Komentar
    {
        public string Opis { get; set; }
        public DateTime DatumObjave { get; set; }
        public string KorisnikKojiJeOstavioKomentar { get; set; }
        public DateTime VoznjaNaKojuJeKomentarOstavljen { get; set; }
        public Ocena OcenaVoznje { get; set; }

        public Komentar() { }
        public Komentar(string opis, DateTime datumObjave, string korisnikKojiJeOstavioKomentar, DateTime voznjaNaKojuJeKomentarOstavljen, Ocena ocenaVoznje)
        {
            Opis = opis;
            DatumObjave = datumObjave;
            KorisnikKojiJeOstavioKomentar = korisnikKojiJeOstavioKomentar;
            VoznjaNaKojuJeKomentarOstavljen = voznjaNaKojuJeKomentarOstavljen;
            OcenaVoznje = ocenaVoznje;
        }
    }
}