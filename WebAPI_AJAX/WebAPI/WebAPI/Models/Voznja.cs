using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enumerations;

namespace WebAPI.Models
{
    public class Voznja
    {
        public DateTime DatumIVremePorudzbine { get; set; }
        public Lokacija LokacijaNaKojuTaksiDolazi { get; set; }
        public TipAutomobila ZeljeniTipAutomobila { get; set; }
        public Musterija MusterijaZaKojuJeKreiranaVoznja { get; set; }
        public Lokacija Odrediste { get; set; }
        public Dispecer Dispecer { get; set; }
        public Vozac Vozac { get; set; }
        public double Iznos { get; set; }
        public Komentar Komentar { get; set; }
        public StatusVoznje StatusVoznje { get; set; }
    }
}