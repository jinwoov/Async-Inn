using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{   //RoomAmenities is a pure Join Table.
    public class RoomAmenities
    {   // RoomID and AmenitiesID constitute a Composite Key for RoomAmenities.
        public int RoomID { get; set; }
        public string AmenitiesID { get; set; }

        // Below are the Nav Properties for RoomAmenities. This model links to the Room and Amenities models. 
        public Room Room { get; set; }
        public Amenities Amenities { get; set; }
    }
}
