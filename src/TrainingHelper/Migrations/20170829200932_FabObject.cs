using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainingHelper.Migrations
{
    public partial class FabObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fab",
                columns: table => new
                {
                    FabId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fab", x => x.FabId);
                });

            migrationBuilder.AddColumn<int>(
                name: "TargetTrained",
                table: "Certifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetTrained",
                table: "Bays",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetTrained",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "TargetTrained",
                table: "Bays");

            migrationBuilder.DropTable(
                name: "Fab");
        }
    }
}
