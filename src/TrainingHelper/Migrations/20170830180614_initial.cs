using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainingHelper.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    CertificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    TargetTrained = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.CertificationId);
                });

            migrationBuilder.CreateTable(
                name: "Bays",
                columns: table => new
                {
                    BayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TargetTrained = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bays", x => x.BayId);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    ToolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BayId = table.Column<int>(nullable: false),
                    CertificationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.ToolId);
                    table.ForeignKey(
                        name: "FK_Tools_Bays_BayId",
                        column: x => x.BayId,
                        principalTable: "Bays",
                        principalColumn: "BayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tools_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "CertificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fab",
                columns: table => new
                {
                    FabId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BayId = table.Column<int>(nullable: true),
                    CertificationId = table.Column<int>(nullable: true),
                    OperatorId = table.Column<int>(nullable: true),
                    ToolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fab", x => x.FabId);
                    table.ForeignKey(
                        name: "FK_Fab_Bays_BayId",
                        column: x => x.BayId,
                        principalTable: "Bays",
                        principalColumn: "BayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fab_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "CertificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fab_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "ToolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FabId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_Areas_Fab_FabId",
                        column: x => x.FabId,
                        principalTable: "Fab",
                        principalColumn: "FabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FabId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_Fab_FabId",
                        column: x => x.FabId,
                        principalTable: "Fab",
                        principalColumn: "FabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    OperatorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.OperatorId);
                    table.ForeignKey(
                        name: "FK_Operators_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperatorsCertification",
                columns: table => new
                {
                    OperatorCertificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertificationId = table.Column<int>(nullable: true),
                    OperatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorsCertification", x => x.OperatorCertificationId);
                    table.ForeignKey(
                        name: "FK_OperatorsCertification_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "CertificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperatorsCertification_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "OperatorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_FabId",
                table: "Areas",
                column: "FabId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bays_AreaId",
                table: "Bays",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fab_BayId",
                table: "Fab",
                column: "BayId");

            migrationBuilder.CreateIndex(
                name: "IX_Fab_CertificationId",
                table: "Fab",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fab_OperatorId",
                table: "Fab",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fab_ToolId",
                table: "Fab",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_ShiftId",
                table: "Operators",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorsCertification_CertificationId",
                table: "OperatorsCertification",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorsCertification_OperatorId",
                table: "OperatorsCertification",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_FabId",
                table: "Shifts",
                column: "FabId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tools_BayId",
                table: "Tools",
                column: "BayId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_CertificationId",
                table: "Tools",
                column: "CertificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bays_Areas_AreaId",
                table: "Bays",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fab_Operators_OperatorId",
                table: "Fab",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Fab_FabId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Fab_FabId",
                table: "Shifts");

            migrationBuilder.DropTable(
                name: "OperatorsCertification");

            migrationBuilder.DropTable(
                name: "Fab");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Bays");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
