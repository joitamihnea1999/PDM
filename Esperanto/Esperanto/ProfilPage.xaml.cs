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
    public partial class ProfilPage : ContentPage
    {
        public ProfilPage()
        {
            InitializeComponent();

           
                DBService dbservice = new DBService();
                List<Profil> listaProfil = new List<Profil>();
            Profil currentProfil = dbservice.getCurrentProfil();
            if(currentProfil != null)
            {
                listaProfil.Add(currentProfil);
                listViewProfil.ItemsSource = listaProfil;
            }
                else
           
            {
                DisplayAlert("Eroare", "Inca nu esti logat!", "OK");
            }
        }

    }
}