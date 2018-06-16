using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enumerations;

namespace WebAPI.Models
{
    public class Dispecer : Korisnik
    {
        public Dispecer() { }
        public Dispecer(string korisnickoIme, string lozinka, string ime, string prezime, Pol pol, string jmbg, string kontaktTelefon, string email, Uloga uloga)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Jmbg = jmbg;
            KontaktTelefon = kontaktTelefon;
            Email = email;
            Uloga = uloga;
            Voznje = new List<Voznja>();
        }
    }
}