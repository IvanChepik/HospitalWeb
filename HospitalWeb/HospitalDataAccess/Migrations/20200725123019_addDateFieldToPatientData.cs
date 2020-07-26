using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataAccess.Migrations
{
    public partial class addDateFieldToPatientData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ChoosedData",
                table: "PatientDatas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_PatientDatas_PatientId",
                table: "PatientDatas",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionSupports_DrugId",
                table: "NutritionSupports",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionSupports_PatientId",
                table: "NutritionSupports",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionSupports_Drugs_DrugId",
                table: "NutritionSupports",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "DrugId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionSupports_Patients_PatientId",
                table: "NutritionSupports",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDatas_Patients_PatientId",
                table: "PatientDatas",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionSupports_Drugs_DrugId",
                table: "NutritionSupports");

            migrationBuilder.DropForeignKey(
                name: "FK_NutritionSupports_Patients_PatientId",
                table: "NutritionSupports");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDatas_Patients_PatientId",
                table: "PatientDatas");

            migrationBuilder.DropIndex(
                name: "IX_PatientDatas_PatientId",
                table: "PatientDatas");

            migrationBuilder.DropIndex(
                name: "IX_NutritionSupports_DrugId",
                table: "NutritionSupports");

            migrationBuilder.DropIndex(
                name: "IX_NutritionSupports_PatientId",
                table: "NutritionSupports");

            migrationBuilder.DropColumn(
                name: "ChoosedData",
                table: "PatientDatas");
        }
    }
}
