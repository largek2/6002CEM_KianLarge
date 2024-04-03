using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace _6003CEM.Services
{
    public class LocalDbService
    {
        private const string DB_NAME = "local.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<List>().Wait(); 
        }

        public Task<List<List>> GetList()
        {
            return _connection.Table<List>().ToListAsync();
        }

        public Task<List> GetById(int id)
        {
            return _connection.Table<List>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Create(List list)
        {
            return _connection.InsertAsync(list);
        }

        public Task Update(List list)
        {
            return _connection.UpdateAsync(list);
        }

        public Task Delete(List list)
        {
            return _connection.DeleteAsync(list);
        }
    }
}