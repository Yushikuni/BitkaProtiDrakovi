using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BitkaProtiDrakovi
{
    class Predmety
    { 
        int sila = 0;
        int utocnost = 0;
        int obrana = 0;
        int vaha = 0;

        protected void Dyka()
        {
            sila += 2;
            vaha += 2;
        }
        protected void MecJednorucni()
        {
            sila += 5;
            vaha += 30;
        }
        protected void MecObourucni()
        {
            sila += 7;
            utocnost += 1;
            vaha += 85;
        }
        protected void PlatoveBrneni()
        {
            obrana += 100;
            vaha += 95;
        }
        protected void Stit()
        {
            obrana += 1;
            vaha += 50;
        }

        

    }
}
