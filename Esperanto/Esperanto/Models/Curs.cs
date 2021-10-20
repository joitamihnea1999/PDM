using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esperanto.Models
{
    class Curs
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Valuta { get; set; }

        public double Valoare { get; set; }

        public int Multiplicator { get; set; }

        public string Data { get; set; }

        public Curs()
        {
            Multiplicator = 1;
        }
    }
}
