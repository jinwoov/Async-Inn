﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInnWebApp.Models;
using AsyncInnWebApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsyncInnWebApp.Controllers
{
    public class HotelController : Controller
    {
        //The below is creating the local property for hotel interface
        private IHotelManager _hotel;

        //The below is brining in the IHotelManager interface into our controller
        public HotelController(IHotelManager hotel)
        {
            _hotel = hotel;
        }

        // Getting all the hotels
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _hotel.GetAllHotels();

            return View(result);
        }


        // choosing the specific hotel that user clicked and render the information
        [HttpPost]
        public async Task<IActionResult> AHotel(int id)
        {
            Hotel hotel = await _hotel.GetHotelByID(id);
            return View(hotel);
        }

    }
}
