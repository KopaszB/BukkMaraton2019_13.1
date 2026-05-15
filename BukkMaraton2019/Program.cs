using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BukkMaraton2019
{
    internal class Program
    {
        static List<Versenyzo> versenyzok = new List<Versenyzo>();
        static void Main(string[] args)
        {
            AdatBeolvas();
            Kiir();


            Console.ReadKey();
        }

        private static void Kiir()
        {
            foreach (var item in versenyzok)
            {
                Console.WriteLine($"{item.Rajtszam,-10}{item.Nev,-25}{item.Tav}");
            }
        }

        private static void AdatBeolvas()
        {
            try
            {
                using (StreamReader olvas = new StreamReader("bukkm2019.txt"))
                {
                    olvas.ReadLine();
                    while (!olvas.EndOfStream)
                    {
                        string[] darabol = olvas.ReadLine().Split(';');
                        var egyVersenyzo = new Versenyzo(darabol[0], darabol[1], darabol[2], darabol[3], TimeSpan.Parse(darabol[4]));
                        versenyzok.Add(egyVersenyzo);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Hiba: " + ex.Message);
            }
            
        }
    }
}
