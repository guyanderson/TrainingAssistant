using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingHelper.Migrations
{
    public partial class removeFabFromShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Fab_FabId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_FabId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "FabId",
                table: "Shifts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FabId",
                table: "Shifts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_FabId",
                table: "Shifts",
                column: "FabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Fab_FabId",
                table: "Shifts",
                column: "FabId",
                principalTable: "Fab",
                principalColumn: "FabId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
