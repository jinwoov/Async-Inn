using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsyncInnWebApp.Models
{
    public class Room
    {
        //ID is the Primary Key for Room. 
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        // Layout is an ENUM

        [JsonPropertyName("layout")]
        public string Layout { get; set; }

        [JsonPropertyName("amenities")]
        public List<Amenities> Amenities { get; set; }

    }
}
