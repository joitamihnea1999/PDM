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
    public partial class IstoricComenziPage : ContentPage
    {
        public IstoricComenziPage()
        {

            InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            DBService dbService = new DBService();
            var currentProfile = dbService.getCurrentProfil();

            var asyncConnection = AsyncConnection.GetInstance();
            var comenzi = await SQLiteNetExtensionsAsync.Extensions.ReadOperations.
               GetAllWithChildrenAsync<Comanda>(asyncConnection);

          

            comenziListView.ItemsSource = comenzi;
        }
    }
}