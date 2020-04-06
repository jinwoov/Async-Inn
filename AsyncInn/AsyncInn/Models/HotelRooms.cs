using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{   //This is a Join Table with Payload.
    public class HotelRooms
    {   // HotelID and RoomID constitute a Composite Key for the model HotelRooms.
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public bool PetFriendly { get; set; }
        public decimal Rate { get; set; }

        // Below are the Nav Properties for HotelRooms. It links to the Hotel and Room models. 
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }

    }
}
