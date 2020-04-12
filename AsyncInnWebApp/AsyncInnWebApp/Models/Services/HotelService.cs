using AsyncInnWebApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsyncInnWebApp.Models.Services
{
    public class HotelService : IHotelManager
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// The below method gets all the hotels from our 3rd party (is it really 3rd party in this case since we made the api?) api.
        /// </summary>
        /// <returns>List of hotels</returns>
        public async Task<List<Hotel>> GetAllHotels()
        {
            //The below sets the destination address
            var baseUrl = @"https://localhost:44398/api";
            string route = "hotels";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseUrl}/{route}");
            // The below will convert JSON to C#
            var result = await JsonSerializer.DeserializeAsync<List<Hotel>>(streamTask);

            return result;

        }

        public async Task<Hotel> GetHotelByID(int ID)
        {
            //The below sets the destination address
            var baseUrl = @"https://localhost:44398/api";
            string route = "hotels";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseUrl}/{route}/{ID}");
            // The below will convert JSON to C#
            var result = await JsonSerializer.DeserializeAsync<Hotel>(streamTask);

            return result;

        }
    }
}
