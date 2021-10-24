using Esperanto.Models;
using Esperanto.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Esperanto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComandaPage : ContentPage
    {
        private List<Pizza> pizzas;
        private List<int> cantitatiPizza;
        private DBService dbService;
        private Pizza lastSelectedPizza = new Pizza();
        private Profil profil;
        private string adresa;
        public ComandaPage()
        {
            InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            pizzas = new List<Pizza>();
            cantitatiPizza = new List<int>();
            dbService = new DBService();
            if(pizzaPicker.ItemsSource == null)
            {
                pizzaPicker.ItemsSource = dbService.GetPizzas();
            }
            
            pizzaPicker.SelectedIndex = 0;
            profil = dbService.getCurrentProfil();
            summary.Text += "\n";
            if (profil == null)
            {
                await DisplayAlert("Eroare", "Inca nu esti logat!", "OK");
                await Navigation.PopAsync();
                await Navigation.PushAsync(new LoginPage());


            }
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {

            int cantitatePizza;

            try
            {
                cantitatePizza = Convert.ToInt32(entryCantitate.Text);
                if (cantitatePizza < 1 || cantitatePizza > 99)
                {
                    DisplayAlert("Eroare", "Cantitatea trebuie sa fie un numbar natural mai mic de 100", "OK");
                    return;
                }

            }
            catch
            {
                await DisplayAlert("Eroare", "Cantitatea trebuie sa fie un numbar natural mai mic de 100", "OK");
                return;

            }


            pizzas.Add(lastSelectedPizza);
            cantitatiPizza.Add(cantitatePizza);
            summary.Text += lastSelectedPizza.ToString() + " x " + cantitatePizza + "\n" ;

        }

        private void pizzaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastSelectedPizza = dbService.GetPizzas()[pizzaPicker.SelectedIndex];

        }

        private async void submitComanda(object sender, EventArgs e)
        {
            adresa = entryAdresa.Text != null ? entryAdresa.Text : "";


            if (adresa.Length < 10)
            {
                await DisplayAlert("Eroare", "Trebuie sa introduceti adresa si sa aiba minim 10 caractere", "OK");
                return;
            }

            if(pizzas.Count == 0)
            {
                await DisplayAlert("Eroare", "Trebuie sa adaugati cel putin o pizza!", "OK");
                return;
            }

            Comanda c = new Comanda(pizzas, profil, cantitatiPizza, adresa);
            var asyncConnection = AsyncConnection.GetInstance();

            await SQLiteNetExtensionsAsync.Extensions.WriteOperations.
              InsertWithChildrenAsync(asyncConnection, c);
           await DisplayAlert("Success!", "Comanda a fost realizata cu success. O puteti vedea in sectiunea Istoric Comenzi", "OK");
            entryAdresa.Text = "";
            adresa = "";
            summary.Text = "\n";
        }
    }
}