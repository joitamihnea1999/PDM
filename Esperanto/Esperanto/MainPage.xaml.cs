using Esperanto.Models;
using Esperanto.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Esperanto
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            DBService dbservice = new DBService();

            var pizzas = dbservice.GetPizzas();
            pizzaListView.ItemsSource = pizzas;      
        }

       
        private void Setari_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetariPage());
        }
    }
}
