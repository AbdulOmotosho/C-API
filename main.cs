using System.text;
using System.Threadingtasks;
using RestSharp;

namespace Countries
{
    class Program
    {
        static void Main(string[] args) {
            string url = "https://xc-countries-api.herokuapp.com/api/countries/";
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Get(request);
            Console.WriteLine(response.Content.ToString());
            Console.Read();
        }
    }
}