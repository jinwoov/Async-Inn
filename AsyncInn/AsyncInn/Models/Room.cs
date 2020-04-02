using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }


        // nav properties
        List<RoomAmenities> RoomAmenities = new List<RoomAmenities>();
        List<HotelRooms> HotelRoom = new List<HotelRooms>();
    }

    /// <summary>
    /// Enum for the layout of the rooms
    /// </summary>
    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}
