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
            var vraag1 = new Vraag { VraagID = 1, DagVraag = "De auto maakte een gevaarlijke...", Antwoord1 = "Manoeuvre", Antwoord2 = "Manouvre", Antwoord3 = "Manoevre", Antwoord4 = "Maneuvre", GoedeAntwoord = 1 };
            var vraag2 = new Vraag { VraagID = 2, DagVraag = "Wij hebben heerlijk aan het water...", Antwoord1 = "Gelunchd", Antwoord2 = "Geluncht", Antwoord3 = "Gelluncht", Antwoord4 = "Gellunchd", GoedeAntwoord = 2 };
            var vraag3 = new Vraag { VraagID = 3, DagVraag = "Toen de oude dame struikelde, schoot haar zoon snel...", Antwoord1 = "Ter hulp", Antwoord2 = "Ten hulp", Antwoord3 = "Te hulp", Antwoord4 = "hulp", GoedeAntwoord = 3 };
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Vraag>().Wait();
            _database.InsertAsync(vraag1);
            _database.InsertAsync(vraag2);
            _database.InsertAsync(vraag3);
        }

        public Task<List<Vraag>> GetVragenAsync()
        {
            return _database.Table<Vraag>().ToListAsync();
        }

        public Task<Vraag> GetVragenAsync(int id)
        {
            return _database.Table<Vraag>()
                            .Where(i => i.VraagID == id)
                            .FirstOrDefaultAsync();
        }

        internal bool DatabaseExists()
        {
            bool exists = File.Exists(Constants.DatabasePath);
            return exists;
        }


        public Task<int> SaveNoteAsync(Vraag vraag)
        {
            if (vraag.VraagID != 0)
            {
                return _database.UpdateAsync(vraag);
            }
            else
            {
                return _database.InsertAsync(vraag);
            }
        }

        public Task<int> DeleteVragenAsync(Vraag vraag)
        {
            return _database.DeleteAsync(vraag);
        }

        public Task<int> SaveVraagAsync(Vraag vraag)
        {
            return _database.InsertAsync(vraag);
        }
    }
}
