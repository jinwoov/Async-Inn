using AsyncInnWebApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncInnWebApp.Models.Services
{
    /// <summary>
    /// Hotel service class for hotel
    /// </summary>
    public class HotelService : IHotelManager
    {
        private static readonly HttpClient client = new HttpClient();
        public Task<List<Hotel>> GetAllHotels()
        {
            // Set destination
            var baseUrl = @"https://localhost:44398/api";
        }

        public Task GetHotelByID()
        {
            throw new NotImplementedException();
        }
    }
}
