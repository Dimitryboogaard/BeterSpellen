using BeterSpellen.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BeterSpellen.Data
{
    public class BeterSpellenDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public BeterSpellenDatabase(string dbPath)
        {
            //var vraag1 = new Vraag { VraagID = 1, DagVraag = "De auto maakte een gevaarlijke...", Antwoord1 = "Manoeuvre", Antwoord2 = "Manouvre", Antwoord3 = "Manoevre", Antwoord4 = "Maneuvre", GoedeAntwoord = 1 };
            //var vraag2 = new Vraag { VraagID = 2, DagVraag = "Wij hebben heerlijk aan het water...", Antwoord1 = "Gelunchd", Antwoord2 = "Geluncht", Antwoord3 = "Gelluncht", Antwoord4 = "Gellunchd", GoedeAntwoord = 2 };
            //var vraag3 = new Vraag { VraagID = 3, DagVraag = "Toen de oude dame struikelde, schoot haar zoon snel...", Antwoord1 = "Ter hulp", Antwoord2 = "Ten hulp", Antwoord3 = "Te hulp", Antwoord4 = "hulp", GoedeAntwoord = 3 };
            //_database = new SQLiteAsyncConnection(dbPath);
            //_database.CreateTableAsync<Vraag>().Wait();
            //_database.InsertAsync(vraag1);
            //_database.InsertAsync(vraag2);
            //_database.InsertAsync(vraag3);

            //var dag1 = new DagModel
            //{
            //    Id = 1,
            //    datum = DateTime.Now.Date
            //};
            //var vraag1 = new VraagModel
            //{
            //    Id = 1,
            //    Vraag = "De auto maakte een gevaarlijke...",
            //};

            //var optie1 = new OptieModel{ Id = 1, Optie = "Manoeuvre", VraagId = 1, Juist = true };
            //var optie2 = new OptieModel { Id = 2, Optie = "Manouvre", VraagId = 1, Juist = false };
            //var optie3 = new OptieModel { Id = 3, Optie = "Manoevre", VraagId = 1, Juist = false };
            //var optie4 = new OptieModel { Id = 4, Optie = "Maneuvre", VraagId = 1, Juist = false };


            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DagModel>().Wait();
            _database.CreateTableAsync<VraagModel>().Wait();
            //_database.InsertAsync(vraag1);
            _database.CreateTableAsync<OptieModel>().Wait();
            //_database.InsertAsync(optie1);
            //_database.InsertAsync(optie2);
            //_database.InsertAsync(optie3);
            //_database.InsertAsync(optie4);
        }

        public Task<List<VraagModel>> GetVragenAsync()
        {
            return _database.Table<VraagModel>().ToListAsync();
        }

        public Task<VraagModel> GetVragenAsync(int id)
        {
            return _database.Table<VraagModel>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<OptieModel>> GetOptiesAsync()
        {
            return _database.Table<OptieModel>().ToListAsync();
        }

        public Task<OptieModel> GetOptiesAsync(int id)
        {
            return _database.Table<OptieModel>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<DagModel>> GetDagenAsync()
        {
            return _database.Table<DagModel>().ToListAsync();
        }

        public Task<DagModel> GetDagenAsync(int id)
        {
            return _database.Table<DagModel>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        internal bool DatabaseExists()
        {
            bool exists = File.Exists(Constants.DatabasePath);
            return exists;
        }


        public Task<int> SaveNoteAsync(VraagModel vraag)
        {
            if (vraag.Id != 0)
            {
                return _database.UpdateAsync(vraag);
            }
            else
            {
                return _database.InsertAsync(vraag);
            }
        }

        public Task<int> DeleteVragenAsync(VraagModel vraag)
        {
            return _database.DeleteAsync(vraag);
        }

        public Task<int> SaveVraagAsync(VraagModel vraag)
        {
            return _database.InsertAsync(vraag);
        }
        public Task<int> SaveOptieAsync(OptieModel optie)
        {
            return _database.InsertAsync(optie);
        }
    }
}
