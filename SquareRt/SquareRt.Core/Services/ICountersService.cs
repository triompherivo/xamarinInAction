using System.Collections.Generic;
using System.Threading.Tasks;
using SquareRt.Core.Models;

namespace SquareRt.Core.Services
{
    public interface ICountersService
    {
        Task<Counter> AddNewCounter(string name);
        Task<List<Counter>> GetAllCounters();
        Task DeleteCounter(Counter counter);
        Task IncrementCounter(Counter counter);

    }
}