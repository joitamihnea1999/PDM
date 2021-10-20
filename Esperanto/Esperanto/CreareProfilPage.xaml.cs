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
    public partial class CreareProfilPage : ContentPage
    {
        public CreareProfilPage()
        {
            InitializeComponent();
        }

        private async void SalveazaCont_Clicked(object sender, EventArgs e)
        {
            string nume = entryNume.Text;
            string parola = entryParola.Text;
            string email = entryEmail.Text;
            string telefon = entryTelefon.Text;

            Profil profilNou = new Profil(nume, parola, email, telefon);

            DBService dbservice = new DBService();

            Profil profilExistent = dbservice.CautaProfilDupaEmail(email);

            if(profilExistent == null)
            {
                dbservice.AdaugaProfil(profilNou);
                await DisplayAlert("Succes", "Contul a fost creat cu succes!", "OK");
                await Navigation.PopAsync();
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Eroare", "Contul exista deja! Foloseste alt email", "OK");
            }

        }
    }
}