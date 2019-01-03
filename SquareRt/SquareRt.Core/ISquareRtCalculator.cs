using System;
using System.Threading.Tasks;
namespace SquareRt.Core
{
    public interface ISquareRtCalculator
    {
        double Calculate(double number);
        //Task<double> Calculate(double number);
    }
}
