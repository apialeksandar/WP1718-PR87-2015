using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Adresa
    {
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string NaseljenoMesto { get; set; }
        public string PozivniBrojMesta { get; set; }

        public Adresa() { }
        public Adresa(string ulica, int broj, string naseljenoMesto, string pozivniBrojMesta)
        {
            Ulica = ulica;
            Broj = broj;
            NaseljenoMesto = naseljenoMesto;
            PozivniBrojMesta = pozivniBrojMesta;
        }
    }
}