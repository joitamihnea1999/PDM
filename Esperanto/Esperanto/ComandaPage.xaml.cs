using Esperanto.Models;
using Esperanto.Services;
using System;
using System.Collections.Generic;
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
        public ComandaPage()
        {
            InitializeComponent();
            pizzas = new List<Pizza>();
            cantitatiPizza = new List<int>();
            dbService = new DBService();
            pizzaPicker.ItemsSource = dbService.GetPizzas();
            pizzaPicker.SelectedIndex = 0;
        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {

            int cantitatePizza;

            try
            {
                cantitatePizza = Convert.ToInt32(entryCantitate.Text);
                if(cantitatePizza < 1 || cantitatePizza > 99)
                {
                    await DisplayAlert("Eroare", "Cantitatea trebuie sa fie un numbar natural mai mic de 100", "OK");
                    return;
                }

            }
            catch
            {
                await DisplayAlert("Eroare", "Cantitatea trebuie sa fie un numbar natural mai mic de 100", "OK");
                return;

            }

            string adresaComanda = entryAdresa.Text;

            DBService dbservice = new DBService();


            
            

        }

       

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void pizzaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pizza selectedPizza = dbService.GetPizzas()[pizzaPicker.SelectedIndex];
            summary.Text = selectedPizza.ToString();

        }
    }
}