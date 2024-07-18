using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace news_websites.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRoleView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69a27b76-abc0-4399-aead-83df51300d92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f35ef09e-8e42-4ed7-81b9-eecd7a29a452");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f9c69dc-dda1-4dba-a38c-ef495f9ce7a1", "7502ab85-8b19-47a9-bab8-fc38337ccb0c", "User", "user" },
                    { "b86909f2-e155-43e7-a2ef-248091cf1b05", "f5d0c35b-b679-4e8a-ba3f-a02739b65f42", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f9c69dc-dda1-4dba-a38c-ef495f9ce7a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b86909f2-e155-43e7-a2ef-248091cf1b05");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "69a27b76-abc0-4399-aead-83df51300d92", "a5a995ec-7aa4-44cf-98fb-534783b5469a", "Admin", "admin" },
                    { "f35ef09e-8e42-4ed7-81b9-eecd7a29a452", "8f6eec67-0951-4d95-ac32-64ffc76b220e", "User", "user" }
                });
        }
    }
}
