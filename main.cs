using System.text;
using System.Threadingtasks;
using RestSharp;

namespace Countries
{
    class Program
    {
        static void Main(string[] args) {
            string url = "https://xc-countries-api.herokuapp.com/api/countries/";
            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            Console.WriteLine(data);
        }
    }
}
