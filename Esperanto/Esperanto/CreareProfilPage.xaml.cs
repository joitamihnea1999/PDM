using Esperanto.Models;
using Esperanto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
            PassError.Text = "";
            EmailError.Text = "";
            NameError.Text = "";
            TelefonError.Text = "";
            string nume = entryNume.Text != null ? entryNume.Text : "";
            string parola = entryParola.Text != null ? entryParola.Text : "";
            string email = entryEmail.Text != null ? entryEmail.Text : "";
            string telefon = entryTelefon.Text != null ? entryTelefon.Text : "";

            bool valid = true;

            if (parola.Length < 6)
            {
                PassError.Text = "Parola trebuie sa aiba cel putin 6 caractere";
                valid = false;
            }

            try
            {
                if(email == "")
                {
                    valid = false;
                    EmailError.Text = "Email-ul este gol!";
                }
                else
                {
                    MailAddress m = new MailAddress(email);
                }
                
            }
            catch (FormatException)
            {
                valid = false;
                EmailError.Text = "Email-ul nu este valid!";
            }

            if (nume.Length < 3)
            {
                NameError.Text = "Numele trebuie sa aiba cel putin 3 caractere";
                valid = false;
            }

             const string phoneNumberRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

            if (!Regex.IsMatch(telefon, phoneNumberRegex) || telefon.Length < 9)
            {
                valid = false;
                TelefonError.Text = "Nr de telefon invalid!";

            };
           
            if(valid == false)
            {
                return;
            }

            

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