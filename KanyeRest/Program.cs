using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KanyeRest
{
    class Program
    {
        static void Main(string[] args)
        {
            var kanyeUrl = "https://api.kanye.rest/";
            var ronSwansonUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var client = new HttpClient();

            var kanyeResponse = client.GetStringAsync(kanyeUrl).Result;
            var ronResponse = client.GetStringAsync(ronSwansonUrl).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            

            var count = 5;

            for(var i = 0; i < count; i++)
            {
                Console.WriteLine($"Kanye: {kanyeQuote}");
                Console.WriteLine($"Ron:  {ronQuote}");
                Console.WriteLine();
                Console.WriteLine();
            }
          
        }
    }
}
