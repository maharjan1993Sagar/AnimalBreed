using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbug_breedAnimal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    breedNameShort = table.Column<string>(nullable: true),
                    breedNamelong = table.Column<string>(nullable: true),
                    shortDetail = table.Column<string>(nullable: true),
                    originFrom = table.Column<string>(nullable: true),
                    registeredBy = table.Column<string>(nullable: true),
                    updatedBy = table.Column<string>(nullable: true),
                    registeredDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_breedAnimal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_farm",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    orgtanizationName = table.Column<string>(nullable: true),
                    shortDetail = table.Column<string>(nullable: true),
                    dateOfRegistration = table.Column<string>(nullable: true),
                    regCertification = table.Column<string>(nullable: true),
                    mobile1 = table.Column<string>(nullable: true),
                    mobile = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    municipility = table.Column<string>(nullable: true),
                    ward = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    farmType = table.Column<string>(nullable: true),
                    land = table.Column<string>(nullable: true),
                    area = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_farm", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_FeedFooder",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fooderNameNep = table.Column<string>(nullable: true),
                    fooderNameEng = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    municipility = table.Column<string>(nullable: true),
                    district = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    shortNote = table.Column<string>(nullable: true),
                    cultivation = table.Column<string>(nullable: true),
                    seedingMethod = table.Column<string>(nullable: true),
                    seedHarvestingStorage = table.Column<string>(nullable: true),
                    grassProduct = table.Column<string>(nullable: true),
                    dm = table.Column<string>(nullable: true),
                    cp = table.Column<string>(nullable: true),
                    tdn = table.Column<string>(nullable: true),
                    ndf = table.Column<string>(nullable: true),
                    c = table.Column<string>(nullable: true),
                    p = table.Column<string>(nullable: true),
                    df = table.Column<string>(nullable: true),
                    adl = table.Column<string>(nullable: true),
                    tanni = table.Column<string>(nullable: true),
                    nitrateScore = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_FeedFooder", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_milkBaseNutrition",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    animalSpecies = table.Column<string>(nullable: true),
                    fatPercentage = table.Column<string>(nullable: true),
                    snf = table.Column<string>(nullable: true),
                    dp = table.Column<string>(nullable: true),
                    cp = table.Column<string>(nullable: true),
                    tdn = table.Column<string>(nullable: true),
                    ndf = table.Column<string>(nullable: true),
                    c = table.Column<string>(nullable: true),
                    p = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_milkBaseNutrition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_pregnancyBawseNutrition",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    animalSpecies = table.Column<string>(nullable: true),
                    breed = table.Column<string>(nullable: true),
                    earlyPreg = table.Column<string>(nullable: true),
                    midPreg = table.Column<string>(nullable: true),
                    latePreg = table.Column<string>(nullable: true),
                    ageOfAnimal = table.Column<string>(nullable: true),
                    fatPercentage = table.Column<string>(nullable: true),
                    snf = table.Column<string>(nullable: true),
                    dp = table.Column<string>(nullable: true),
                    cp = table.Column<string>(nullable: true),
                    tdn = table.Column<string>(nullable: true),
                    ndf = table.Column<string>(nullable: true),
                    c = table.Column<string>(nullable: true),
                    p = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_pregnancyBawseNutrition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_vaccinationType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    vaccinationName = table.Column<string>(nullable: true),
                    shortNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_vaccinationType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbug_animal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagNo = table.Column<string>(nullable: true),
                    weight = table.Column<string>(nullable: true),
                    species = table.Column<string>(nullable: true),
                    breedId = table.Column<int>(nullable: false),
                    age = table.Column<string>(nullable: true),
                    dob = table.Column<string>(nullable: true),
                    sireId = table.Column<int>(nullable: false),
                    damId = table.Column<int>(nullable: false),
                    noOfCalving = table.Column<string>(nullable: true),
                    lastCalvingDate = table.Column<string>(nullable: true),
                    pregnencyStatus = table.Column<bool>(nullable: false),
                    pregnencyDuration = table.Column<string>(nullable: true),
                    milkingStatus = table.Column<bool>(nullable: false),
                    createdAt = table.Column<string>(nullable: true),
                    updatedBy = table.Column<string>(nullable: true),
                    ownerId = table.Column<int>(nullable: true),
                    keeperId = table.Column<int>(nullable: true),
                    farmId = table.Column<int>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    declaredBy = table.Column<string>(nullable: true),
                    declaredDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_animal", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_animal_dbug_breedAnimal_breedId",
                        column: x => x.breedId,
                        principalTable: "dbug_breedAnimal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbug_ownerKeeper",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    category = table.Column<string>(nullable: true),
                    fullName = table.Column<string>(nullable: true),
                    occupation = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    municipililty = table.Column<string>(nullable: true),
                    wardNo = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    logitude = table.Column<string>(nullable: true),
                    dob = table.Column<string>(nullable: true),
                    academicQualification = table.Column<string>(nullable: true),
                    finantanceStatus = table.Column<string>(nullable: true),
                    mobileNumber = table.Column<string>(nullable: true),
                    otherNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    farmid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_ownerKeeper", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_ownerKeeper_dbug_farm_farmid",
                        column: x => x.farmid,
                        principalTable: "dbug_farm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbug_vaccinationSubType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubTypeName = table.Column<string>(nullable: true),
                    VaccinationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_vaccinationSubType", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_vaccinationSubType_dbug_vaccinationType_VaccinationTypeId",
                        column: x => x.VaccinationTypeId,
                        principalTable: "dbug_vaccinationType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbug_diseases",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    diseasesNameEng = table.Column<string>(nullable: true),
                    diseasesNameNep = table.Column<string>(nullable: true),
                    symptom = table.Column<string>(nullable: true),
                    shortNote = table.Column<string>(nullable: true),
                    AnimalRegistrationid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_diseases", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_diseases_dbug_animal_AnimalRegistrationid",
                        column: x => x.AnimalRegistrationid,
                        principalTable: "dbug_animal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbug_growthMonitoring",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagNo = table.Column<string>(nullable: true),
                    length = table.Column<string>(nullable: true),
                    girth = table.Column<string>(nullable: true),
                    weight = table.Column<string>(nullable: true),
                    shortNote = table.Column<string>(nullable: true),
                    monitoredBy = table.Column<string>(nullable: true),
                    animalRegistrationid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_growthMonitoring", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_growthMonitoring_dbug_animal_animalRegistrationid",
                        column: x => x.animalRegistrationid,
                        principalTable: "dbug_animal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbug_healthCheckUp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagNo = table.Column<string>(nullable: true),
                    diseasesId = table.Column<int>(nullable: true),
                    serviceProviderId = table.Column<int>(nullable: true),
                    sampleTakenDate = table.Column<DateTime>(nullable: false),
                    sampleBoxNo = table.Column<string>(nullable: true),
                    laboratoryId = table.Column<int>(nullable: true),
                    charge = table.Column<string>(nullable: true),
                    receiptNo = table.Column<string>(nullable: true),
                    anlyzeReport = table.Column<string>(nullable: true),
                    reportExpDate = table.Column<DateTime>(nullable: false),
                    animalRegistrationid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_healthCheckUp", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_healthCheckUp_dbug_animal_animalRegistrationid",
                        column: x => x.animalRegistrationid,
                        principalTable: "dbug_animal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbug_milkRecord",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagNumber = table.Column<string>(nullable: true),
                    milkingStatus = table.Column<bool>(nullable: false),
                    recordingPeriod = table.Column<string>(nullable: true),
                    recordingDate = table.Column<DateTime>(nullable: false),
                    milkVolume = table.Column<string>(nullable: true),
                    milkSampleBoxNo = table.Column<string>(nullable: true),
                    labId = table.Column<string>(nullable: true),
                    testingCharge = table.Column<string>(nullable: true),
                    receiptNo = table.Column<string>(nullable: true),
                    genericProblem = table.Column<string>(nullable: true),
                    vacination = table.Column<string>(nullable: true),
                    shortNote = table.Column<string>(nullable: true),
                    animalRegistrationid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_milkRecord", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_milkRecord_dbug_animal_animalRegistrationid",
                        column: x => x.animalRegistrationid,
                        principalTable: "dbug_animal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalOwner",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalOwner", x => new { x.AnimalId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_AnimalOwner_dbug_animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "dbug_animal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalOwner_dbug_ownerKeeper_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "dbug_ownerKeeper",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbug_vaccination",
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
                    table.PrimaryKey("PK_dbug_vaccination", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_vaccination_dbug_vaccinationSubType_vaccinationSubTypeId",
                        column: x => x.vaccinationSubTypeId,
                        principalTable: "dbug_vaccinationSubType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbug_vaccination_dbug_vaccinationType_vaccinationTypeid",
                        column: x => x.vaccinationTypeid,
                        principalTable: "dbug_vaccinationType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbug_vaccinationAnimal",
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
                    receiptNo = table.Column<string>(nullable: true),
                    animalId = table.Column<int>(nullable: false),
                    animalRegistrationid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_vaccinationAnimal", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_vaccinationAnimal_dbug_animal_animalRegistrationid",
                        column: x => x.animalRegistrationid,
                        principalTable: "dbug_animal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbug_vaccinationAnimal_dbug_diseases_diseasesId",
                        column: x => x.diseasesId,
                        principalTable: "dbug_diseases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbug_vaccinationAnimal_dbug_vaccination_vaccinationid",
                        column: x => x.vaccinationid,
                        principalTable: "dbug_vaccination",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalOwner_OwnerId",
                table: "AnimalOwner",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_animal_breedId",
                table: "dbug_animal",
                column: "breedId");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_diseases_AnimalRegistrationid",
                table: "dbug_diseases",
                column: "AnimalRegistrationid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_growthMonitoring_animalRegistrationid",
                table: "dbug_growthMonitoring",
                column: "animalRegistrationid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_healthCheckUp_animalRegistrationid",
                table: "dbug_healthCheckUp",
                column: "animalRegistrationid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_milkRecord_animalRegistrationid",
                table: "dbug_milkRecord",
                column: "animalRegistrationid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_ownerKeeper_farmid",
                table: "dbug_ownerKeeper",
                column: "farmid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_vaccination_vaccinationSubTypeId",
                table: "dbug_vaccination",
                column: "vaccinationSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_vaccination_vaccinationTypeid",
                table: "dbug_vaccination",
                column: "vaccinationTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_vaccinationAnimal_animalRegistrationid",
                table: "dbug_vaccinationAnimal",
                column: "animalRegistrationid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_vaccinationAnimal_diseasesId",
                table: "dbug_vaccinationAnimal",
                column: "diseasesId");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_vaccinationAnimal_vaccinationid",
                table: "dbug_vaccinationAnimal",
                column: "vaccinationid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_vaccinationSubType_VaccinationTypeId",
                table: "dbug_vaccinationSubType",
                column: "VaccinationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalOwner");

            migrationBuilder.DropTable(
                name: "dbug_FeedFooder");

            migrationBuilder.DropTable(
                name: "dbug_growthMonitoring");

            migrationBuilder.DropTable(
                name: "dbug_healthCheckUp");

            migrationBuilder.DropTable(
                name: "dbug_milkBaseNutrition");

            migrationBuilder.DropTable(
                name: "dbug_milkRecord");

            migrationBuilder.DropTable(
                name: "dbug_pregnancyBawseNutrition");

            migrationBuilder.DropTable(
                name: "dbug_vaccinationAnimal");

            migrationBuilder.DropTable(
                name: "dbug_ownerKeeper");

            migrationBuilder.DropTable(
                name: "dbug_diseases");

            migrationBuilder.DropTable(
                name: "dbug_vaccination");

            migrationBuilder.DropTable(
                name: "dbug_farm");

            migrationBuilder.DropTable(
                name: "dbug_animal");

            migrationBuilder.DropTable(
                name: "dbug_vaccinationSubType");

            migrationBuilder.DropTable(
                name: "dbug_breedAnimal");

            migrationBuilder.DropTable(
                name: "dbug_vaccinationType");
        }
    }
}
