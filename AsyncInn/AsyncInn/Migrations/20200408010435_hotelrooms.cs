using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class hotelrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "HotelID", "RoomID", "PetFriendly", "Rate", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 1, false, 80.00m, 101 },
                    { 1, 2, true, 100.00m, 102 },
                    { 2, 1, false, 200.00m, 1200 },
                    { 2, 2, true, 220.00m, 1300 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelID", "RoomID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelID", "RoomID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelID", "RoomID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelID", "RoomID" },
                keyValues: new object[] { 2, 2 });
        }
    }
}
