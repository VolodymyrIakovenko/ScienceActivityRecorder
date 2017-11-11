using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScienceActivityRecorder.Migrations
{
    public partial class DependenciesChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalActivityInfo_PersonalInfo_PersonalInfoId",
                table: "AdditionalActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalActivityInfo_PersonalInfo_PersonalInfoId",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationActivityInfo_PersonalInfo_PersonalInfoId",
                table: "PublicationActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_PublicationActivityInfo_PersonalInfoId",
                table: "PublicationActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalActivityInfo_PersonalInfoId",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalActivityInfo_PersonalInfoId",
                table: "AdditionalActivityInfo");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "PublicationActivityInfo");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "AdditionalActivityInfo");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "PublicationActivityInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "ProfessionalActivityInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "AdditionalActivityInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonalInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_PersonalInfo_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicationActivityInfo_ProfileId",
                table: "PublicationActivityInfo",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalActivityInfo_ProfileId",
                table: "ProfessionalActivityInfo",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalActivityInfo_ProfileId",
                table: "AdditionalActivityInfo",
                column: "ProfileId");

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
                name: "FK_PublicationActivityInfo_Profiles_ProfileId",
                table: "PublicationActivityInfo",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalActivityInfo_Profiles_ProfileId",
                table: "AdditionalActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalActivityInfo_Profiles_ProfileId",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationActivityInfo_Profiles_ProfileId",
                table: "PublicationActivityInfo");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_PublicationActivityInfo_ProfileId",
                table: "PublicationActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalActivityInfo_ProfileId",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalActivityInfo_ProfileId",
                table: "AdditionalActivityInfo");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "PublicationActivityInfo");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AdditionalActivityInfo");

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "PublicationActivityInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "ProfessionalActivityInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "AdditionalActivityInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublicationActivityInfo_PersonalInfoId",
                table: "PublicationActivityInfo",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalActivityInfo_PersonalInfoId",
                table: "ProfessionalActivityInfo",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalActivityInfo_PersonalInfoId",
                table: "AdditionalActivityInfo",
                column: "PersonalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalActivityInfo_PersonalInfo_PersonalInfoId",
                table: "AdditionalActivityInfo",
                column: "PersonalInfoId",
                principalTable: "PersonalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalActivityInfo_PersonalInfo_PersonalInfoId",
                table: "ProfessionalActivityInfo",
                column: "PersonalInfoId",
                principalTable: "PersonalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationActivityInfo_PersonalInfo_PersonalInfoId",
                table: "PublicationActivityInfo",
                column: "PersonalInfoId",
                principalTable: "PersonalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
