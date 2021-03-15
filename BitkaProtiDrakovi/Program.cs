using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitkaProtiDrakovi
{
    class Program
    {
        static void Main()
        {
            Valecnik valecnik = new Valecnik();
            Drak drak = new Drak();
            Predmet[] predmety = new Predmet[5];

            predmety[0] = new Predmet("Dýka", 2, 0, 0, 2, true, false);
            predmety[1] = new Predmet("Meč jednoruční", 5, 0, 0, 30, true, false);
            predmety[2] = new Predmet("Meč obouruční", 7, 1, 0, 85, true, true);
            predmety[3] = new Predmet("Plátové brnění", 0, 0, 100, 95, false, false);
            predmety[4] = new Predmet("Štít", 0, 0, 1, 50, false, false);

            VypisPredmety(ref predmety);

            Console.WriteLine("\n" + valecnik);
            Console.WriteLine("\n" + drak);




            //hra samotna:
            //uvod
            Console.WriteLine("\n Kalítor je království, kde vládnou ženy.\n Jako dobrodruh, který se touží usadit v hlavním městě Zaa.\n" +
                " Musíš ale splnit královnin úkol, a to zachránit jediného potomka,\n tedy toho legitimního, z věže v předaleké zemi, kam ho unesl tmavý drak.\n" +
                " Teď si říkáš, jak to vím, co? Viděla jsem takového létajícího ještěra v noci.\n" +
                " Mělo to lehký nádech tmy a něčeho asi zeleného. Navíc takové ještěrky mají rady vysoká místa. \n Nebo snad ne?\n Tak co tu ještě okouníš. Upaluj!\n");




            Console.ReadLine();
        }

        public static void VypisPredmety(ref Predmet[] predmety)
        {
            // Formatovany vypis hlavicky tabulky se soubory
            Console.WriteLine(string.Format("{0, -10}", "Index") + 
                              string.Format("{0, -20}", "Název") + 
                              string.Format("{0, -10}", "Síla") +
                              string.Format("{0, -10}", "Útočnost") +
                              string.Format("{0, -10}", "Obrana") +
                              string.Format("{0, -10}", "Váha"));

            for (var i = 0; i < predmety.Length; i++)
            {
                Console.Write(string.Format("{0, -10}", i));    // Vypise index predmetu
                Console.WriteLine(predmety[i]);                 // Vypise predmet
            }
        }
    }
}
