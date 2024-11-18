using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services_backend.Migrations
{
    /// <inheritdoc />
    public partial class modifications2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorLight",
                table: "Establishments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ColorMedium",
                table: "Establishments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ColorStrong",
                table: "Establishments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorLight",
                table: "Establishments");

            migrationBuilder.DropColumn(
                name: "ColorMedium",
                table: "Establishments");

            migrationBuilder.DropColumn(
                name: "ColorStrong",
                table: "Establishments");
        }
    }
}
