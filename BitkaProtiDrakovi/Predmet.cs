namespace BitkaProtiDrakovi
{
    class Predmet
    {
        // Vlastnosti predmětů
        public string Nazev { get; set; }
        public int Sila { get; set; }
        public int Utocnost { get; set; }
        public int Obrana { get; set; }
        public int Vaha { get; set; }
        public bool JeZbran { get; set; }       // true = je zbraň, false = není zbraň
        public bool JeObourucni { get; set; }   // true = je obouruční zbraň, false = není obouruční zbraň

        // Konstruktor nového předmětu
        public Predmet(string nazev, int sila, int utocnost, int obrana, int vaha, bool jeZbran, bool jeObourucni)
        {
            Nazev = nazev;
            Sila = sila;
            Utocnost = utocnost;
            Obrana = obrana;
            Vaha = vaha;
            JeZbran = jeZbran;
            JeObourucni = jeObourucni;
        }

        // Metoda pro výpis předmětů
        public override string ToString()
        {
            string ret = "";

            ret += $"{Nazev.ToUpper(),-20}" +
                   $"{Sila,-10}" +
                   $"{Utocnost,-10}" +
                   $"{Obrana,-10}" +
                   $"{Vaha,-10}";
            
            return ret;
        }
    }
}
