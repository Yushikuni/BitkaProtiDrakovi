namespace BitkaProtiDrakovi
{
    class Predmet
    {
        // Vlastnosti predmetu
        public string Nazev { get; set; }
        public int Sila { get; set; }
        public int Utocnost { get; set; }
        public int Obrana { get; set; }
        public int Vaha { get; set; }
        public bool JeZbran { get; set; }
        public bool JeObourucni { get; set; }

        // Konstruktor noveho predmetu
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

        // Metoda pro vypis predmetu
        public override string ToString()
        {
            string ret = "";

            ret += string.Format("{0, -20}", Nazev.ToUpper()) +
                   string.Format("{0, -10}", Sila) +
                   string.Format("{0, -10}", Utocnost) +
                   string.Format("{0, -10}", Obrana) +
                   string.Format("{0, -10}", Vaha);
            
            return ret;
        }
    }
}
