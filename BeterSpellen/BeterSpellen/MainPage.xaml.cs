using BeterSpellen.Data;
using BeterSpellen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace BeterSpellen
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static Vraag VraagVanDeDag;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!App.Database.DatabaseExists())
            {

                SeedDatabase();
            }

            if (!App.Database.GetVragenAsync().Result.Any())
            {
                SeedDatabase();

            }



            

            var vragen = App.Database.GetVragenAsync();

            VraagVanDeDag = await App.Database.GetVragenAsync(1);
            List<Vraag> list = await App.Database.GetVragenAsync();

            List<string> Antwoorden = new List<string>();
            foreach (var antwoorden in list.Where(x => x.VraagID == VraagVanDeDag.VraagID))
            {
                Antwoorden.Add(antwoorden.Antwoord1);
                Antwoorden.Add(antwoorden.Antwoord2);
                Antwoorden.Add(antwoorden.Antwoord3);
                Antwoorden.Add(antwoorden.Antwoord4);
            }
            listView.ItemsSource = Antwoorden;
            VraagLbl.Text = VraagVanDeDag.DagVraag;

        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var vraag = e.SelectedItem;
            if (e.SelectedItemIndex == VraagVanDeDag.GoedeAntwoord)
            {
                GoedOfFout.Text = "Goed";
            }

            else
            {
                GoedOfFout.Text = "Fout"; 
            }

        }


        public async void SeedDatabase()
        {
            await App.Database.SaveVraagAsync(new VraagModel
            {
                Vraag = "Vraag 1",
                
            }) ;
        }

    }
    }
