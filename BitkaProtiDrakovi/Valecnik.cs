﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return (Inteligence >= 4) ? true : false;
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

            return (uhyb == 1) ? true : false;
        }
    }
}
