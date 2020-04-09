using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTO
{
    // Hotels data transfer object that will normalize for viewer

    public class HotelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public List<HotelRoomsDTO> Rooms { get; set; }
    }
}
