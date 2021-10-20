using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Esperanto.Services
{
    class Utils
    {
        public Dictionary<string,double> ConversiePret(double pret)
        {
            double pretNou = pret;

            string cursValuta = Preferences.Get("curs_valuta", "");
            double cursValoare = Preferences.Get("curs_valoare", 0);
            double multiplicator = Preferences.Get("curs_multiplicator", 1);

            pretNou = pretNou / (multiplicator * cursValoare);

            Dictionary<string, double> dictCurs = new Dictionary<string, double>();

            dictCurs[cursValuta] = cursValoare;

            return dictCurs;
        }

    }
}
