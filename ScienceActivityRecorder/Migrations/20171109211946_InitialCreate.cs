using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScienceActivityRecorder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalActivityInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Num20VocationalGuidenceWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num21ManagementOfCommonWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num22CreationOfOffices = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num23ParticipationInWorkOfBoards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num24NationalAward = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalActivityInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademicDisciplines = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvancedTraining = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationalInstitution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seniority = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalActivityInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Num10OrganizationalWorkInEducationalInstitutions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num11ParticipationInValidationOfScientists = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num12DegreeOfDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num13PatentsAvailibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num15DegreeOfDoctorOfPhilosophy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num16ManagementOfUkrainianOlympicWinnerStudent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num17OrganizingSocialActivities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num19CombinationOfTeachingAndPractice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num4ScientificManagement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num5ParticipationInInternationalProjects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num6LecturesInForeignLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num7WorkInExpertBoard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num8ScientificGuidenceFunctions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num9MangementOfPriceWinnerStudent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalActivityInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublicationActivityInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Num14TeachingManualsAvailibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num18PopularSciencePublicationsAvailibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num1PublicationsInScienceMetricDatabases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num2PublicationsInUkrainianDatabases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num3TextbookAvailability = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationActivityInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalActivityInfo");

            migrationBuilder.DropTable(
                name: "PersonalInfo");

            migrationBuilder.DropTable(
                name: "ProfessionalActivityInfo");

            migrationBuilder.DropTable(
                name: "PublicationActivityInfo");
        }
    }
}
