using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataAccess.Migrations
{
    public partial class addDataForPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DrugName = table.Column<string>(nullable: true),
                    Protein = table.Column<double>(nullable: false),
                    Fat = table.Column<double>(nullable: false),
                    Carbohydrate = table.Column<double>(nullable: false),
                    KCal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "NutritionSupports",
                columns: table => new
                {
                    NutritionSupportId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DrugId = table.Column<long>(nullable: false),
                    ProvisionDate = table.Column<DateTime>(nullable: false),
                    DrugVolume = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionSupports", x => x.NutritionSupportId);
                });

            migrationBuilder.CreateTable(
                name: "PatientDatas",
                columns: table => new
                {
                    PatientDataId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Temperature = table.Column<double>(nullable: false),
                    ActivityFactor = table.Column<double>(nullable: false),
                    DamageFactor = table.Column<double>(nullable: false),
                    WeightInitial = table.Column<double>(nullable: false),
                    WeightCurrent = table.Column<double>(nullable: false),
                    Growth = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDatas", x => x.PatientDataId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "NutritionSupports");

            migrationBuilder.DropTable(
                name: "PatientDatas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Patients");
        }
    }
}
