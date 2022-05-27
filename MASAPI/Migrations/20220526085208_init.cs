using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MASAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Hospital_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Doctor_Hospital",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "integer", nullable: false),
                    IdHospital = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DoctorHospital_PK", x => new { x.IdDoctor, x.IdHospital });
                    table.ForeignKey(
                        name: "FK_Doctor_Hospital_Doctors_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Doctor_Hospital_Hospitals_IdHospital",
                        column: x => x.IdHospital,
                        principalTable: "Hospitals",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Accepted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sickness = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IdHospital = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_PK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patients_Hospitals_IdHospital",
                        column: x => x.IdHospital,
                        principalTable: "Hospitals",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "ID", "Gender", "HireDate", "MiddleName", "Name", "PhoneNumber", "Surname", "Title" },
                values: new object[,]
                {
                    { 1, 'M', new DateTime(2022, 5, 26, 8, 52, 8, 23, DateTimeKind.Utc).AddTicks(680), null, "Artur", "135792468", "Arturowski", "Habilitated Doctor" },
                    { 2, 'F', new DateTime(2022, 5, 26, 8, 52, 8, 23, DateTimeKind.Utc).AddTicks(680), null, "Agata", "124578359", "Agatowska", "Licenced Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "ID", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Cybernetyki", "Onkologiczny", "123456789" },
                    { 2, "Ameryki", "Psychologiczny", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Doctor_Hospital",
                columns: new[] { "IdDoctor", "IdHospital" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "ID", "Accepted", "Gender", "IdHospital", "MiddleName", "Name", "PhoneNumber", "Sickness", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 26, 8, 52, 8, 23, DateTimeKind.Utc).AddTicks(2210), 'M', 1, null, "Piotrek", "123789456", "Too much alcohol", "Zambrowski" },
                    { 2, new DateTime(2022, 5, 26, 8, 52, 8, 23, DateTimeKind.Utc).AddTicks(2220), 'F', 2, null, "Angelika", "456789123", "Too much weed", "Patusiar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Hospital_IdHospital",
                table: "Doctor_Hospital",
                column: "IdHospital");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdHospital",
                table: "Patients",
                column: "IdHospital");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor_Hospital");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
