using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScienceActivityRecorder.Migrations
{
    public partial class NamesChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PK_PublicationActivityInfo",
                table: "PublicationActivityInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalActivityInfo",
                table: "ProfessionalActivityInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalActivityInfo",
                table: "AdditionalActivityInfo");

            migrationBuilder.RenameTable(
                name: "PublicationActivityInfo",
                newName: "PublicationActivity");

            migrationBuilder.RenameTable(
                name: "ProfessionalActivityInfo",
                newName: "ProfessionalActivity");

            migrationBuilder.RenameTable(
                name: "AdditionalActivityInfo",
                newName: "AdditionalActivity");

            migrationBuilder.RenameIndex(
                name: "IX_PublicationActivityInfo_ProfileId",
                table: "PublicationActivity",
                newName: "IX_PublicationActivity_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionalActivityInfo_ProfileId",
                table: "ProfessionalActivity",
                newName: "IX_ProfessionalActivity_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalActivityInfo_ProfileId",
                table: "AdditionalActivity",
                newName: "IX_AdditionalActivity_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicationActivity",
                table: "PublicationActivity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalActivity",
                table: "ProfessionalActivity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalActivity",
                table: "AdditionalActivity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalActivity_Profile_ProfileId",
                table: "AdditionalActivity",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalActivity_Profile_ProfileId",
                table: "ProfessionalActivity",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationActivity_Profile_ProfileId",
                table: "PublicationActivity",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalActivity_Profile_ProfileId",
                table: "AdditionalActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalActivity_Profile_ProfileId",
                table: "ProfessionalActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationActivity_Profile_ProfileId",
                table: "PublicationActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicationActivity",
                table: "PublicationActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalActivity",
                table: "ProfessionalActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalActivity",
                table: "AdditionalActivity");

            migrationBuilder.RenameTable(
                name: "PublicationActivity",
                newName: "PublicationActivityInfo");

            migrationBuilder.RenameTable(
                name: "ProfessionalActivity",
                newName: "ProfessionalActivityInfo");

            migrationBuilder.RenameTable(
                name: "AdditionalActivity",
                newName: "AdditionalActivityInfo");

            migrationBuilder.RenameIndex(
                name: "IX_PublicationActivity_ProfileId",
                table: "PublicationActivityInfo",
                newName: "IX_PublicationActivityInfo_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionalActivity_ProfileId",
                table: "ProfessionalActivityInfo",
                newName: "IX_ProfessionalActivityInfo_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalActivity_ProfileId",
                table: "AdditionalActivityInfo",
                newName: "IX_AdditionalActivityInfo_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicationActivityInfo",
                table: "PublicationActivityInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalActivityInfo",
                table: "ProfessionalActivityInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalActivityInfo",
                table: "AdditionalActivityInfo",
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
    }
}
