using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{   //This is a regular table.
    public class Hotel
    {   // ID is the Primary Key of Hotel. The other properties are info about the hotel.
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }

        //Below is the Nav Property. This model links to HotelRooms.

        public List<HotelRooms> HotelRoom = new List<HotelRooms>();
    }
}
