using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Esperanto.Models
{
    class Pizza
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Denumire { get; set; }
        public double Diametru { get; set; }
        public double Pret { get; set; }

        public Pizza()
        { 
        
        }
        public Pizza(string denumire, double diametru, double pret)
        {
            Denumire = denumire;
            Diametru = diametru;
            Pret = pret;
        }
    }
}
