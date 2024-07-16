using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace news_websites.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "69a27b76-abc0-4399-aead-83df51300d92", "a5a995ec-7aa4-44cf-98fb-534783b5469a", "Admin", "admin" },
                    { "f35ef09e-8e42-4ed7-81b9-eecd7a29a452", "8f6eec67-0951-4d95-ac32-64ffc76b220e", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69a27b76-abc0-4399-aead-83df51300d92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f35ef09e-8e42-4ed7-81b9-eecd7a29a452");
        }
    }
}
