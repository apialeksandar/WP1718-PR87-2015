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
        public DateTime GodisteAutomobila { get; set; }
        public string BrojRegistarskeOznake { get; set; }
        public int BrojTaksiVozila { get; set; }
        public TipAutomobila TipAutomobila { get; set; }
    }
}