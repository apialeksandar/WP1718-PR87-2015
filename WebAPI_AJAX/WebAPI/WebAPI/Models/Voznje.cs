using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enumerations;

namespace WebAPI.Models
{
    public class Voznje
    {
        public static List<Voznja> SveVoznje { get; set; }

        public static void Create()
        {
            SveVoznje = new List<Voznja>();

            string[] linesVoznja = System.IO.File.ReadAllLines(@"E:\FAX\III godina\2. semestar\Web programiranje [6 ESPB]\projekat\WP1718-PR87-2015\WebAPI_AJAX\WebAPI\WebAPI\bazaVoznje.txt");
            for (int i = 0; i < linesVoznja.Count(); i++)
            {
                string[] line = linesVoznja[i].Split(',');
                
                TipAutomobila auto;
                Ocena ocena;
                StatusVoznje status;

                if (line[7].Equals("PutnickiAutomobil"))
                {
                    auto = TipAutomobila.PutnickiAutomobil;
                }
                else
                    auto = TipAutomobila.KombiVozilo;

                if (line[22].Equals("Nula"))
                {
                    ocena = Ocena.Nula;
                }
                else if (line[22].Equals("Jedan"))
                {
                    ocena = Ocena.Jedan;
                }
                else if (line[22].Equals("Dva"))
                {
                    ocena = Ocena.Dva;
                }
                else if (line[22].Equals("Tri"))
                {
                    ocena = Ocena.Tri;
                }
                else if (line[22].Equals("Cetiri"))
                {
                    ocena = Ocena.Cetiri;
                }
                else
                {
                    ocena = Ocena.Pet;
                }


                if (line[23].Equals("NaCekanju"))
                {
                    status = StatusVoznje.NaCekanju;
                }
                else if (line[23].Equals("Formirana"))
                {
                    status = StatusVoznje.Formirana;
                }
                else if (line[23].Equals("Obradjena"))
                {
                    status = StatusVoznje.Obradjena;
                }
                else if (line[23].Equals("Prihvacena"))
                {
                    status = StatusVoznje.Prihvacena;
                }
                else if (line[23].Equals("Otkazana"))
                {
                    status = StatusVoznje.Otkazana;
                }
                else if (line[23].Equals("Neuspesna"))
                {
                    status = StatusVoznje.Neuspesna;
                }
                else
                {
                    status = StatusVoznje.Uspesna;
                }

                SveVoznje.Add(new Voznja(DateTime.Parse(line[0]), new Lokacija(line[1], line[2], new Adresa(line[3], int.Parse(line[4]), line[5], line[6])), auto, line[8], new Lokacija(line[9], line[10], new Adresa(line[11], int.Parse(line[12]), line[13], line[14])), line[15], line[16], double.Parse(line[17]), new Komentar(line[18], DateTime.Parse(line[19]), line[20], DateTime.Parse(line[21]), ocena), status, int.Parse(line[24])));
            }
        }
    }
}