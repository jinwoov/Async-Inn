using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        //Create
        Task<Amenities> CreateAmenity(Amenities amenities);

        //Read
        Task<Amenities> GetAmenity(int ID);

        //Read all amenities
        Task<List<Amenities>> GetAmenities();

        //Update
        Task UpdateAmenity(Amenities amenities);

        //Delete
        Task<Amenities> DeleteAmenity(int id);
    }
}
