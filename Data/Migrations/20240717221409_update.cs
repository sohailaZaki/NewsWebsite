using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace news_websites.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f9c69dc-dda1-4dba-a38c-ef495f9ce7a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b86909f2-e155-43e7-a2ef-248091cf1b05");

            migrationBuilder.CreateTable(
                name: "roleViewModel",
                columns: table => new
                {
                    roleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    useRole = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleViewModel", x => x.roleId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56d13040-4a20-41e3-b287-605e8004c11e", "23b53fbd-e7ac-4088-a06e-965ae591dc2c", "Admin", "admin" },
                    { "7157ba1c-0117-46df-b2e5-f72e75125513", "0cc86163-d1c1-4898-a359-13c299f44483", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roleViewModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56d13040-4a20-41e3-b287-605e8004c11e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7157ba1c-0117-46df-b2e5-f72e75125513");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f9c69dc-dda1-4dba-a38c-ef495f9ce7a1", "7502ab85-8b19-47a9-bab8-fc38337ccb0c", "User", "user" },
                    { "b86909f2-e155-43e7-a2ef-248091cf1b05", "f5d0c35b-b679-4e8a-ba3f-a02739b65f42", "Admin", "admin" }
                });
        }
    }
}
