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
            DBService dbservice = new DBService();

            var currentProfile = dbservice.getCurrentProfil();
            var asyncConnection = dbservice.getAsyncDb();

            var comenzi = await SQLiteNetExtensionsAsync.Extensions.ReadOperations.
               GetAllWithChildrenAsync<Comanda>(asyncConnection);

          

            comenziListView.ItemsSource = comenzi;
        }
    }
}