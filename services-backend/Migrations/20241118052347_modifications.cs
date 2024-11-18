using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services_backend.Migrations
{
    /// <inheritdoc />
    public partial class modifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TypeServices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "TypeServices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PolicyCancelation",
                table: "TypeServices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TypeServices");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "TypeServices");

            migrationBuilder.DropColumn(
                name: "PolicyCancelation",
                table: "TypeServices");
        }
    }
}
