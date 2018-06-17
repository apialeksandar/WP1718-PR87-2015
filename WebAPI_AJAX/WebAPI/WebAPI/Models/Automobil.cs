using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enumerations;

namespace WebAPI.Models
{
    public class Automobil
    {
        public Vozac Vozac { get; set; }
        public string GodisteAutomobila { get; set; }
        public string BrojRegistarskeOznake { get; set; }
        public int BrojTaksiVozila { get; set; }
        public TipAutomobila TipAutomobila { get; set; }
        public bool Slobodan { get; set; }

        public Automobil() { }
        public Automobil(Vozac vozac, string godisteAutomobila, string brojRegistarskeOznake, int brojTaksiVozila, TipAutomobila tipAutomobila)
        {
            Vozac = vozac;
            GodisteAutomobila = godisteAutomobila;
            BrojRegistarskeOznake = brojRegistarskeOznake;
            BrojTaksiVozila = BrojTaksiVozila;
            TipAutomobila = tipAutomobila;
            Slobodan = true;
        }
    }
}