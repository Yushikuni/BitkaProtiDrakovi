using System;
using System.Collections.Generic;

namespace BitkaProtiDrakovi
{
    class Valecnik
    {
        // Válečníkovy atributy
        public int Sila { get; set;}
        public int Obratnost { get; set; }
        public int Inteligence { get; set; } = 2;
        public int Charizma { get; set; }
        public int Zivoty { get; set; }
        public List<Predmet> NasazenePredmety { get; set; }
        public int ObsazeneRuce { get; set; }                   // Udává v kolika rukách právě hráč třímá zbraň

        // Konstruktor vytvoření válečníka
        public Valecnik(ref Random rnd)
        {
            Sila = rnd.Next(1, 100);
            Obratnost = rnd.Next(1, 100);
            //Inteligence = rnd.Next(1, 100);
            Charizma = rnd.Next(1, 100);
            Zivoty = rnd.Next(1, 100);
            NasazenePredmety = new List<Predmet>();
            ObsazeneRuce = 0;
        }

        // Nasadí válečníkovi předmět
        public bool NasadPredmet(ref Predmet predmet)
        {
            if (predmet.Sila > Sila)
            {
                // Vyhodí výjimku, pokud válečníkova síla není dostatečná pro nasazení předmětu
                throw new Exception("Nemůžeš nasadit tento předmět, protože na něj nemáš dostatečnou sílu!");
            }

            if (NasazenePredmety.Contains(predmet))
            {
                // Vyhodí výjimku, pokud se hráč pokusí nasadit předmět, který již má nasazený
                throw new Exception("Nemůžeš si nasadit předmět, který již nosíš!");
            }

            if (predmet.JeZbran)
            {
                if (predmet.JeObourucni)
                {
                    if (ObsazeneRuce + 2 > 2)
                    {
                        // Vyhodí výjimku, pokud má válečník již plně obsazené ruce
                        throw new Exception("Máš už plné ruce, neuneseš žádnou další zbraň!");
                    }

                    ObsazeneRuce += 2;
                }
                else
                {
                    if (ObsazeneRuce + 1 > 2) 
                    {
                        // Vyhodí výjimku, pokud má válečník již plně obsazené ruce
                        throw new Exception("Máš už plné ruce, neuneseš žádnou další zbraň!");
                    }

                    ObsazeneRuce += 1;
                }
            }
            
            NasazenePredmety.Add(predmet);
            return true;
        }

        // Přepočítá hráčovi staty po nasazení předmětu
        public void PrepocitejStatyPoNasazeniPredmetu()
        {
            var vaha = 0;

            foreach (var predmet in NasazenePredmety)
            {
                Sila += predmet.Utocnost;
                Zivoty += predmet.Obrana;
                vaha += predmet.Vaha;
            }

            // Za překročení váhy = 100 se ubírá jeden bod obratnosti
            if (vaha > 100)
            {
                Obratnost -= 1;
            }
        }

        // Pokud je válečník dostatečně chytrý, zobrazí se mu vak
        public bool ZobraziSeVak() => (Inteligence >= 4);

        // Útok představuje hráčovu sílu
        public int Utok() => Sila;

        // Hráč utrží zranění
        public void UtrziZraneni(int utrzeneZraneni) => Zivoty -= utrzeneZraneni;

        // Vrací true nebo false na základě toho, zda se podařilo či nepodařilo uhnout útoku
        public bool UhybPredUtokem(ref Random rnd)
        {
            var uhyb = rnd.Next(0, 2);  // vraci integer s hodnotou 0 ci 1 (0 = neuspech, 1 = uspech pri uteku)

            return (uhyb == 1);
        }

        // Vrací true nebo false na základě toho, zda je hráč naživu
        public bool JeNazivu() => (Zivoty > 0);

        // Metoda pro výpis vlastností válečníka
        public override string ToString()
        {
            string ret = "";

            ret += new string('=', 10) + " VÁLEČNÍK " + new string('=', 10) + "\n";
            ret += "Síla:\t\t" + Sila + "\n";
            ret += "Obratnost:\t" + Obratnost + "\n";
            ret += "Inteligence:\t" + Inteligence + "\n";
            ret += "Charizma:\t" + Charizma + "\n";
            ret += "Životy:\t\t" + Zivoty + "\n";
            ret += new string('=', 30);

            return ret;
        }
    }
}
