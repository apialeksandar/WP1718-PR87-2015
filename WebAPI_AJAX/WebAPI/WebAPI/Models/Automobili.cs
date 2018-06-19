using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Automobili
    {
        public static List<Automobil> Vozila { get; set; }

        public static void Create()
        {
            Vozila = new List<Automobil>();

            for(int i = 0; i < 20; i++)
            {
                Vozila.Add(new Automobil("", (2000 + i).ToString(), "NS" + (170 + i).ToString() + "-TX", i + 1, Enumerations.TipAutomobila.PutnickiAutomobil));
            }
        }
    }
}