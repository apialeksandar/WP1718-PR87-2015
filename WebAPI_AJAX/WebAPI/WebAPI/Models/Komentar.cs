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
        public Korisnik KorisnikKojiJeOstavioKomentar { get; set; }
        public Voznja VoznjaNaKojuJeKomentarOstavljen { get; set; }
        public Ocena OcenaVoznje { get; set; }

        public Komentar() { }
        public Komentar(string opis, DateTime datumObjave, Korisnik korisnikKojiJeOstavioKomentar, Voznja voznjaNaKojuJeKomentarOstavljen, Ocena ocenaVoznje)
        {
            Opis = opis;
            DatumObjave = datumObjave;
            KorisnikKojiJeOstavioKomentar = korisnikKojiJeOstavioKomentar;
            VoznjaNaKojuJeKomentarOstavljen = voznjaNaKojuJeKomentarOstavljen;
            OcenaVoznje = ocenaVoznje;
        }
    }
}