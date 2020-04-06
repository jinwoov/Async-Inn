using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{   //This is a regular table.
    public class Amenities
    {   /// <summary>
    /// ID is the Amenities Primary Key, Name is the name of the amenities. 
    /// </summary>
        public int ID { get; set; }
        public string Name { get; set; }

        // These are the Nav Properies, this model links to RoomAmenities. 
        List<RoomAmenities> RoomAmenities = new List<RoomAmenities>();
    }
}
