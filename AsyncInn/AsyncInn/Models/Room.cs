using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{   //This is a regular table.
    public class Room
    {   //ID is the Primary Key for Room. 
        public int ID { get; set; }
        public string Name { get; set; }
        // Layout is an ENUM
        public Layout Layout { get; set; }


        // Below are the Nav Properties for Room. It links to the RoomAmenities and HotelRooms models. 
        List<RoomAmenities> RoomAmenities = new List<RoomAmenities>();
        List<HotelRooms> HotelRoom = new List<HotelRooms>();
    }

    /// <summary>
    /// Enum for the layout of the rooms
    /// </summary>
    public enum Layout
    {
        Studio = 0,
        OneBedroom = 1,
        TwoBedroom = 2
    }
}
