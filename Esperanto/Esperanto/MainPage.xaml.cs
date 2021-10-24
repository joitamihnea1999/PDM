using Esperanto.Models;
using Esperanto.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Esperanto
{
    public partial class MainPage : ContentPage
    {

        private List<Pizza> pizzaInRON = new List<Pizza>();
        private double currencyValue = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(double currencyValue = 1)
        {
            InitializeComponent();
            this.currencyValue = currencyValue;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            DBService dbservice = new DBService();
            pizzaInRON = dbservice.GetPizzas();
            pizzaListView.ItemsSource = pizzaInRON;
            pizzaListView.RowHeight = 450;
            try
            {

                if (currencyValue != 1)
                {
                    List<Pizza> newPizzas = new List<Pizza>();
                    foreach (var item in pizzaInRON)
                    {
                        newPizzas.Add(new Pizza(item.Denumire,  item.Diametru, Math.Round(item.Pret / currencyValue, 2) , item.Image));
                    }

                    if (pizzaListView.ItemsSource != null)
                    {
                        pizzaListView.ItemsSource = null;
                    }
                    pizzaListView.ItemsSource = newPizzas;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            
            

            
            
        }

        private async void Setari_Clicked(object sender, EventArgs e)
        {        
      await  Navigation.PushAsync(new SetariPage());
        }
    }
}
