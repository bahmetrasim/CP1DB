using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Android.Util;
using System.Diagnostics;

namespace CP1
{

    public class AlloyDatabase
    {
        private SQLiteAsyncConnection database;
        public AlloyDatabase(string dbPatch)
        {

            database = new SQLiteAsyncConnection(dbPatch);
            database.CreateTableAsync<Alloy>();

        }


        public Task<List<Alloy>> GetItemsAsync()
        {
            return database.Table<Alloy>().ToListAsync();
        }

        public Task<List<Alloy>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Alloy>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Alloy> GetItemAsync(int id)
        {
            var list1 = database.Table<Alloy>().Where(i => i.AlloyID == id).ToListAsync();
            return database.Table<Alloy>().Where(i => i.AlloyID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Alloy item)
        {
            if (item.AlloyID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Alloy item)
        {
            return database.DeleteAsync(item);
        }

        public async Task<List<Alloy>> GetAlloyList()
        {
            List<Alloy> alloys = await database.QueryAsync<Alloy>("SELECT AlloyName From Alloy");
            return alloys;
        }
        public async Task<List<string>> Getalloyaslist()
        {
            List<string> alloys = new List<string>();
            var query = database.Table<Alloy>().Where(s => s.AlloyName.Contains("A"));
            var result = await query.ToListAsync();
            foreach (var s in result)
            {
                alloys.Add(s.AlloyName);
            }
            return alloys;
        }

        public async Task<IEnumerable<string>> Getalllist()
        {
            try
            {
                var list = await database.ExecuteScalarAsync<IEnumerable<string>>("SELECT AlloyName FROM Alloy");
                return list;
            }
            catch (SQLiteException ex)
            {
                Log.Error("Hata", ex.Message);
                return new List<string>();
            }
        }

    }
}

