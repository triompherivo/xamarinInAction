using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SquareRt.Core
{
    public class SquareRtCalculator : ISquareRtCalculator
    {
        readonly HttpClient httpClient = new HttpClient();

        public SquareRtCalculator()
        {
            httpClient.DefaultRequestHeaders
                .Add("Ocp-Apim-Subscription-Key", "e358d9d76a1f40c3b88eca1cbe5f837c");
        }

        //public async Task<double> Calculate(double number)
        //{
        //    var url = "https://api.cognitive.microsoft.com/bing/v7.0/search?" + $"q=sqrt({number})&responseFilter=Computation";
        //    var response = await httpClient.GetAsync(url).ConfigureAwait(false);
        //    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        //    var squareRt = JsonConvert.DeserializeObject<SquareRootResponse>(json);
        //    return squareRt.Computation.Value;
        //}
        public double Calculate(double number) => Math.Sqrt(number);
    }
}
