using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquareRt.Core.Models;

namespace SquareRt.Core.Repositories
{
    public interface ICountersRepository
    {
        Task Save(Counter counter);
        Task<List<Counter>> GetAll();
        Task Delete(Counter counter);
    }
}
