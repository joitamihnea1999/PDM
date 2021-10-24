using Esperanto.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace Esperanto.Services
{
    class DBService
    {

        private  SQLiteConnection connection;

        public DBService()
        {
            connection = SyncConnection.GetInstance();
        }


        public List<Comanda> GetComenzi(Profil p)
        {
            var x = connection.Query<Comanda>("SELECT * FROM Comanda");
            return x;

           
        }

        public Profil CautaProfilDupaId(int id)
        {
            return connection.Table<Profil>().FirstOrDefault(x => x.Id == id);
        }

        public  Profil getCurrentProfil()
        {
            int idProfilLogat = Convert.ToInt32(Preferences.Get("idProfilLogat", "0"));

            if (idProfilLogat != 0)
            {
                DBService dbservice = new DBService();
                Profil profil = CautaProfilDupaId(idProfilLogat);
                return profil;
            }
            return null;
           
        }

        public  List<Pizza> GetPizzas()
        {
            var x = connection.Query<Pizza>("SELECT * FROM Pizza");
            return x;
        }


        public  int AdaugaCurs(Curs curs)
        {
            return connection.Insert(curs);
        }

        public  int AdaugaListaCursuri(List<Curs> cursuri)
        {
            return connection.InsertAll(cursuri);
        }

        public  List<Curs> ObtineCursDinData(string data)
        {
            return connection.Query<Curs>("SELECT * FROM Curs WHERE Data = ?", data);
        }



        public  int AdaugaPizza(Pizza pizza)
        {
            return connection.Insert(pizza);
        }

        public  int AdaugaListaPizza(List<Pizza> pizze)
        {
            return connection.InsertAll(pizze);
        }




        public  int AdaugaProfil(Profil profil)
        {
            return connection.Insert(profil);
        }

        public  int AdaugaListaProfile(List<Profil> profile)
        {
            return connection.InsertAll(profile);
        }

        public  Profil CautaProfilDupaEmailSiParola(string email, string parola)
        {
            return connection.Table<Profil>().FirstOrDefault(x => x.Email == email && x.Parola == parola);
        }
        public  Profil CautaProfilDupaEmail(string email)
        {
            return connection.Table<Profil>().FirstOrDefault(x => x.Email == email);
        }
       


        public  int AdaugaComanda(Comanda comanda)
        {
            return connection.Insert(comanda);
        }

        public  int AdaugaListaComenzi(List<Comanda> comenzi)
        {
            return connection.InsertAll(comenzi);
        }
    }
}
