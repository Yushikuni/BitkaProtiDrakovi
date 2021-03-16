using System;

namespace BitkaProtiDrakovi
{
    class Drak : IUtils
    {
        // Vlastnosti draka
        public int Sila { get; set; }
        public int Obratnost { get; set; }
        public int Inteligence { get; set; }
        public int Strach { get; set; }         // Strach modifikuje drakův útok
        public int Zivoty { get; set; }

        // Vytvoření draka
        public Drak(ref Random rnd)
        {
            Sila = rnd.Next(1, 100) + 50;       // Drakova síla je navýšena o 50
            Obratnost = rnd.Next(1, 100);
            Inteligence = rnd.Next(1, 100);
            Strach = rnd.Next(1, 100);
            Zivoty = rnd.Next(1, 100) + 50;     // Drakovy životy jsou navýšeny o 50
        }

        // Metoda pro drakův útok
        public int Utok() => Sila + Strach;

        // Vrací true nebo false na základě toho, zda je drak naživu
        public bool JeNazivu() => (Zivoty > 0);

        // Drak utrží zranění
        public void UtrziZraneni(int utrzeneZraneni) => Zivoty -= utrzeneZraneni;

        // Vypsání statů draka 
        public override string ToString()
        {
            string ret = "";

            ret += new string('=', 12) + " DRAK " + new string('=', 12) + "\n";
            ret += "Síla:\t\t" + Sila + "\n";
            ret += "Obratnost:\t" + Obratnost + "\n";
            ret += "Inteligence:\t" + Inteligence + "\n";
            ret += "Strach:     \t" + Strach + "\n";
            ret += "Životy:\t\t" + Zivoty + "\n";
            ret += new string('=', 30);
            return ret;
        }
    }
}
