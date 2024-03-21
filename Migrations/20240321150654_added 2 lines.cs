using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Save__plan_your_trips.Migrations
{
    /// <inheritdoc />
    public partial class added2lines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "File",
                table: "Albums");
        }
    }
}
