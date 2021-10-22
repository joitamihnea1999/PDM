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
        private static SQLiteConnection connection = null;


        public DBService()
        {
            if (connection == null)
            {
                string cale;

                cale = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "esperanto.db");
                Console.WriteLine(cale);

                connection = new SQLiteConnection(cale);


                connection.CreateTable<Curs>();
                connection.CreateTable<Pizza>();
                connection.CreateTable<Profil>();
                connection.CreateTable<Comanda>();

                var pizzas = connection.Query<Pizza>("SELECT * FROM Pizza");

                if (pizzas.Count == 0)
                {
                    List<Pizza> initialPizzas = new List<Pizza>();
                    initialPizzas.Add(new Pizza("Capriciosa", 30, 25, "Pizza"));
                    initialPizzas.Add(new Pizza("Neapolitan", 30, 28, "Pizza"));
                    initialPizzas.Add(new Pizza("Chicago ", 30, 29, "Pizza"));
                    initialPizzas.Add(new Pizza("New York-Style", 30, 30, "Pizza"));
                    initialPizzas.Add(new Pizza("Sicilian", 30, 30, "Pizza"));
                    initialPizzas.Add(new Pizza("Greek ", 30, 25, "Pizza"));
                    initialPizzas.Add(new Pizza("California ", 30, 25, "Pizza"));
                    initialPizzas.Add(new Pizza("Detroit ", 30, 30, "Pizza"));
                    initialPizzas.Add(new Pizza("Tonda Romana", 30, 30, "Pizza"));
                    initialPizzas.Add(new Pizza("Fritta ", 30, 30, "Pizza"));

                    connection.InsertAll(initialPizzas);

                }

            }

        }


        



        public List<Profil> GetProfils()
        {
            var x = connection.Query<Profil>("SELECT * FROM Profil");
            Console.WriteLine(x);
            return x;
        }

        public List<Pizza> GetPizzas()
        {
            var x = connection.Query<Pizza>("SELECT * FROM Pizza");
            return x;
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
