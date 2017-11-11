using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScienceActivityRecorder.Migrations
{
    public partial class DependenciesAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastFillDate",
                table: "PublicationActivityInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "PublicationActivityInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastFillDate",
                table: "ProfessionalActivityInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "ProfessionalActivityInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastFillDate",
                table: "AdditionalActivityInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "AdditionalActivityInfo",
                type: "int",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "LastFillDate",
                table: "PublicationActivityInfo");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "PublicationActivityInfo");

            migrationBuilder.DropColumn(
                name: "LastFillDate",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropColumn(
                name: "LastFillDate",
                table: "AdditionalActivityInfo");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "AdditionalActivityInfo");
        }
    }
}
