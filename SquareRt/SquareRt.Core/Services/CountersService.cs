using System.Collections.Generic;
using System.Threading.Tasks;
using SquareRt.Core.Models;
using SquareRt.Core.Repositories;

namespace SquareRt.Core.Services
{
    public class CountersService : ICountersService
    {
         readonly ICountersRepository repository;

         public CountersService(ICountersRepository repository)
         {
             this.repository = repository;
         }

         public async Task<Counter> AddNewCounter(string name)
         {
             var counter = new Counter {Name = name};
             await repository.Save(counter).ConfigureAwait(false);
             return counter;
         }

         public Task<List<Counter>> GetAllCounters()
         {
             return repository.GetAll();
         }

         public Task DeleteCounter(Counter counter)
         {
             return repository.Delete(counter);
         }

         public Task IncrementCounter(Counter counter)
         {
             counter.Count += 1;
             return repository.Save(counter);
         }
    }
}