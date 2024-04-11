using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Save__plan_your_trips.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScheduledTripId",
                table: "ToDo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ScheduledTripId",
                table: "ToDo",
                column: "ScheduledTripId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_ScheduledTrip_ScheduledTripId",
                table: "ToDo",
                column: "ScheduledTripId",
                principalTable: "ScheduledTrip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_ScheduledTrip_ScheduledTripId",
                table: "ToDo");

            migrationBuilder.DropIndex(
                name: "IX_ToDo_ScheduledTripId",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "ScheduledTripId",
                table: "ToDo");
        }
    }
}
