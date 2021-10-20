using Esperanto.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Esperanto.Services
{
    class DBService
    {
        SQLiteConnection connection;

        public DBService()
        {
            string cale;

            cale = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "esperanto.db");

            connection = new SQLiteConnection(cale);

            connection.CreateTable<Curs>();
            connection.CreateTable<Pizza>();
            connection.CreateTable<Profil>();
            connection.CreateTable<Comanda>();
        }

        public int AdaugaCurs(Curs curs)
        {
            return connection.Insert(curs);
        }

        public int AdaugaListaCursuri(List<Curs> cursuri)
        {
            return connection.InsertAll(cursuri);
        }

        public List<Curs> ObtineCursDinData(string data)
        {
            return connection.Query<Curs>("SELECT * FROM Curs WHERE Data = ?", data);
        }



        public int AdaugaPizza(Pizza pizza)
        {
            return connection.Insert(pizza);
        }

        public int AdaugaListaPizza(List<Pizza> pizze)
        {
            return connection.InsertAll(pizze);
        }




        public int AdaugaProfil(Profil profil)
        {
            return connection.Insert(profil);
        }

        public int AdaugaListaProfile(List<Profil> profile)
        {
            return connection.InsertAll(profile);
        }

        public Profil CautaProfilDupaEmailSiParola(string email, string parola)
        {
            return connection.Table<Profil>().FirstOrDefault(x => x.Email == email && x.Parola == parola);
        }
        public Profil CautaProfilDupaEmail(string email)
        {
            return connection.Table<Profil>().FirstOrDefault(x => x.Email == email);
        }
        public Profil CautaProfilDupaId(int id)
        {
            return connection.Table<Profil>().FirstOrDefault(x => x.Id == id);
        }


        public int AdaugaComanda(Comanda comanda)
        {
            return connection.Insert(comanda);
        }

        public int AdaugaListaComenzi(List<Comanda> comenzi)
        {
            return connection.InsertAll(comenzi);
        }
    }
}
