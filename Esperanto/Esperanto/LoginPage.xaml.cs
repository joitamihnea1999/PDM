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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void CreazaCont_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreareProfilPage());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            string email = entryEmail.Text;
            string parola = entryParola.Text;

            DBService dbservice = new DBService();

            Profil profil = dbservice.CautaProfilDupaEmailSiParola(email, parola);

            if(profil != null)
            {
                await DisplayAlert("Succes", "Te-ai logat cu succes!", "OK");

                if (Preferences.ContainsKey("idProfilLogat"))
                {
                    Preferences.Remove("idProfilLogat");
                }

                Preferences.Set("idProfilLogat", profil.Id.ToString());
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Eroare", "Contul nu a fost gasit. Incearca din nou", "OK");
            }

        }
    }
}