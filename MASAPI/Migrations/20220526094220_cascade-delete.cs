using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MASAPI.Migrations
{
    public partial class cascadedelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Hospital_Doctors_IdDoctor",
                table: "Doctor_Hospital");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Hospital_Hospitals_IdHospital",
                table: "Doctor_Hospital");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_IdHospital",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2022, 5, 26, 9, 42, 20, 396, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2022, 5, 26, 9, 42, 20, 396, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "ID",
                keyValue: 1,
                column: "Accepted",
                value: new DateTime(2022, 5, 26, 9, 42, 20, 396, DateTimeKind.Utc).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "ID",
                keyValue: 2,
                column: "Accepted",
                value: new DateTime(2022, 5, 26, 9, 42, 20, 396, DateTimeKind.Utc).AddTicks(9670));

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Hospital_Doctors_IdDoctor",
                table: "Doctor_Hospital",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Hospital_Hospitals_IdHospital",
                table: "Doctor_Hospital",
                column: "IdHospital",
                principalTable: "Hospitals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_IdHospital",
                table: "Patients",
                column: "IdHospital",
                principalTable: "Hospitals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Hospital_Doctors_IdDoctor",
                table: "Doctor_Hospital");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Hospital_Hospitals_IdHospital",
                table: "Doctor_Hospital");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_IdHospital",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2022, 5, 26, 8, 52, 8, 23, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2022, 5, 26, 8, 52, 8, 23, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "ID",
                keyValue: 1,
                column: "Accepted",
                value: new DateTime(2022, 5, 26, 8, 52, 8, 23, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "ID",
                keyValue: 2,
                column: "Accepted",
                value: new DateTime(2022, 5, 26, 8, 52, 8, 23, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Hospital_Doctors_IdDoctor",
                table: "Doctor_Hospital",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Hospital_Hospitals_IdHospital",
                table: "Doctor_Hospital",
                column: "IdHospital",
                principalTable: "Hospitals",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_IdHospital",
                table: "Patients",
                column: "IdHospital",
                principalTable: "Hospitals",
                principalColumn: "ID");
        }
    }
}
