using System;

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
            
            NasadPredmety(ref valecnik, ref predmety);
            valecnik.PrepocitejStatyPoNasazeniPredmetu();

            Console.WriteLine("\n" + valecnik);
            Console.ReadLine();
        }

        // Nasadí válečníkovy předměty
        public static void NasadPredmety(ref Valecnik valecnik, ref Predmet[] predmety)
        {
            int idx;        // index zvoleného předmětu

            while (true)
            {
                Console.WriteLine("\nZadej index předmětu, který chceš nasadit \n(-1 pro ukončení zadávání)\n(6 pro vypsání seznamu předmětů): ");
                idx = Convert.ToInt32(Console.ReadLine());

                // Kontroluje, zda bylo požádáno o ukončení nasazování předmětů
                if (idx == -1)
                {
                    break;
                }

                // Kontroluje, zda bylo požádáno u opětovný výpis předmětů
                if (idx == 6)
                {
                    VypisPredmety(ref predmety);
                    continue;
                }

                // Kontroluje, zda nebylo překročeno rozmezí pro volbu v menu
                if (idx < 0 || idx > 6)
                {
                    throw new Exception("Byl zadán neodpovídající index předmětu!");
                }

                // Kontroluje, zda byl úspěšně nasazen předmět a nasazuje předmět
                try
                {
                    if (valecnik.NasadPredmet(ref predmety[idx]))
                    {
                        Console.WriteLine($"Předmět {predmety[idx].Nazev} byl úspěšně nasazen!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
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
            Console.WriteLine($"{"Index",-10}" +
                              $"{"Název",-20}" +
                              $"{"Síla",-10}" +
                              $"{"Útočnost",-10}" +
                              $"{"Obrana",-10}" +
                              $"{"Váha",-10}");

            for (var i = 0; i < predmety.Length; i++)
            {
                Console.Write($"{i,-10}");          // Vypise index predmetu
                Console.WriteLine(predmety[i]);     // Vypise predmet
            }
        }
    }
}
