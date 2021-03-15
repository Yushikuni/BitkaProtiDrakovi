using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitkaProtiDrakovi
{
    class Valecnik
    {
        Random rnd = new Random();
        //proc private? nechci menit vlastnosti valecnika pres hlavni cyklus 
        private int Sila = -1;
        private int Obratnost = -1;
        private int Inteligence = -1;
        private int Charizma = -1;
        private int Zivoty = -1;
        
        //vytvoreni valecnika
       public void VytvorValecinka(int sila, int obratnost, int inteligence, int charizma, int zivoty)
        {
            sila = rnd.Next(1, 100);
            System.Threading.Thread.Sleep(100);
            Sila = sila;

            obratnost = rnd.Next(1, 100);
            System.Threading.Thread.Sleep(100);
            Obratnost = obratnost;

            inteligence = rnd.Next(1, 100);
            System.Threading.Thread.Sleep(100);
            Inteligence = inteligence;

            charizma = rnd.Next(1, 100);
            System.Threading.Thread.Sleep(100);
            Charizma = charizma;

            zivoty = rnd.Next(1, 100);
            System.Threading.Thread.Sleep(100);
            Zivoty = zivoty;
        }
        //pokud je valecnik chytry muze najit ve vaku susenky
        public bool ZobraziSeVak(int inteligence)
        {
            if(inteligence>=4)
            {
                return true;
            }
            return false;
        }
        //utok je sloucen pres silu valecnika a silu predmetu
        public virtual int Utok(int silaValecnika, int silaPredmetu)
        {
            int sila = silaValecnika + silaPredmetu;
            return sila;
        }

        //uhyb pred utokem draka je roven 50% jako u hodu minci
        public virtual bool UhybPredUtokem(Random rnd)
        {
            //pokud je rnd roven 1 uhyb se provedl a pokud ne tak se nepovedl
            if(int.Parse(rnd.ToString()) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
    }
}
