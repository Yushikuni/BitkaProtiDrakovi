using System;

namespace BitkaProtiDrakovi
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();                              // Vytvoření nové instance generátoru pseudonáhodných čísel
            Valecnik valecnik = new Valecnik(ref rnd);              // Vytvoreni noveho valecnika
            Drak drak = new Drak(ref rnd);                          // Vytvoření nového draka
            Predmet[] predmety = new Predmet[5];                    // Vytvoreni pole peti objektu typu predmet
           // int volba;                                              // Proměnná pro ukládání hráčovy volby užité v menu hry

            NactiPredmety(ref predmety);    // Načte předměty do pole předmětů
            VypisPocatekPribehu();                  // Vypíše příběh do konzole
            VypisPredmety(ref predmety);    //Vypíše přeměty v tuhle


            //Možnost nasazení předmětů a zvednutí statusů pro válečníka
            NasadPredmety(ref valecnik, ref predmety);
            valecnik.PrepocitejStatyPoNasazeniPredmetu();

            //Další část příběhu
            DalsiCastPribehu();
            //Tohle je simulovaný boj
            Boj(ref valecnik, ref drak);

            //Výsledek souboje ovlivní epilog.
            if(valecnik.JeNazivu())
            {
                EpilogPrvni();
            }
            else
            {
                EpilogDruhy();
            }


            /* while (true)
             {
                 VypisMenu();                                        // Vypíše formátované menu
                 Console.Write("\nZadej svou volbu: ");
                 volba = Convert.ToInt32(Console.ReadLine());        // Načte hráčovu volbu do proměnné volba

                 switch (volba)
                 {
                     // Ukončí hru
                     case 0:
                         Console.WriteLine("Hra se ukončí stisknutím klávesy Enter");
                         Console.ReadLine();
                         return;

                     // Vypíše staty válečníka do konzole
                     case 1:
                         Console.WriteLine("\n" + valecnik);
                         break;

                     // Vypíše staty draka do konzole
                     case 2:
                         Console.WriteLine("\n" + drak);
                         break;

                     // Vypíše tabulku s předměty do konzole
                     case 3:
                         VypisPredmety(ref predmety);
                         break;

                     // Umožní hráči nasadit předměty
                     case 4:
                         NasadPredmety(ref valecnik, ref predmety);
                         valecnik.PrepocitejStatyPoNasazeniPredmetu();       // Po nasazení předmětů dojde k přepočítání síly, životů a případného postihu za překročenou váhu
                         break;

                     // Spustí simulaci boje s drakem
                     case 5:
                         Boj(ref valecnik, ref drak);
                         break;

                     // Ukončí program v případě, že hráč zadá hodnotu mimo očekávané rozmezí
                     default:
                         Console.WriteLine("Byla zadána hodnota mimo rozsah. Ukončuji program po stisknutím klávesy Enter.");
                         Console.ReadLine();
                         return;
                 }
             }*/

            Console.ReadLine();
        }

        // Vypíše menu ovládání hry
        public static void VypisMenu()
        {
            Console.WriteLine("\n" + new string('-', 12) + " MENU " + new string('-', 12));     // Formátovaný výpis hlavičky
            Console.WriteLine("0 - Ukonči hru");
            Console.WriteLine("1 - Vypiš staty hráče");
            Console.WriteLine("2 - Vypiš staty draka");
            Console.WriteLine("3 - Vypiš seznam předmětů");
            Console.WriteLine("4 - Nasaď předměty");
            Console.WriteLine("5 - Bojuj s drakem");
            Console.WriteLine(new string('-', 30));     // Formátovaný výpis patičky
        }

        // Simuluje boj mezi drakem a hráčem
        public static void Boj(ref Valecnik valecnik, ref Drak drak)
        {
            Random rnd = new Random();      // Generátor pseudonáhodných čísel pro boj s drakem
            int utoci = 1;                  // Proměnná určující, kdo je na řadě s útočením (1 = hráč, 2 = drak)

            while (true)
            {
                if (valecnik.ZobraziSeVak())    // Zvítězil hráč
                {
                    Console.WriteLine("\nVzpomněl jsi si na svůj vak a vytáhl jsi z něj předmět: Sušenky Milánek, jsou křupavé a vhodné na předaleké poutě." +
                        "\n Použil jsi sušenky Milánek, drak Ti vydal prince bez boje!");
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
                    drak.UtrziZraneni(valecnik.Utok());         // Drak utrží zranění odpovídající hráčovu útoku
                    Console.WriteLine("Drak utržil zranění!");
                    Console.WriteLine($"Drakovi zbývá {drak.Zivoty} životů.");
                    utoci = 2;  // Další v pořadí útočení bude drak
                }
                else // Útočí drak
                {
                    if (valecnik.UhybPredUtokem(ref rnd))       // Zjistí, zda byl hráč schopen se vyhnout drakovu útoku
                    {
                        Console.WriteLine("Hráč se úspěšně vyhnul zranění!");
                        Console.WriteLine($"Hráčovi zbývá {valecnik.Zivoty} životů.");
                    }
                    else
                    {
                        valecnik.UtrziZraneni(drak.Utok());     // Hráč utrží zranění odpovídající drakovu útoku
                        Console.WriteLine("Hráč utržil zranění!");
                        Console.WriteLine($"Hráčovi zbývá {valecnik.Zivoty} životů.");
                    }

                    utoci = 1;  // Další v pořadí útočení bude hráč
                }
            }
        }

        // Vypíše předmluvu příběhu
        public static void VypisPocatekPribehu()
        {
            Console.WriteLine("Kalítor je království, kde vládnou ženy. Jako dobrodruh, který se touží usadit v hlavním městě Zaa.) \n" +
                              "Musíš ale splnit královnin úkol, a to zachránit jediného potomka, tedy toho legitimního (klepy), z věže v předaleké zemi, kam ho unesl tmavý drak.\n" +
                              "Teď si říkáš, jak to vím, co? Viděla jsem takového létajícího ještěra v noci. Mělo to lehký nádech tmy a něčeho asi zeleného. Navíc takové ještěrky mají rady vysoká místa.\n" +
                              "Nebo snad ne? Tak co tu ještě okouníš. Upaluj! \n");
            Console.WriteLine("Odcházíš do svého skromného příbytku a jdeš směrem k truhle.\nNacházíš tam nekolik předmětů...\n");
            Console.WriteLine("\nChceš si nejraději vzít všechny ale víš že všechno neuneseš...");

        }

        //vypíše další část příběhu
        public static void DalsiCastPribehu()
        {
            Console.WriteLine("\n\nVydáváš se přes hory, doly a chmurný les.\nNalézáš mega velkou věž, vidíš ji z dálky a i tak ti došlo, že slovo mega obrovská věž nestačí pojmout její velikost..." +
                "\nSlyšíš neurvalý řev:\"RAÚÚÚÚÚÚL\" , v tom ti došlo že jsi v tahu..." +
                "\nTak co mi zbývá říkáš si..." +
                "\nPřistoupíš k napůl spícímu drakovi a ....");
        }


        //epilog ten správný
        public static void EpilogPrvni()
        {
            Console.WriteLine("\nÚspěšně jsi zachránil prince, gratulace...." +
                "\nTen votrapa ti už začíná lízt krkem, naneštěstí předtím, než bys ho zabil sám, uvidíš hradby města Zaa." +
                "\nVšichni tě vítají hrdino...." +
                "\nKrálovna tě příjmá v paláci a uděluje ti titul Rytíře kalitorského, " +
                "\nk tomu náleží klidné hlídky, kde se nic neděje a luxusní domeček..." +
                "\nJsi poctěn, příjimáš." +
                "\nKonec.");
            Console.WriteLine("STISKNI ENTER A JDI PAŘIT WOWKO!!!!");
        }

        //druhý epilog kvůli smrti hráče
        public static void EpilogDruhy()
        {
            Console.WriteLine("\n\nŠkoda, žádná reinkarnace tu není...\nEnter pro konec");
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
                catch (IndexOutOfRangeException)    // Hráč zadal index předmětu, který je mimo povolený rozsah
                {
                    Console.WriteLine("Zadaný index neodpovídá žádnému předmětu");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Načte do pole předmětů, které obdrži jako argument
        public static void NactiPredmety(ref Predmet[] predmety)
        {
            predmety[0] = new Predmet("Dýka", 2, 0, 0, 2, true, false);
            predmety[1] = new Predmet("Meč jednoruční", 5, 0, 0, 30, true, false);
            predmety[2] = new Predmet("Meč obouruční", 7, 1, 0, 85, true, true);
            predmety[3] = new Predmet("Plátové brnění", 0, 0, 100, 95, false, false);
            predmety[4] = new Predmet("Štít", 0, 0, 1, 50, true, false); // Přepsala jsem jednu hodnotu tak, že štít se bere jako zbraň, kvůli kolizi s obouručákem
        }

        // Vypíše pole předmětů, které obdrži jako argument
        public static void VypisPredmety(ref Predmet[] predmety)
        {
            // Formatovaný vypis hlavičky tabulky se soubory
            Console.WriteLine($"{"Index",-10}" +
                              $"{"Název",-20}" +
                              $"{"Síla",-10}" +
                              $"{"Útočnost",-10}" +
                              $"{"Obrana",-10}" +
                              $"{"Váha",-10}");

            for (var i = 0; i < predmety.Length; i++)
            {
                Console.Write($"{i,-10}");          // Vypíše index předmětu
                Console.WriteLine(predmety[i]);     // Vypíše předmět
            }
        }
    }
}