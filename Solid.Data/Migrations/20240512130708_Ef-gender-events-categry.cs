using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.Data.Migrations
{
    /// <inheritdoc />
    public partial class Efgendereventscategry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Categrys_CategryId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Events11_EventsId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Genders_GenderId",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_CategryId",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_EventsId",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_GenderId",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "CategryId",
                table: "Gifts",
                newName: "CategryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategryID",
                table: "Gifts",
                newName: "CategryId");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_CategryId",
                table: "Gifts",
                column: "CategryId");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_EventsId",
                table: "Gifts",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_GenderId",
                table: "Gifts",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Categrys_CategryId",
                table: "Gifts",
                column: "CategryId",
                principalTable: "Categrys",
                principalColumn: "CategryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Events11_EventsId",
                table: "Gifts",
                column: "EventsId",
                principalTable: "Events11",
                principalColumn: "EventsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Genders_GenderId",
                table: "Gifts",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
