using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Save__plan_your_trips.Migrations
{
    /// <inheritdoc />
    public partial class convertimagestolist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Album",
                newName: "ImageList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageList",
                table: "Album",
                newName: "Image");
        }
    }
}
