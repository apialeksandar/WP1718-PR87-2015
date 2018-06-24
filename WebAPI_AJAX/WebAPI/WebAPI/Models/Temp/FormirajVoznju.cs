using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enumerations;

namespace WebAPI.Models.Temp
{
    public class FormirajVoznju
    {
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string NaseljenoMesto { get; set; }
        public string PozivniBrojMesta { get; set; }
        public string Vozac { get; set; }
        public TipAutomobila ZeljeniTipAutomobila { get; set; }
        public StatusVoznje StatusVoznje { get; set; }
        public string Iznos { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public string OdOcena { get; set; }
        public string DoOcena { get; set; }

        public FormirajVoznju() { }

        public FormirajVoznju(string ulica, string broj, string naseljenoMesto, string pozivniBrojMesta, string vozac)
        {
            Ulica = ulica;
            Broj = broj;
            NaseljenoMesto = naseljenoMesto;
            PozivniBrojMesta = pozivniBrojMesta;
            Vozac = vozac;
        }
    }
}