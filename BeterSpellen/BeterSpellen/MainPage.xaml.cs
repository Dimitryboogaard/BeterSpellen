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

            if (!App.Database.GetNotesAsync().Result.Any())
            {
                SeedDatabase();

            }




            listView.ItemsSource = await App.Database.GetNotesAsync();
            var vraag = await App.Database.GetNotesAsync();

        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Vraag vraag = (Vraag)e.SelectedItem;

            if (e.SelectedItemIndex == vraag.GoedeAntwoord)
            {
                GoedOfFout.Text = Convert.ToString(vraag.GoedeAntwoord);
            }

            else
            {
                GoedOfFout.Text = Convert.ToString(vraag.GoedeAntwoord); 
            }
        }


        public async void SeedDatabase()
        {
            await App.Database.SaveVraagAsync(new Vraag
            {
                DagVraag = "Vraag 1",
                Antwoord1 = "Antwoord 1",
                Antwoord2 = "Antwoord 2",
                Antwoord3 = "Antwoord 3",
                Antwoord4 = "Antwoord 4",
                GoedeAntwoord = 3
            });
        }

    }
    }
