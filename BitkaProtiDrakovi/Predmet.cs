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

            ret += Nazev.ToUpper() + "\t" + Sila + "\t" + Utocnost + "\t" + Obrana + "\t" + Vaha;
            
            return ret;
        }
    }
}
