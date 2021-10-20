using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Esperanto.Models
{
    class Profil
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public Profil()
        {

        }

        public Profil(string nume, string parola, string email, string telefon)
        {
            Nume = nume;
            Parola = parola;
            Email = email;
            Telefon = telefon;
        }
    }
}
