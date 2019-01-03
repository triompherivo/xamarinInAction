using System;
using MvvmCross.Core.ViewModels;

namespace SquareRt.Core.ViewModels
{
    public class SquareRtViewModel :MvxViewModel
    {
        readonly ISquareRtCalculator calculator;
        public SquareRtViewModel(ISquareRtCalculator calculator)
        {
            this.calculator = calculator;
        }
        double result;
        public double Result
        {
            get { return result; }
            private set { SetProperty(ref result, value); }
        }
        double number;
        public double Number
        {
            get { //return Convert.ToString(number); 
                return Number;
              }
            set { //SetProperty(ref number, Convert.ToDouble(value));
                if (SetProperty(ref number, value))
                    Result = calculator.Calculate(number);
              }
        }
    }
}
