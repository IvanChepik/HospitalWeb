using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataAccess.Migrations
{
    public partial class addPatientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseHistoryNumber = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true),
                    DateOfHospital = table.Column<DateTime>(nullable: false),
                    DateOfOITR = table.Column<DateTime>(nullable: false),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    DateDischarge = table.Column<DateTime>(nullable: false),
                    IsMale = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
