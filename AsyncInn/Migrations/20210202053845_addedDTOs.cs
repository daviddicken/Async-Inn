using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addedDTOs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Layout",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Layout",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Layout",
                value: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Layout",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Layout",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Layout",
                value: 1);
        }
    }
}
