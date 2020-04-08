using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        //Create
        Task<AmenitiesDTO> CreateAmenity(Amenities amenities);

        //Read
        Task<AmenitiesDTO> GetAmenity(int ID);

        //Read all amenities
        Task<List<AmenitiesDTO>> GetAmenities();

        //Update
        Task UpdateAmenity(Amenities amenities);

        //Delete
        Task<Amenities> DeleteAmenity(int id);
    }
}
