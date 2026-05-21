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
            //Kiir();

            //4.feladat
            int nemBefutok = 691-versenyzok.Count;
            Console.WriteLine($"4. feladat: Versenytávot nem teljesítők: {(double)nemBefutok/691*100}%");

            //5.feladat
            int noiVersenyzo = 0;
            foreach (var item in versenyzok)
            {
                if (item.Tav=="Rövid" && item.Kategoria.Last()=='n')
                {
                    noiVersenyzo++;
                }
            }
            Console.WriteLine($"5. feladat: Női versenyzők száma a rövidtávú versenyen: {noiVersenyzo} fő");

            //6.feladat
            Console.WriteLine($"6. feladat: {(tobbMintHatOra()?"Volt ilyen versenyző":"Nem volt ilyen versenyző")}");

            //7.feladat
            TimeSpan minIdo = TimeSpan.MaxValue;
            Versenyzo gyoztesRovidFF = versenyzok[0];
            foreach (var item in versenyzok)
            {
                if (item.Tav=="Rövid" && item.Kategoria=="ff" && item.Ido<minIdo)
                {
                    minIdo = item.Ido;
                    gyoztesRovidFF = item;
                }
            }
            Console.WriteLine("7. feladat: Afelnőtt férfi (ff) kategória győztese rövid távon ");
            Console.WriteLine($"\tRajtszám: {gyoztesRovidFF.Rajtszam}" +
                $"\n\tNév: {gyoztesRovidFF.Nev}" +
                $"\n\tEgyesület: {gyoztesRovidFF.Egyesulet}" +
                $"\n\tIdő: {gyoztesRovidFF.Ido}");

            //8.feladat
            Dictionary<string,int> statisztika = new Dictionary<string,int>();
            foreach (var item in versenyzok)
            {
                if (item.Kategoria.EndsWith("f"))
                {
                    if (statisztika.ContainsKey(item.Kategoria))
                    {
                        statisztika[item.Kategoria]++;
                    }
                    else
                    {
                        statisztika.Add(item.Kategoria, 1);
                    }
                }
            }
            Console.WriteLine("8. feladat: Statisztika");
            foreach (var item in statisztika) 
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}fő");
            }
            Console.ReadKey();
        }

        private static bool tobbMintHatOra()
        {
            bool eredmeny = false;
            foreach (var item in versenyzok)
            {
                if (item.Ido.TotalHours>6)
                {
                    eredmeny = true;
                    break;
                }
            }
            return eredmeny;
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
