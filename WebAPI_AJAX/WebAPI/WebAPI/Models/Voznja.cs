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
        public string MusterijaZaKojuJeKreiranaVoznja { get; set; }
        public Lokacija Odrediste { get; set; }
        public string Dispecer { get; set; }
        public string Vozac { get; set; }
        public double Iznos { get; set; }
        public Komentar Komentar { get; set; }
        public StatusVoznje StatusVoznje { get; set; }
        public int Pomoc { get; set; }

        public Voznja() {}
        public Voznja(DateTime datumIVremePorudzbine, Lokacija lokacijaNaKojuTaksiDolazi, TipAutomobila zeljeniTipAutomobila, string musterijaZaKojuJeKreiranaVoznja, Lokacija odrediste, string dispecer, string vozac, double iznos, Komentar komentar, StatusVoznje statusVoznje, int pomoc)
        {
            DatumIVremePorudzbine = datumIVremePorudzbine;
            LokacijaNaKojuTaksiDolazi = lokacijaNaKojuTaksiDolazi;
            ZeljeniTipAutomobila = zeljeniTipAutomobila;
            MusterijaZaKojuJeKreiranaVoznja = musterijaZaKojuJeKreiranaVoznja;
            Odrediste = odrediste;
            Dispecer = dispecer;
            Vozac = vozac;
            Iznos = iznos;
            Komentar = komentar;
            StatusVoznje = statusVoznje;
            Pomoc = pomoc;
        }
    }
}