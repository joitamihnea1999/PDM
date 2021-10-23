using Esperanto.Models;
using Esperanto.Services;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;

namespace Esperanto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferintePage : ContentPage
    {
        public PreferintePage()
        {
            InitializeComponent();
            

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

          
            

            List<Entry> dateGrafic = new List<Entry>();

            DBService dbService = new DBService();

            Profil profil = dbService.getCurrentProfil();

            if (profil == null)
            {
                await DisplayAlert("Eroare", "Inca nu esti logat!", "OK");
                await Navigation.PopAsync();
                await Navigation.PushAsync(new LoginPage());


            } else
            {
                List<Pizza> allPizzas = dbService.GetPizzas();
                var asyncConnection = AsyncConnection.GetInstance();

                var comenzi = await SQLiteNetExtensionsAsync.Extensions.ReadOperations.
                   GetAllWithChildrenAsync<Comanda>(asyncConnection);

                var comenzileUseruluiLogat = comenzi.Where(comanda => comanda.Profil.Id == profil.Id);

                List<Comanda> list = new List<Comanda>();

                foreach (var comanda in comenzileUseruluiLogat)
                {
                    list.Add(comanda);
                }


                foreach (var pizza in allPizzas)
                {
                    int nrTotalPizzaDinComanda = 0;
                    foreach (var comanda in list)
                    {

                        var foundPizza = comanda.Pizze.Where(x => x.Id == pizza.Id).FirstOrDefault();
                        if (foundPizza != null)
                        {
                            var index = comanda.Pizze.IndexOf(foundPizza);
                            nrTotalPizzaDinComanda += comanda.cantitatiPizza[index];
                        }



                    }

                    if (nrTotalPizzaDinComanda > 0)
                    {
                        dateGrafic.Add(new Entry(nrTotalPizzaDinComanda)
                        {
                            Label = pizza.Denumire,
                            ValueLabel = nrTotalPizzaDinComanda.ToString(),
                            Color = SKColor.Parse("#406343")
                        });
                    }





                }

                pizzaChart.Chart = new BarChart()
                {
                    Entries = dateGrafic,
                    LabelColor = SKColor.Parse("#406343"),
                    LabelTextSize = 40,
                    LabelOrientation = Orientation.Vertical

                };
            }
           
        }
    }
}