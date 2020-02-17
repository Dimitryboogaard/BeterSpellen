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
        public static VraagModel VraagVanDeDag;
        public static List<OptieModel> opties;
        public static List<VraagModel> VragenVanDeDag;
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



            

            var vragen = await App.Database.GetVragenAsync();

            VraagVanDeDag = await App.Database.GetVragenAsync(1);
            
            //foreach (var vraagun in vragen.Where(x => x.Datum == DateTime.Now.Date))
            //{
            //    VragenVanDeDag.Add(vraagun);
            //}

            opties = await App.Database.GetOptiesAsync();

            List<string> Antwoorden = new List<string>();
            foreach (var antwoorden in opties.Where(x => x.VraagId == VraagVanDeDag.Id))
            {
                Antwoorden.Add(antwoorden.Optie);
            }
            listView.ItemsSource = Antwoorden;
            VraagLbl.Text = VraagVanDeDag.Vraag;

        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var optie = opties.Where(x => x.VraagId == VraagVanDeDag.Id && x.Juist == true).FirstOrDefault();
            if (e.SelectedItem == optie.Optie && optie.Juist == true)
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
                Id = 1,
                Vraag = "De auto maakte een gevaarlijke...",
                Datum = DateTime.Now.Date
            });

            await App.Database.SaveOptieAsync(new OptieModel { Id = 1, Optie = "Manoeuvre", VraagId = 1, Juist = true });
            await App.Database.SaveOptieAsync(new OptieModel { Id = 2, Optie = "Manouvre", VraagId = 1, Juist = false });
            await App.Database.SaveOptieAsync(new OptieModel { Id = 3, Optie = "Manoevre", VraagId = 1, Juist = false });
            await App.Database.SaveOptieAsync(new OptieModel { Id = 4, Optie = "Maneuvre", VraagId = 1, Juist = false });

            await App.Database.SaveVraagAsync(new VraagModel
            {
                Id = 2,
                Vraag = "Wij hebben heerlijk aan het water...",
                Datum = DateTime.Now.Date
            });

            await App.Database.SaveOptieAsync(new OptieModel { Optie = "Gelunchd", VraagId = 2, Juist = false });
            await App.Database.SaveOptieAsync(new OptieModel { Optie = "Geluncht", VraagId = 2, Juist = true });
            await App.Database.SaveOptieAsync(new OptieModel { Optie = "Gelluncht", VraagId = 2, Juist = false });
            await App.Database.SaveOptieAsync(new OptieModel { Optie = "Gellunchd", VraagId = 2, Juist = false });

            DateTime date = DateTime.Now.Date;
            await App.Database.SaveVraagAsync(new VraagModel
            {
                Id = 3,
                Vraag = "Toen de oude dame struikelde, schoot haar zoon snel...",
                Datum = date.AddDays(10)
            });

            await App.Database.SaveOptieAsync(new OptieModel { Optie = "Ter hulp", VraagId = 2, Juist = false });
            await App.Database.SaveOptieAsync(new OptieModel { Optie = "Ten hulp", VraagId = 2, Juist = false });
            await App.Database.SaveOptieAsync(new OptieModel { Optie = "Te hulp", VraagId = 2, Juist = true });
            await App.Database.SaveOptieAsync(new OptieModel { Optie = "Hulp", VraagId = 2, Juist = false });
                Vraag = "Vraag 1",
                
            }) ;
        }

    }
    }

