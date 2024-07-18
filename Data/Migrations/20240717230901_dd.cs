using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace news_websites.Data.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "406b6108-2cfa-4f79-b922-1204ea658d21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b87a77e-a4b1-4cf0-bf08-aed171b4600f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b11325c-8b20-4600-9cbb-2b857088ec3e", "868f9601-39c0-4d20-9163-744b99bd7919", "Admin", "admin" },
                    { "c8aec8b9-7a2b-4c68-ba6b-ea779c0b9903", "3ccdd8c5-9711-4f4e-af1b-d99478db9cb1", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b11325c-8b20-4600-9cbb-2b857088ec3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8aec8b9-7a2b-4c68-ba6b-ea779c0b9903");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "406b6108-2cfa-4f79-b922-1204ea658d21", "6fb40c7b-2916-49fa-bd70-ce29627ca66e", "Admin", "admin" },
                    { "9b87a77e-a4b1-4cf0-bf08-aed171b4600f", "05ff4b4a-b72b-4d00-a526-b3ac71df9150", "User", "user" }
                });
        }
    }
}
