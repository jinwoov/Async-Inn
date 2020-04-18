using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsyncInnWebApp.Models
{
    public class HotelRooms
    {
        [JsonPropertyName("hotelID")]
        public int HotelID { get; set; }

        [JsonPropertyName("roomNumber")]
        public int RoomNumber { get; set; }

        [JsonPropertyName("rate")]
        public decimal Rate { get; set; }

        [JsonPropertyName("petFriendly")]
        public bool PetFriendly { get; set; }

        [JsonPropertyName("roomID")]
        public int RoomID { get; set; }

        [JsonPropertyName("room")]
        public Room Room { get; set; }
    }
}
