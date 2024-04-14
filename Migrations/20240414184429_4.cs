using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Save__plan_your_trips.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");

            migrationBuilder.AddColumn<string>(
                name: "Fifth",
                table: "ScheduledTrip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "First",
                table: "ScheduledTrip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fourth",
                table: "ScheduledTrip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ScheduledTrip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Second",
                table: "ScheduledTrip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Third",
                table: "ScheduledTrip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fifth",
                table: "ScheduledTrip");

            migrationBuilder.DropColumn(
                name: "First",
                table: "ScheduledTrip");

            migrationBuilder.DropColumn(
                name: "Fourth",
                table: "ScheduledTrip");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ScheduledTrip");

            migrationBuilder.DropColumn(
                name: "Second",
                table: "ScheduledTrip");

            migrationBuilder.DropColumn(
                name: "Third",
                table: "ScheduledTrip");

            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledTripId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDo_ScheduledTrip_ScheduledTripId",
                        column: x => x.ScheduledTripId,
                        principalTable: "ScheduledTrip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ScheduledTripId",
                table: "ToDo",
                column: "ScheduledTripId");
        }
    }
}
