using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addedSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirConditioning",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "CoffeMaker",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "Fridge",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "Microwave",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "MiniBar",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "OceanView",
                table: "Amenities");

            migrationBuilder.AddColumn<string>(
                name: "item",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "item" },
                values: new object[,]
                {
                    { 1, "Microwave" },
                    { 2, "Fridge" },
                    { 3, "OceanView" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Country", "Name", "Phone", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Seattle", "USA", "WestInn", "(206)-555-1212", "WA", "123 4th ave" },
                    { 2, "Everett", "USA", "DaysInn", "(425)-773-1212", "WA", "456 hwy 99" },
                    { 3, "San Diego", "USA", "DoggyInn", "(619)-555-1212", "CA", "418 Palmera Dr" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Pups Place" },
                    { 2, 2, "Family Fort" },
                    { 3, 1, "Solo Suite" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "item",
                table: "Amenities");

            migrationBuilder.AddColumn<string>(
                name: "AirConditioning",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoffeMaker",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fridge",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Microwave",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiniBar",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OceanView",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
