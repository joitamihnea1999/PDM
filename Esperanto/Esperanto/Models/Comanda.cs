using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esperanto.Models
{
    class Comanda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [TextBlob("ProfilBlobbed")]
        public Profil Profil { get; set; }
        public string ProfilBlobbed { get; set; }

        [TextBlob("PizzeBlobbed")]
        public List<Pizza> Pizze { get; set; }

        [TextBlob("CantitatiPizzaBlobbed")]
        public List<int> cantitatiPizza { get; set; }

        public string CantitatiPizzaBlobbed { get; set; }

        public string PizzeBlobbed { get; set; }

        public string Adresa { get; set; }

        public string Info { get; set; }

        public Comanda()
        {

        }
        public Comanda(List<Pizza> Pizze, Profil Profil, List<int> cantitatiPizza, string Adresa)
        {
            this.Pizze = Pizze;
            this.Profil = Profil;
            this.cantitatiPizza = cantitatiPizza;
            this.Adresa = Adresa;
            this.Info = generateDisplayString();
        }


        public string generateDisplayString()
        {
            double valoareComanda = 0;
            string finalString = "Comanda contine " + Pizze.Count + " pizza: \n";
            for ( int i = 0; i < Pizze.Count; i++)
            {
                finalString += Pizze[i].Denumire + " x " + cantitatiPizza[i] + "\n";
                valoareComanda += Pizze[i].Pret * cantitatiPizza[i];
            }
            finalString += "\n A avut/are valoare totala de " + valoareComanda + " RON";
            finalString += "\n Si a fost/urmeaza sa fie livrata la adresa: " + Adresa;
            return finalString;
           
        }


    }
}
