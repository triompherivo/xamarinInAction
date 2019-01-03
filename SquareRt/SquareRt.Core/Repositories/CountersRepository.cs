using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using PCLStorage;
using SquareRt.Core.Models;
using SQLite;

namespace SquareRt.Core.Repositories
{
    public class CountersRepository : ICountersRepository
    {
         readonly SQLiteAsyncConnection connection;

         public CountersRepository()
         {
             var local = FileSystem.Current.LocalStorage.Path;
             var datafile = Path.Combine(local, "counters.db3");
             connection=new SQLiteAsyncConnection(datafile);
             connection.GetConnection().CreateTable<Counter>();

         }

         public Task Save(Counter counter)
         {
             return connection.InsertOrReplaceAsync(counter);
         }

         public Task<List<Counter>> GetAll()
         {
             return connection.Table<Counter>().ToListAsync();
         }

         public Task Delete(Counter counter)
         {
             return connection.DeleteAsync(counter);
         }
    }
}