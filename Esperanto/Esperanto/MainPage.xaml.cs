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

        public MainPage()
        {
            InitializeComponent();
            DBService dbservice = new DBService();

            var pizzas = dbservice.GetPizzas();
            pizzaListView.ItemsSource = pizzas;
            var screenWidth = DeviceDisplay.MainDisplayInfo.Width;
            pizzaListView.RowHeight = screenWidth > 400 ? 400 : 350;
        }

       
        private void Setari_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetariPage());
        }
    }
}
