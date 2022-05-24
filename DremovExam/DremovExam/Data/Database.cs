using DremovExam.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DremovExam.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Number>().Wait();
        }

        public Task<List<Number>> GetNumbersAsync()
        {
            return database.Table<Number>().ToListAsync();
        }

        public Task<Number> GetNumberAsync(int id)
        {
            return database.Table<Number>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNumberAsync(Number num)
        {
            if (num.ID != 0)
            {
                return database.UpdateAsync(num);
            }
            else
            {
                return database.InsertAsync(num);
            }
        }

        public Task<int> DeleteNumberAsync(Number num)
        {
            return database.DeleteAsync(num);
        }
    }
}
