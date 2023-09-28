using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

public record class Feature(string LocationName, string Address);
class Program
{
    static void Main(string[] args)
    {
        string url = "https://services8.arcgis.com/nc3uaBB71kACj1DV/ArcGIS/rest/services/SamplePOIs/FeatureServer/0/";

        using (HttpClient httpClient = new HttpClient())
        {

            // GET DATA
            Console.WriteLine("Fetching Data..");
            HttpResponseMessage response = httpClient.GetAsync(url + "query?where=1%3D1&outFields=*&f=json").Result;
            string content = response.Content.ReadAsStringAsync().Result;

            JObject jsonResponse = JObject.Parse(content);
            JArray features = (JArray)jsonResponse["features"];

            foreach (JObject feature in features)
            {
                Console.WriteLine($"Location Name: {feature["attributes"]["Location Name"]}");
                Console.WriteLine($"Address: {feature["attributes"]["Address"]}");
            }


            // ADD DATA
            Console.WriteLine("\n**********************************************************************");
            Console.WriteLine("Adding new Data");
            Console.WriteLine("**********************************************************************");
            string addUrl = url + "addFeatures?f=json";
            var values = new Dictionary<string, string>
            {
                { "features", "[ { \"attributes\": { \"Location_N\": \"Test Location from code\", \"Address\": \"Test Address from code\" } } ]" },
                { "f", "json" }
            };

            var requestContent = new FormUrlEncodedContent(values);

            HttpResponseMessage responseAdd = httpClient.PostAsync(addUrl, requestContent).Result;
            string contentAdd = responseAdd.Content.ReadAsStringAsync().Result;

            Console.WriteLine(contentAdd);

            //UPDATE DATA
            Console.WriteLine("\n**********************************************************************");
            Console.WriteLine("Updating Data");
            Console.WriteLine("**********************************************************************");
            string updateUrl = url + "updateFeatures?f=json";
            var valuesUpdate = new Dictionary<string, string>
            {
                { "features", "[ { \"attributes\": { \"FID\": 1, \"Location_N\": \"Test Location from code UPDATED\", \"Address\": \"Test Address from code UPDATED\" } } ]" },
                { "f", "json" }
            };

            var requestContentUpdate = new FormUrlEncodedContent(valuesUpdate);

            HttpResponseMessage responseUpdate = httpClient.PostAsync(updateUrl, requestContentUpdate).Result;
            string contentUpdate = responseUpdate.Content.ReadAsStringAsync().Result;

            Console.WriteLine(contentUpdate);

            //DELETE DATA
            Console.WriteLine("\n**********************************************************************");
            Console.WriteLine("Deleting Data");
            Console.WriteLine("**********************************************************************");
            string deleteUrl = url + "deleteFeatures?f=json";
            var valuesDelete = new Dictionary<string, string>
            {
                { "objectIds", "1" },
                { "f", "json" }
            };

            var requestContentDelete = new FormUrlEncodedContent(valuesDelete);

            HttpResponseMessage responseDelete = httpClient.PostAsync(deleteUrl, requestContentDelete).Result;
            string contentDelete = responseDelete.Content.ReadAsStringAsync().Result;

            Console.WriteLine(contentDelete);

        }
    }
}
