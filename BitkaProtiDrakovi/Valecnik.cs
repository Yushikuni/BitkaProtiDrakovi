using System;

namespace BitkaProtiDrakovi
{
    class Valecnik
    {
        // Valecnikovi atributy
        public int Sila { get; set;}
        public int Obratnost { get; set; }
        public int Inteligence { get; set; }
        public int Charizma { get; set; }
        public int Zivoty { get; set; }

        // Kontrustor vytvoreni valecnika
        public Valecnik()
        {
            Random rnd = new Random();
            Sila = rnd.Next(1, 100);
            Obratnost = rnd.Next(1, 100);
            Inteligence = rnd.Next(1, 100);
            Charizma = rnd.Next(1, 100);
            Zivoty = rnd.Next(1, 100);
        }

        // Pokud je valecnik dostatecne chytry, zobrazi vak
        public bool ZobraziSeVak()
        {
            return (Inteligence >= 4);
        }

        // Utok predstavuje soucet sily valecnika a sily jeho predmetu
        public int Utok(int silaPredmetu)
        {
            return Sila + silaPredmetu;
        }

        // Vraci true nebo false na zaklade toho, zda se povedlo uhnout utoku
        public static bool UhybPredUtokem()
        {
            Random rnd = new Random();

            var uhyb = rnd.Next(0, 2);  // vraci integer s hodnotou 0 ci 1 (0 = neuspech, 1 = uspech pri uteku)

            return (uhyb == 1);
        }

        // Metoda pro vypis vlastnosti vytvoreneho valecnika
        public override string ToString()
        {
            string ret = "";

            ret += new string('=', 10) + " VÁLEČNÍK " + new string('=', 10) + "\n";
            ret += "Síla:\t\t" + Sila + "\n";
            ret += "Obratnost:\t" + Obratnost + "\n";
            ret += "Inteligence:\t" + Inteligence + "\n";
            ret += "Charizma:\t" + Charizma + "\n";
            ret += "Životy:\t\t" + Zivoty + "\n";

            return ret;
        }
    }
}
