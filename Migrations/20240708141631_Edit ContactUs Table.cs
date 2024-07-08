using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace news_websites.Migrations
{
    /// <inheritdoc />
    public partial class EditContactUsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ContactUs");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Subject",
                table: "ContactUs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "ContactUs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
