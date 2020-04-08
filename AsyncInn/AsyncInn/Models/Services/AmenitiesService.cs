﻿using AsyncInn.Data;
using AsyncInn.Models.DTO;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    /// <summary>
    /// This is to apply interface to the service
    /// </summary>
    public class AmenitiesService : IAmenitiesManager
    {
        private AsyncInnDbContext _context { get; }

        public AmenitiesService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is to create a amenity to the database
        /// </summary>
        /// <param name="amenities">Amenity object that is being created</param>
        /// <returns>Object that's been created</returns>
        public async Task<Amenities> CreateAmenity(Amenities amenities)
        {
            _context.Add(amenities);

            await _context.SaveChangesAsync();

            return amenities;
        }

        /// <summary>
        /// Deleting existing amenity in our database
        /// </summary>
        /// <param name="id">id that user chose</param>
        /// <returns>Amenity that has been deleted</returns>
        public async Task<Amenities> DeleteAmenity(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);

            _context.Remove(amenity);

            await _context.SaveChangesAsync();

            return amenity;
        }

        /// <summary>
        /// Delegating the ToListAsync method to occur using asynchronous method of GetAmenities
        /// </summary>
        /// <returns>List of amenities</returns>
        public async Task<List<Amenities>> GetAmenities() => await _context.Amenities.ToListAsync();

        /// <summary>
        /// Delegating the FindAsync method to occur using asynchronous method of GetAmenity
        /// </summary>
        /// <param name="ID">Id of the amenity</param>
        /// <returns>the specific amenity</returns>
        public async Task<AmenitiesDTO> GetAmenity(int ID)
        {
            Amenities amenities = await _context.Amenities.FindAsync(ID);
            return ConvertToDTO(amenities);
        }

        /// <summary>
        /// This is to update an existing amenity
        /// </summary>
        /// <param name="amenities">Amenities object that is being passed in</param>
        public async Task UpdateAmenity(Amenities amenities)
        {
            _context.Update(amenities);

            await _context.SaveChangesAsync();
        }

        public AmenitiesDTO ConvertToDTO(Amenities amenities)
        {
            AmenitiesDTO adto = new AmenitiesDTO()
            {
                Name = amenities.Name,
                ID = amenities.ID
            };

            return adto;
        }   

    }
}
