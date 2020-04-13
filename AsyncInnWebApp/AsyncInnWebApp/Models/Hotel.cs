using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsyncInnWebApp.Models
{
    //Class that will be used as a reference for hotel data that is received from API server
    public class Hotel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("streetAddress")]
        public string StreetAddress { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]

        public string State { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }


    }
}
