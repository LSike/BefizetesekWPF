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
        public Befizetes(string nev, int osszeg)
        {
            Nev = nev;
            Osszeg = osszeg;
        }

        public Befizetes(string sor)
        {
            string[] adatok = sor.Split(';');
            Nev = adatok[0];
            Osszeg = int.Parse(adatok[1]);
        }

        public string Nev { get; set; }
        public int Osszeg { get; set; }

        public override string ToString()
        {
            return $"Név: {Nev}, összeg: {Osszeg} Ft";
        }
    }
}
