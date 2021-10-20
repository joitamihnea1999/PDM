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

            int idProfilLogat = Convert.ToInt32(Preferences.Get("idProfilLogat", "0"));

            if (idProfilLogat != 0)
            {
                Console.WriteLine("da - " + idProfilLogat);
                DBService dbservice = new DBService();
                Profil profil = dbservice.CautaProfilDupaId(idProfilLogat);
                List<Profil> listaProfil = new List<Profil>();
                listaProfil.Add(profil);
                Console.WriteLine(profil.Telefon);
                listViewProfil.ItemsSource = listaProfil;
            }
            else
            {
                DisplayAlert("Eroare", "Inca nu esti logat!", "OK");
            }
        }

    }
}