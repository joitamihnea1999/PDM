using Esperanto.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Esperanto.Services
{
    class SyncConnection
    {

        private SyncConnection() { }


        private static SQLiteConnection _instance;


        public static SQLiteConnection GetInstance()
        {
            if (_instance == null)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "esperanto.db");
                _instance = new SQLiteConnection(path);
                
               _instance.CreateTable<Curs>();
               _instance.CreateTable<Pizza>();
               _instance.CreateTable<Profil>();
               _instance.CreateTable<Comanda>();

                var pizzas =_instance.Query<Pizza>("SELECT * FROM Pizza");

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

                   _instance.InsertAll(initialPizzas);

                }

            
            }
            return _instance;
        }
    }
}
