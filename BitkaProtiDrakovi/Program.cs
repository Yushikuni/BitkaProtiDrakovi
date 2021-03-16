using System;

namespace BitkaProtiDrakovi
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            Valecnik valecnik = new Valecnik(ref rnd);         // Vytvoreni noveho valecnika
            Drak drak = new Drak(ref rnd);                      // Vytvoření nového draka
            Predmet[] predmety = new Predmet[5];        // Vytvoreni pole peti objektu typu predmet
            int volba;                                  // Proměnná pro ukládání hráčovy volby užité v menu hry

            NactiPredmety(ref predmety);    // Načte předměty do pole předmětů
            VypisPribeh();                  // Vypíše předmluvu k příběhu do konzole

            while (true)
            {
                VypisMenu();
                Console.Write("\nZadej svou volbu: ");
                volba = int.Parse(Console.ReadLine());

                switch (volba)
                {
                    case 0:
                        Console.WriteLine("Hra se ukončí stisknutím klávesy Enter");
                        Console.ReadLine();
                        return;
                    case 1:
                        Console.WriteLine("\n" + valecnik);
                        break;
                    case 2:
                        Console.WriteLine("\n" + drak);
                        break;
                    case 3:
                        VypisPredmety(ref predmety);
                        break;
                    case 4:
                        NasadPredmety(ref valecnik, ref predmety);
                        valecnik.PrepocitejStatyPoNasazeniPredmetu();
                        break;
                    case 5:
                        Boj(ref valecnik, ref drak);
                        break;
                    default:
                        Console.WriteLine("Byla zadána hodnota mimo rozsah. Ukončuji program po stisknutím klávesy Enter.");
                        Console.ReadLine();
                        return;
                }
            }
        }

        // Vypíše menu ovládání hry
        public static void VypisMenu()
        {
            Console.WriteLine("\n" + new string('-', 12) + " MENU " + new string('-', 12));
            Console.WriteLine("0 - Ukonči hru");
            Console.WriteLine("1 - Vypiš staty hráče");
            Console.WriteLine("2 - Vypiš staty draka");
            Console.WriteLine("3 - Vypiš seznam předmětů");
            Console.WriteLine("4 - Nasaď předměty");
            Console.WriteLine("5 - Bojuj s drakem");
            Console.WriteLine(new string('-', 30));
        }

        // Simuluje boj mezi drakem a hráčem
        public static void Boj(ref Valecnik valecnik, ref Drak drak)
        {
            Random rnd = new Random();
            int utoci = 1;

            while (true)
            {
                if (valecnik.ZobraziSeVak())    // Zvítězil hráč
                {
                    Console.WriteLine("Použil jsi sušenky Milánek, drak Ti vydal prince bez boje!");
                    break;  
                }

                if (!valecnik.JeNazivu())   // Zvítězil drak
                {
                    Console.WriteLine("Zemřel jsi krutou a bolestivou smrtí!");
                    break;  
                }

                if (!drak.JeNazivu())   // Zvítězil hráč
                {
                    Console.WriteLine("Porazil jsi draka a zachránil prince!");
                    break;  
                }

                if (utoci == 1) // Útočí hráč
                {
                    drak.UtrziZraneni(valecnik.Utok());
                    Console.WriteLine("Drak utržil zranění!");
                    Console.WriteLine($"Drakovi zbývá {drak.Zivoty} životů.");
                    utoci = 2;  // Další v pořadí útočení bude drak
                }
                else // Útočí drak
                {
                    if (valecnik.UhybPredUtokem(ref rnd))
                    {
                        Console.WriteLine("Hráč se úspěšně vyhnul zranění!");
                        Console.WriteLine($"Hráčovi zbývá {valecnik.Zivoty} životů.");
                    }
                    else
                    {
                        valecnik.UtrziZraneni(drak.Utok());
                        Console.WriteLine("Hráč utržil zranění!");
                        Console.WriteLine($"Hráčovi zbývá {valecnik.Zivoty} životů.");
                    }

                    utoci = 1;  // Další v pořadí útočení bude hráč
                }
            }
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
