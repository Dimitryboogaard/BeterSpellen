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
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Vraag>().Wait();
        }

        public Task<List<Vraag>> GetNotesAsync()
        {
            return _database.Table<Vraag>().ToListAsync();
        }

        public Task<Vraag> GetNoteAsync(int id)
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

        public Task<int> DeleteNoteAsync(Vraag vraag)
        {
            return _database.DeleteAsync(vraag);
        }

        public Task<int> SaveVraagAsync(Vraag vraag)
        {
            return _database.InsertAsync(vraag);
        }
    }
}
