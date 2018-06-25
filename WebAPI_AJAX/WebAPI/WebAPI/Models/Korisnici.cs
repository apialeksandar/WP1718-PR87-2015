using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enumerations;

namespace WebAPI.Models
{
    public class Korisnici
    {
        public static List<Musterija> Musterije { get; set; }
        public static List<Dispecer> Dispeceri { get; set; }
        public static List<Vozac> Vozaci { get; set; }

        public static void Create()
        {
            Musterije = new List<Musterija>();
            Dispeceri = new List<Dispecer>();
            Vozaci = new List<Vozac>();

            Musterije.Add(new Musterija("musterija", "12345", "Mušterija", "Mušterić", Enumerations.Pol.Zenski, "0365995931198", "0381654009687", "musterija@yahoo.com", Enumerations.Uloga.Musterija));

            string[] lines = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\dispeceri.txt");

            Pol p;

            if (lines[4].Equals("Muski"))
            {
                p = Pol.Muski;
            }
            else
                p = Pol.Zenski;

            Dispeceri.Add(new Dispecer(lines[0], lines[1], lines[2], lines[3], p, lines[5], lines[6], lines[7], Uloga.Dispecer));

            if (lines[14].Equals("Muski"))
            {
                p = Pol.Muski;
            }
            else
                p = Pol.Zenski;

            Dispeceri.Add(new Dispecer(lines[8], lines[9], lines[10], lines[11], p, lines[13], lines[14], lines[15], Uloga.Dispecer));

            Vozaci.Add(new Vozac("vozac", "vozac", "vozac", "vozac", Pol.Muski, "2405996820189", "066064958", "vozac@gmail.com", Uloga.Vozac, new Lokacija("44°49'04.127", "44°49'04.127", new Adresa("PocetnaUlica", 5, "Novi Sad", "21000")), new Automobil("vozac", "2005", "NS108-TX", 10, TipAutomobila.PutnickiAutomobil)));
        }
    }
}