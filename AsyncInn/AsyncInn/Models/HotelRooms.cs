using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRooms
    {
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public bool PetFriendly { get; set; }
        public decimal Rate { get; set; }

        // nav properties
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }

    }
}
