using Esperanto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Essentials;

namespace Esperanto.Services
{
    class SursaDateCurs
    {
        public static async Task<List<Curs>> ObtineListaCurs()
        {
            DBService dbservice = new DBService();

            List<Curs> cursuri = dbservice.ObtineCursDinData(DateTime.Now.ToString("yyyy-MM-dd"));

            if (cursuri.Count == 0)
            {
                cursuri = await PreiaCursXML();

                dbservice.AdaugaListaCursuri(cursuri);
            }

            return await PreiaCursXML();
        }


        private static async Task<List<Curs>> PreiaCursXML()
        {
            List<Curs> listaCurs = new List<Curs>();

            HttpClient httpClient = new HttpClient();
            Stream stream = await httpClient.GetStreamAsync("https://bnr.ro/nbrfxrates.xml");

            using (XmlReader reader = XmlReader.Create(stream))
            {
                while (reader.Read())
                {

                    string data = "";

                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "Cube")
                        {
                            data = reader["date"];
                        }
                        if (reader.Name == "Rate")
                        {
                            Curs curs = new Curs()
                            {
                                Valuta = reader["currency"],
                                Data = data,
                                Multiplicator = reader["multiplicator"] != null ? int.Parse(reader["multiplicator"]) : 1

                            };

                            reader.Read();

                            curs.Valoare = double.Parse(reader.Value);

                            listaCurs.Add(curs);
                        }
                    }
                }
            }

            return listaCurs;
        }

    }
}
