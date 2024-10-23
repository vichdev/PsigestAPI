using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psigest.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClinicsAndHealthInsuranceModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ClinicHealthInsurance",
                columns: table => new
                {
                    ClinicsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthInsurancesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicHealthInsurance", x => new { x.ClinicsId, x.HealthInsurancesId });
                    table.ForeignKey(
                        name: "FK_ClinicHealthInsurance_Clinics_ClinicsId",
                        column: x => x.ClinicsId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicHealthInsurance_HealthInsurances_HealthInsurancesId",
                        column: x => x.HealthInsurancesId,
                        principalTable: "HealthInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicHealthInsurance_HealthInsurancesId",
                table: "ClinicHealthInsurance",
                column: "HealthInsurancesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicHealthInsurance");

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
    }
}
