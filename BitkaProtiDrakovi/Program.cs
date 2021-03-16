using System;

namespace BitkaProtiDrakovi
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            Valecnik valecnik = new Valecnik(ref rnd);         // Vytvoreni noveho valecnika
            Drak drak = new Drak(ref rnd);
            Predmet[] predmety = new Predmet[5];        // Vytvoreni pole peti objektu typu predmet

            //VypisPribeh();
            NactiPredmety(ref predmety);
            VypisPredmety(ref predmety);
            Console.WriteLine("\n" + valecnik);         // Zobrazí staty válečníka před nasazením předmětů
            Console.WriteLine("\n" + drak);
            NasadPredmety(ref valecnik, ref predmety);
            valecnik.PrepocitejStatyPoNasazeniPredmetu();

            Console.WriteLine("\n" + valecnik);
            Console.ReadLine();
        }

        // Vypíše předmluvu příběhu
        public static void VypisPribeh()
        {
            Console.WriteLine("Kalítor je království, kde vládnou ženy. Jako dobrodruh, který se touží usadit v hlavním městě Zaa.) \n" +
                              "Musíš ale splnit královnin úkol, a to zachránit jediného potomka, tedy toho legitimního (klepy), z věže v předaleké zemi, kam ho unesl tmavý drak.\n" +
                              "Teď si říkáš, jak to vím, co? Viděla jsem takového létajícího ještěra v noci. Mělo to lehký nádech tmy a něčeho asi zeleného. Navíc takové ještěrky mají rady vysoká místa.\n" +
                              "Nebo snad ne? Tak co tu ještě okouníš. Upaluj! ");
        }

        // Nasadí válečníkovy předměty
        public static void NasadPredmety(ref Valecnik valecnik, ref Predmet[] predmety)
        {
            int idx;        // index zvoleného předmětu

            while (true)
            {
                Console.WriteLine("\nZadej index předmětu, který chceš nasadit \n(-1 pro ukončení zadávání)\n(5 pro vypsání seznamu předmětů): ");
                idx = Convert.ToInt32(Console.ReadLine());

                // Kontroluje, zda bylo požádáno o ukončení nasazování předmětů
                if (idx == -1)
                {
                    break;
                }

                // Kontroluje, zda bylo požádáno u opětovný výpis předmětů
                if (idx == 5)
                {
                    VypisPredmety(ref predmety);
                    continue;
                }

                // Kontroluje, zda byl úspěšně nasazen předmět a nasazuje předmět
                try
                {
                    if (valecnik.NasadPredmet(ref predmety[idx]))
                    {
                        Console.WriteLine($"Předmět {predmety[idx].Nazev} byl úspěšně nasazen!");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Zadaný index neodpovídá žádnému předmětu");
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
