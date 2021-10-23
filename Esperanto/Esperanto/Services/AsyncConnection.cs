using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Esperanto.Services
{
    class AsyncConnection
    {

        private AsyncConnection() { }

       
        private static SQLiteAsyncConnection _instance;

     
        public static SQLiteAsyncConnection GetInstance()
        {
            if (_instance == null)
            {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "esperanto.db");
            _instance = new SQLiteAsyncConnection(path);
        }
            return _instance;
        }
    }
}
