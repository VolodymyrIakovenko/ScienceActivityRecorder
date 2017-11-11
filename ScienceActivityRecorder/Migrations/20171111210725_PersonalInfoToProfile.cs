using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScienceActivityRecorder.Migrations
{
    public partial class PersonalInfoToProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalActivityInfo_Profiles_ProfileId",
                table: "AdditionalActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalActivityInfo_Profiles_ProfileId",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_PersonalInfo_PersonalInfoId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationActivityInfo_Profiles_ProfileId",
                table: "PublicationActivityInfo");

            migrationBuilder.DropTable(
                name: "PersonalInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_PersonalInfoId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.AddColumn<string>(
                name: "AcademicDisciplines",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdvancedTraining",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Profile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationalInstitution",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seniority",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalActivityInfo_Profile_ProfileId",
                table: "AdditionalActivityInfo",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalActivityInfo_Profile_ProfileId",
                table: "ProfessionalActivityInfo",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationActivityInfo_Profile_ProfileId",
                table: "PublicationActivityInfo",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalActivityInfo_Profile_ProfileId",
                table: "AdditionalActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalActivityInfo_Profile_ProfileId",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationActivityInfo_Profile_ProfileId",
                table: "PublicationActivityInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "AcademicDisciplines",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "AdvancedTraining",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "EducationalInstitution",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Seniority",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademicDisciplines = table.Column<string>(nullable: true),
                    AdvancedTraining = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Degree = table.Column<string>(nullable: true),
                    EducationalInstitution = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    HomeAddress = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Seniority = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PersonalInfoId",
                table: "Profiles",
                column: "PersonalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalActivityInfo_Profiles_ProfileId",
                table: "AdditionalActivityInfo",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalActivityInfo_Profiles_ProfileId",
                table: "ProfessionalActivityInfo",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_PersonalInfo_PersonalInfoId",
                table: "Profiles",
                column: "PersonalInfoId",
                principalTable: "PersonalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationActivityInfo_Profiles_ProfileId",
                table: "PublicationActivityInfo",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
