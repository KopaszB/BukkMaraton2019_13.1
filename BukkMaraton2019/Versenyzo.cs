using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton2019
{
    internal class Versenyzo
    {
        public Versenyzo(string rajtszam, string kategoria, string nev, string egyesulet, TimeSpan ido)
        {
            Rajtszam = rajtszam;
            Kategoria = kategoria;
            Nev = nev;
            Egyesulet = egyesulet;
            Ido = ido;
        }

        public string Rajtszam { get; set; }
        public string Kategoria { get; set; }
        public string Nev { get; set; }
        public string Egyesulet { get; set; }
        public TimeSpan Ido { get; set; }
        public string Tav { get
            {
                return new Versenytav(Rajtszam).ToString();
            } }


    }
}
