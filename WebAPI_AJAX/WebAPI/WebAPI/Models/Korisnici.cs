using System;
using System.Collections.Generic;
using System.IO;
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

            string[] linesMusterija = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaKorisnici.txt");
            for (int i = 0; i < linesMusterija.Count(); i++)
            {
                string[] line = linesMusterija[i].Split(',');
                Pol pol;

                if (line[4].Equals("Muski"))
                {
                    pol = Pol.Muski;
                }
                else
                    pol = Pol.Zenski;
                Musterije.Add(new Musterija(line[0], line[1], line[2], line[3], pol, line[5], line[6], line[7], Uloga.Musterija));
            }

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

            int k = 0;
            foreach (Dispecer dispecer in Dispeceri)
            {
                string lineSendDispecer = String.Empty;
                lineSendDispecer = dispecer.KorisnickoIme + "," + dispecer.Lozinka + "," + dispecer.Ime + "," + dispecer.Prezime + "," + dispecer.Pol.ToString() + "," + dispecer.Jmbg + "," + dispecer.KontaktTelefon + "," + dispecer.Email + "," + dispecer.Uloga.ToString() + Environment.NewLine;

                if (!File.Exists(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaDispeceri.txt"))
                {
                    File.WriteAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaDispeceri.txt", lineSendDispecer);
                }
                else
                {
                    if(k == 0)
                    {
                        System.IO.File.WriteAllText((@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaDispeceri.txt"), string.Empty);
                        k++;
                    }
                    File.AppendAllText(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaDispeceri.txt", lineSendDispecer);
                }
            }

            string[] linesVozac = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVozaci.txt");
            for (int i = 0; i < linesVozac.Count(); i++)
            {
                string[] line = linesVozac[i].Split(',');
                Pol pol;
                TipAutomobila auto;
                bool slobodan;

                if (line[4].Equals("Muski"))
                {
                    pol = Pol.Muski;
                }
                else
                    pol = Pol.Zenski;

                if (line[19].Equals("PutnickiAutomobil"))
                {
                    auto = TipAutomobila.PutnickiAutomobil;
                }
                else
                    auto = TipAutomobila.KombiVozilo;

                if (line[20].Equals("True"))
                {
                    slobodan = true;
                }
                else
                    slobodan = false;
                Vozaci.Add(new Vozac(line[0], line[1], line[2], line[3], pol, line[5], line[6], line[7], Uloga.Vozac, new Lokacija(line[9], line[10], new Adresa(line[11], int.Parse(line[12]), line[13], line[14])), new Automobil(line[15], line[16], line[17], int.Parse(line[18]), auto), slobodan, double.Parse(line[21])));
            }
        }
    }
}