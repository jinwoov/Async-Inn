using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelID", "RoomNumber" },
                keyValues: new object[] { 1, 102 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelID", "RoomNumber" },
                keyValues: new object[] { 2, 1300 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "HotelID", "RoomNumber", "PetFriendly", "Rate", "RoomID" },
                values: new object[] { 1, 102, true, 100.00m, 2 });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "HotelID", "RoomNumber", "PetFriendly", "Rate", "RoomID" },
                values: new object[] { 2, 1300, true, 220.00m, 2 });
        }
    }
}
