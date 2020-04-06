using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        // constructor that will use for database migration
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext>options) : base(options)
        {

        }

        /// <summary>
        /// Composite key associate present
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRooms>().HasKey(x => new { x.HotelID, x.RoomID });
            modelBuilder.Entity<RoomAmenities>().HasKey(x => new { x.AmenitiesID, x.RoomID });
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Capitol Hill",
                    Layout = (Layout) 0
                },
                new Room
                {
                    ID = 2,
                    Name = "Queen Anne",
                    Layout = (Layout) 2
                },
                new Room
                {
                    ID = 3,
                    Name = "Lake City",
                    Layout = (Layout)2
                },
                new Room
                {
                    ID = 4,
                    Name = "Beacon Hill",
                    Layout = (Layout)1
                },
                new Room
                {
                    ID = 5,
                    Name = "Pike Place",
                    Layout = (Layout)0
                },
                new Room
                {
                    ID = 6,
                    Name = "Columbia City",
                    Layout = (Layout)1
                }
                ) ;

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Seattle",
                    StreetAddress = "85 Pike St",
                    City = "Seattle",
                    State = "WA",
                    Phone = "(206) 682-7453"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Bellevue",
                    StreetAddress = "575 Bellevue Sq",
                    City = "Bellevue",
                    State = "WA",
                    Phone = "(425) 646-3660"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Lynnwood",
                    StreetAddress = "3000 184th St. SW",
                    City = "Lynnwood",
                    State = "WA",
                    Phone = "(425) 771-1121"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Tukwila",
                    StreetAddress = "2800 Southcenter Mall",
                    City = "Tukwila",
                    State = "WA",
                    Phone = "(206) 246-0423"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Federal Way",
                    StreetAddress = "1928-B South Commons",
                    City = "Federal Way",
                    State = "WA",
                    Phone = "(253) 275-3303"
                }
            );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Coffee Maker"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Minibar"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Water View"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "King Bed"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Jacuzi Tub"
                }


            );
        }

        // dbsets for models
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<HotelRooms> HotelRoom { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
