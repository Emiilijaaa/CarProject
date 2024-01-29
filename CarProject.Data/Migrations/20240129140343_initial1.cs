using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehicleTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "VehicleTypes");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "VehicleTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
