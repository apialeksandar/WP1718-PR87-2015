using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznje
    {
        public static List<Voznja> SveVoznje { get; set; }

        public static void Create()
        {
            SveVoznje = new List<Voznja>();
        }
    }
}