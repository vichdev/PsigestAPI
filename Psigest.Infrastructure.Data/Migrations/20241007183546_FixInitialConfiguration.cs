using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psigest.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixInitialConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_HealthInsurances_HealthInsuranceId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_HealthInsuranceId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "HealthInsuranceId",
                table: "Clinics");

            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "HealthInsurances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthInsurances_ClinicId",
                table: "HealthInsurances",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthInsurances_Clinics_ClinicId",
                table: "HealthInsurances",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthInsurances_Clinics_ClinicId",
                table: "HealthInsurances");

            migrationBuilder.DropIndex(
                name: "IX_HealthInsurances_ClinicId",
                table: "HealthInsurances");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "HealthInsurances");

            migrationBuilder.AddColumn<Guid>(
                name: "HealthInsuranceId",
                table: "Clinics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_HealthInsuranceId",
                table: "Clinics",
                column: "HealthInsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_HealthInsurances_HealthInsuranceId",
                table: "Clinics",
                column: "HealthInsuranceId",
                principalTable: "HealthInsurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
