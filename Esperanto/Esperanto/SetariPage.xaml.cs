using Esperanto.Models;
using Esperanto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Esperanto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetariPage : ContentPage
    {
        Dictionary<string, Curs> dictCurs = new Dictionary<string, Curs>();

        public SetariPage()
        {
            InitializeComponent();
            Initializare();
        }

        public async void Initializare()
        {
            List<Curs> listCurs = await SursaDateCurs.ObtineListaCurs();
            List<string> valute = new List<string>();

            foreach (Curs curs in listCurs)
            {
                dictCurs[curs.Valuta] = curs;
            }

            pickerValuta.ItemsSource = dictCurs.Keys.ToList();

            pickerValuta.SelectedItem = "EUR";
        }

        private void pickerValutaChanged(object sender, EventArgs e)
        {
            Curs curs = dictCurs[(string)pickerValuta.SelectedItem];

            Preferences.Set("curs_valoare", curs.Valoare);
            Preferences.Set("curs_valuta", curs.Valuta);
            Preferences.Set("curs_multiplicator", curs.Multiplicator);
        }
    }
}