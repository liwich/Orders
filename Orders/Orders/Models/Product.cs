using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Orders.Models
{
    [DataTable("Products")]
    public class Product
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Price")]
        public double Price { get; set; }
         
    }
}