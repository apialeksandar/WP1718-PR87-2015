using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Vozaci
    {
        public static List<Vozac> Vozacii { get; set; }

        public static void Create()
        {
            Vozacii = new List<Vozac>();
        }
    }
}