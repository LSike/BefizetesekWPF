using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefizetesekWPF
{
    internal class Befizetes
    {
        public Befizetes() { }
        public Befizetes(int id, string nev, int osszeg)
        {
            Id = id;
            Nev = nev;
            Osszeg = osszeg;
        }

        public Befizetes(string sor)
        {
            string[] adatok = sor.Split(';');
            Id = int.Parse(adatok[0]);
            Nev = adatok[1];
            Osszeg = int.Parse(adatok[2]);
        }

        public int Id { get; set; }
        public string Nev { get; set; }
        public int Osszeg { get; set; }

        public override string ToString()
        {
            return $"Név: {Nev}, összeg: {Osszeg} Ft";
        }
    }
}
