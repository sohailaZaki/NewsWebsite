using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace news_websites.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatingtabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "406b6108-2cfa-4f79-b922-1204ea658d21", "6fb40c7b-2916-49fa-bd70-ce29627ca66e", "Admin", "admin" },
                    { "9b87a77e-a4b1-4cf0-bf08-aed171b4600f", "05ff4b4a-b72b-4d00-a526-b3ac71df9150", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "406b6108-2cfa-4f79-b922-1204ea658d21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b87a77e-a4b1-4cf0-bf08-aed171b4600f");

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
    }
}
