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
        public string PizzeBlobbed { get; set; }

        public double PretTotal { get; set; }

        public string Adresa { get; set; }

    }
}
