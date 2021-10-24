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
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            DBService dbService = new DBService();

            Profil profil = dbService.getCurrentProfil();

            if (profil == null)
            {
                await DisplayAlert("Eroare", "Inca nu esti logat!", "OK");
                await Navigation.PopAsync();
                await Navigation.PushAsync(new LoginPage());


            } else
            {
                Nume.Text = "Nume: " + profil.Nume;
                Email.Text = "Email: " + profil.Email;
                Telefon.Text = "Telefon: " + profil.Telefon;
            }
        }

    }
}