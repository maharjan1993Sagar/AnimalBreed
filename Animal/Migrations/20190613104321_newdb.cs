using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbug_ai",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagId = table.Column<string>(nullable: true),
                    semenBatchNo = table.Column<string>(nullable: true),
                    bullId = table.Column<string>(nullable: true),
                    semenDoseWasted = table.Column<string>(nullable: true),
                    inSemnatorId = table.Column<string>(nullable: true),
                    amounReceived = table.Column<string>(nullable: true),
                    recepitNo = table.Column<string>(nullable: true),
                    inSeminationPatch = table.Column<string>(nullable: true),
                    previousInseminationDate = table.Column<DateTime>(nullable: false),
                    locationNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_ai", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_animalSelection",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    animalId = table.Column<string>(nullable: true),
                    ownerId = table.Column<string>(nullable: true),
                    farmId = table.Column<string>(nullable: true),
                    selectionDate = table.Column<DateTime>(nullable: false),
                    shortNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_animalSelection", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_calfReg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTag = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    weight = table.Column<string>(nullable: true),
                    geneticDefect = table.Column<string>(nullable: true),
                    organizationalId = table.Column<string>(nullable: true),
                    ownerId = table.Column<string>(nullable: true),
                    keeperId = table.Column<string>(nullable: true),
                    dob = table.Column<DateTime>(nullable: false),
                    shortNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_calfReg", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_calving",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagNo = table.Column<string>(nullable: true),
                    serviceProviderId = table.Column<string>(nullable: true),
                    calvingDate = table.Column<DateTime>(nullable: false),
                    calvingType = table.Column<string>(nullable: true),
                    calvingCase = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_calving", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_pregnancyDiagnosis",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagId = table.Column<string>(nullable: true),
                    serviceProviderId = table.Column<string>(nullable: true),
                    naturalService = table.Column<string>(nullable: true),
                    otherServices = table.Column<string>(nullable: true),
                    serviceName = table.Column<string>(nullable: true),
                    diagnosisDate = table.Column<DateTime>(nullable: false),
                    result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_pregnancyDiagnosis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_pregnancyTermination",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagNo = table.Column<string>(nullable: true),
                    serviceProvidedId = table.Column<string>(nullable: true),
                    terminationDate = table.Column<DateTime>(nullable: false),
                    terminationType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_pregnancyTermination", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_semenCollection",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    collectionCenterId = table.Column<string>(nullable: true),
                    bullId = table.Column<string>(nullable: true),
                    batchNo = table.Column<string>(nullable: true),
                    collectionDate = table.Column<DateTime>(nullable: false),
                    shortNote = table.Column<string>(nullable: true),
                    responsibleCollectorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_semenCollection", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "institutionRegForServices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    serviceType = table.Column<string>(nullable: true),
                    institutionName = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionRegForServices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_registerServiceProvider",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fullName = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    professionType = table.Column<string>(nullable: true),
                    mub = table.Column<string>(nullable: true),
                    wardNo = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    provenDocument = table.Column<string>(nullable: true),
                    academicQualification = table.Column<string>(nullable: true),
                    certificate = table.Column<string>(nullable: true),
                    license = table.Column<string>(nullable: true),
                    phone1 = table.Column<string>(nullable: true),
                    phone2 = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    idCardNo = table.Column<string>(nullable: true),
                    Aiid = table.Column<int>(nullable: true),
                    PregnencyDiagnosisid = table.Column<int>(nullable: true),
                    Calvingid = table.Column<int>(nullable: true),
                    PregnencyTerminationid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_registerServiceProvider", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_registerServiceProvider_dbug_ai_Aiid",
                        column: x => x.Aiid,
                        principalTable: "dbug_ai",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbug_registerServiceProvider_dbug_calving_Calvingid",
                        column: x => x.Calvingid,
                        principalTable: "dbug_calving",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbug_registerServiceProvider_dbug_pregnancyDiagnosis_PregnencyDiagnosisid",
                        column: x => x.PregnencyDiagnosisid,
                        principalTable: "dbug_pregnancyDiagnosis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbug_registerServiceProvider_dbug_pregnancyTermination_PregnencyTerminationid",
                        column: x => x.PregnencyTerminationid,
                        principalTable: "dbug_pregnancyTermination",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbug_responsibleCollectorRegister",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    collectionCenterOrganizationId = table.Column<string>(nullable: true),
                    fullName = table.Column<string>(nullable: true),
                    phone1 = table.Column<string>(nullable: true),
                    phone2 = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    ward = table.Column<string>(nullable: true),
                    mun = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    academicQualification = table.Column<string>(nullable: true),
                    document = table.Column<string>(nullable: true),
                    licenseNo = table.Column<string>(nullable: true),
                    licenseImg = table.Column<string>(nullable: true),
                    citizenImg = table.Column<string>(nullable: true),
                    SemenCollectionid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_responsibleCollectorRegister", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_responsibleCollectorRegister_dbug_semenCollection_SemenCollectionid",
                        column: x => x.SemenCollectionid,
                        principalTable: "dbug_semenCollection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbug_semenCollectionCenter",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    collectionCenterName = table.Column<string>(nullable: true),
                    registerNo = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    mun = table.Column<string>(nullable: true),
                    ward = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    SemenCollectionid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_semenCollectionCenter", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_semenCollectionCenter_dbug_semenCollection_SemenCollectionid",
                        column: x => x.SemenCollectionid,
                        principalTable: "dbug_semenCollection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbug_registerServiceProvider_Aiid",
                table: "dbug_registerServiceProvider",
                column: "Aiid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_registerServiceProvider_Calvingid",
                table: "dbug_registerServiceProvider",
                column: "Calvingid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_registerServiceProvider_PregnencyDiagnosisid",
                table: "dbug_registerServiceProvider",
                column: "PregnencyDiagnosisid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_registerServiceProvider_PregnencyTerminationid",
                table: "dbug_registerServiceProvider",
                column: "PregnencyTerminationid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_responsibleCollectorRegister_SemenCollectionid",
                table: "dbug_responsibleCollectorRegister",
                column: "SemenCollectionid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_semenCollectionCenter_SemenCollectionid",
                table: "dbug_semenCollectionCenter",
                column: "SemenCollectionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbug_animalSelection");

            migrationBuilder.DropTable(
                name: "dbug_calfReg");

            migrationBuilder.DropTable(
                name: "dbug_registerServiceProvider");

            migrationBuilder.DropTable(
                name: "dbug_responsibleCollectorRegister");

            migrationBuilder.DropTable(
                name: "dbug_semenCollectionCenter");

            migrationBuilder.DropTable(
                name: "institutionRegForServices");

            migrationBuilder.DropTable(
                name: "dbug_ai");

            migrationBuilder.DropTable(
                name: "dbug_calving");

            migrationBuilder.DropTable(
                name: "dbug_pregnancyDiagnosis");

            migrationBuilder.DropTable(
                name: "dbug_pregnancyTermination");

            migrationBuilder.DropTable(
                name: "dbug_semenCollection");
        }
    }
}
