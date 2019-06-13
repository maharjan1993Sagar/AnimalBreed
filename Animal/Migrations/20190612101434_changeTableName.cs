using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class changeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vaccinationAnimals_diseases_diseasesId",
                table: "vaccinationAnimals");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccinationAnimals_vaccinations_vaccinationid",
                table: "vaccinationAnimals");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccinations_vaccinationSubType_vaccinationSubTypeId",
                table: "vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccinations_vaccinationTypes_vaccinationTypeid",
                table: "vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccinationSubType_vaccinationTypes_VaccinationTypeid",
                table: "vaccinationSubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vaccinationTypes",
                table: "vaccinationTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vaccinationSubType",
                table: "vaccinationSubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vaccinations",
                table: "vaccinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vaccinationAnimals",
                table: "vaccinationAnimals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_diseases",
                table: "diseases");

            migrationBuilder.RenameTable(
                name: "vaccinationTypes",
                newName: "dbug_vaccinationType");

            migrationBuilder.RenameTable(
                name: "vaccinationSubType",
                newName: "dbug_vaccinationSubType");

            migrationBuilder.RenameTable(
                name: "vaccinations",
                newName: "dbug_vaccination");

            migrationBuilder.RenameTable(
                name: "vaccinationAnimals",
                newName: "dbug_vaccinationAnimal");

            migrationBuilder.RenameTable(
                name: "diseases",
                newName: "dbug_diseases");

            migrationBuilder.RenameIndex(
                name: "IX_vaccinationSubType_VaccinationTypeid",
                table: "dbug_vaccinationSubType",
                newName: "IX_dbug_vaccinationSubType_VaccinationTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_vaccinations_vaccinationTypeid",
                table: "dbug_vaccination",
                newName: "IX_dbug_vaccination_vaccinationTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_vaccinations_vaccinationSubTypeId",
                table: "dbug_vaccination",
                newName: "IX_dbug_vaccination_vaccinationSubTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_vaccinationAnimals_vaccinationid",
                table: "dbug_vaccinationAnimal",
                newName: "IX_dbug_vaccinationAnimal_vaccinationid");

            migrationBuilder.RenameIndex(
                name: "IX_vaccinationAnimals_diseasesId",
                table: "dbug_vaccinationAnimal",
                newName: "IX_dbug_vaccinationAnimal_diseasesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbug_vaccinationType",
                table: "dbug_vaccinationType",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbug_vaccinationSubType",
                table: "dbug_vaccinationSubType",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbug_vaccination",
                table: "dbug_vaccination",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbug_vaccinationAnimal",
                table: "dbug_vaccinationAnimal",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbug_diseases",
                table: "dbug_diseases",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_vaccination_dbug_vaccinationSubType_vaccinationSubTypeId",
                table: "dbug_vaccination",
                column: "vaccinationSubTypeId",
                principalTable: "dbug_vaccinationSubType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_vaccination_dbug_vaccinationType_vaccinationTypeid",
                table: "dbug_vaccination",
                column: "vaccinationTypeid",
                principalTable: "dbug_vaccinationType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_vaccinationAnimal_dbug_diseases_diseasesId",
                table: "dbug_vaccinationAnimal",
                column: "diseasesId",
                principalTable: "dbug_diseases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_vaccinationAnimal_dbug_vaccination_vaccinationid",
                table: "dbug_vaccinationAnimal",
                column: "vaccinationid",
                principalTable: "dbug_vaccination",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_vaccinationSubType_dbug_vaccinationType_VaccinationTypeid",
                table: "dbug_vaccinationSubType",
                column: "VaccinationTypeid",
                principalTable: "dbug_vaccinationType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_vaccination_dbug_vaccinationSubType_vaccinationSubTypeId",
                table: "dbug_vaccination");

            migrationBuilder.DropForeignKey(
                name: "FK_dbug_vaccination_dbug_vaccinationType_vaccinationTypeid",
                table: "dbug_vaccination");

            migrationBuilder.DropForeignKey(
                name: "FK_dbug_vaccinationAnimal_dbug_diseases_diseasesId",
                table: "dbug_vaccinationAnimal");

            migrationBuilder.DropForeignKey(
                name: "FK_dbug_vaccinationAnimal_dbug_vaccination_vaccinationid",
                table: "dbug_vaccinationAnimal");

            migrationBuilder.DropForeignKey(
                name: "FK_dbug_vaccinationSubType_dbug_vaccinationType_VaccinationTypeid",
                table: "dbug_vaccinationSubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbug_vaccinationType",
                table: "dbug_vaccinationType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbug_vaccinationSubType",
                table: "dbug_vaccinationSubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbug_vaccinationAnimal",
                table: "dbug_vaccinationAnimal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbug_vaccination",
                table: "dbug_vaccination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbug_diseases",
                table: "dbug_diseases");

            migrationBuilder.RenameTable(
                name: "dbug_vaccinationType",
                newName: "vaccinationTypes");

            migrationBuilder.RenameTable(
                name: "dbug_vaccinationSubType",
                newName: "vaccinationSubType");

            migrationBuilder.RenameTable(
                name: "dbug_vaccinationAnimal",
                newName: "vaccinationAnimals");

            migrationBuilder.RenameTable(
                name: "dbug_vaccination",
                newName: "vaccinations");

            migrationBuilder.RenameTable(
                name: "dbug_diseases",
                newName: "diseases");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_vaccinationSubType_VaccinationTypeid",
                table: "vaccinationSubType",
                newName: "IX_vaccinationSubType_VaccinationTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_vaccinationAnimal_vaccinationid",
                table: "vaccinationAnimals",
                newName: "IX_vaccinationAnimals_vaccinationid");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_vaccinationAnimal_diseasesId",
                table: "vaccinationAnimals",
                newName: "IX_vaccinationAnimals_diseasesId");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_vaccination_vaccinationTypeid",
                table: "vaccinations",
                newName: "IX_vaccinations_vaccinationTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_vaccination_vaccinationSubTypeId",
                table: "vaccinations",
                newName: "IX_vaccinations_vaccinationSubTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vaccinationTypes",
                table: "vaccinationTypes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vaccinationSubType",
                table: "vaccinationSubType",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vaccinationAnimals",
                table: "vaccinationAnimals",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vaccinations",
                table: "vaccinations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_diseases",
                table: "diseases",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccinationAnimals_diseases_diseasesId",
                table: "vaccinationAnimals",
                column: "diseasesId",
                principalTable: "diseases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccinationAnimals_vaccinations_vaccinationid",
                table: "vaccinationAnimals",
                column: "vaccinationid",
                principalTable: "vaccinations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccinations_vaccinationSubType_vaccinationSubTypeId",
                table: "vaccinations",
                column: "vaccinationSubTypeId",
                principalTable: "vaccinationSubType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccinations_vaccinationTypes_vaccinationTypeid",
                table: "vaccinations",
                column: "vaccinationTypeid",
                principalTable: "vaccinationTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccinationSubType_vaccinationTypes_VaccinationTypeid",
                table: "vaccinationSubType",
                column: "VaccinationTypeid",
                principalTable: "vaccinationTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
