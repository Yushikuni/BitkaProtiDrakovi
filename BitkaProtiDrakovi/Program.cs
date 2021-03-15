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
            Valecnik valecnik = new Valecnik();         // Vytvoreni noveho valecnika
            Predmet[] predmety = new Predmet[5];        // Vytvoreni pole peti objektu typu predmet

            NactiPredmety(ref predmety);
            VypisPredmety(ref predmety);

            Console.WriteLine("\n" + valecnik);
            Console.ReadLine();
        }

        // Nacte do pole predmetu, ktere obdrzi jako argument
        public static void NactiPredmety(ref Predmet[] predmety)
        {
            predmety[0] = new Predmet("Dýka", 2, 0, 0, 2, true, false);
            predmety[1] = new Predmet("Meč jednoruční", 5, 0, 0, 30, true, false);
            predmety[2] = new Predmet("Meč obouruční", 7, 1, 0, 85, true, true);
            predmety[3] = new Predmet("Plátové brnění", 0, 0, 100, 95, false, false);
            predmety[4] = new Predmet("Štít", 0, 0, 1, 50, false, false);
        }

        // Vypise pole predmetu, ktere obdrzi jako argument
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
