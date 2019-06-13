using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class ADDClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "diseases",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    diseasesNameEng = table.Column<string>(nullable: true),
                    diseasesNameNep = table.Column<string>(nullable: true),
                    symptom = table.Column<string>(nullable: true),
                    shortNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diseases", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vaccinationTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    vaccinationName = table.Column<string>(nullable: true),
                    shortNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccinationTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vaccinationSubType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubTypeName = table.Column<string>(nullable: true),
                    VaccinationTypeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccinationSubType", x => x.id);
                    table.ForeignKey(
                        name: "FK_vaccinationSubType_vaccinationTypes_VaccinationTypeid",
                        column: x => x.VaccinationTypeid,
                        principalTable: "vaccinationTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vaccinations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    vaccinName = table.Column<string>(nullable: true),
                    vaccinTypeId = table.Column<int>(nullable: true),
                    vaccinationSubTypeId = table.Column<int>(nullable: true),
                    vaccinForm = table.Column<string>(nullable: true),
                    manufacturedBy = table.Column<string>(nullable: true),
                    vaccinationTypeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccinations", x => x.id);
                    table.ForeignKey(
                        name: "FK_vaccinations_vaccinationSubType_vaccinationSubTypeId",
                        column: x => x.vaccinationSubTypeId,
                        principalTable: "vaccinationSubType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vaccinations_vaccinationTypes_vaccinationTypeid",
                        column: x => x.vaccinationTypeid,
                        principalTable: "vaccinationTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vaccinationAnimals",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagNo = table.Column<string>(nullable: true),
                    serviceProviderId = table.Column<int>(nullable: false),
                    vaccinId = table.Column<int>(nullable: false),
                    vaccinationid = table.Column<int>(nullable: true),
                    diseasesId = table.Column<int>(nullable: false),
                    vaccinationDate = table.Column<DateTime>(nullable: false),
                    dosage = table.Column<string>(nullable: true),
                    batchNo = table.Column<string>(nullable: true),
                    charge = table.Column<string>(nullable: true),
                    receiptNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccinationAnimals", x => x.id);
                    table.ForeignKey(
                        name: "FK_vaccinationAnimals_diseases_diseasesId",
                        column: x => x.diseasesId,
                        principalTable: "diseases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vaccinationAnimals_vaccinations_vaccinationid",
                        column: x => x.vaccinationid,
                        principalTable: "vaccinations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationAnimals_diseasesId",
                table: "vaccinationAnimals",
                column: "diseasesId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationAnimals_vaccinationid",
                table: "vaccinationAnimals",
                column: "vaccinationid");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinations_vaccinationSubTypeId",
                table: "vaccinations",
                column: "vaccinationSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinations_vaccinationTypeid",
                table: "vaccinations",
                column: "vaccinationTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationSubType_VaccinationTypeid",
                table: "vaccinationSubType",
                column: "VaccinationTypeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vaccinationAnimals");

            migrationBuilder.DropTable(
                name: "diseases");

            migrationBuilder.DropTable(
                name: "vaccinations");

            migrationBuilder.DropTable(
                name: "vaccinationSubType");

            migrationBuilder.DropTable(
                name: "vaccinationTypes");
        }
    }
}
