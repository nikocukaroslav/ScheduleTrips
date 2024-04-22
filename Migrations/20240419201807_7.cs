using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Save__plan_your_trips.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_ScheduledTrip_ScheduledTripId",
                table: "ToDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo");

            migrationBuilder.RenameTable(
                name: "ToDo",
                newName: "ToDos");

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_ScheduledTripId",
                table: "ToDos",
                newName: "IX_ToDos_ScheduledTripId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScheduledTripId",
                table: "ToDos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_ScheduledTrip_ScheduledTripId",
                table: "ToDos",
                column: "ScheduledTripId",
                principalTable: "ScheduledTrip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_ScheduledTrip_ScheduledTripId",
                table: "ToDos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos");

            migrationBuilder.RenameTable(
                name: "ToDos",
                newName: "ToDo");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_ScheduledTripId",
                table: "ToDo",
                newName: "IX_ToDo_ScheduledTripId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScheduledTripId",
                table: "ToDo",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_ScheduledTrip_ScheduledTripId",
                table: "ToDo",
                column: "ScheduledTripId",
                principalTable: "ScheduledTrip",
                principalColumn: "Id");
        }
    }
}
