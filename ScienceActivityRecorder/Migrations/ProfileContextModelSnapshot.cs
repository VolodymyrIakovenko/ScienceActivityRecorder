﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ScienceActivityRecorder.Models;
using System;

namespace ScienceActivityRecorder.Migrations
{
    [DbContext(typeof(ProfileContext))]
    partial class ProfileContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ScienceActivityRecorder.Models.AdditionalActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastFillDate");

                    b.Property<string>("Num20VocationalGuidenceWork");

                    b.Property<string>("Num21ManagementOfCommonWork");

                    b.Property<string>("Num22CreationOfOffices");

                    b.Property<string>("Num23ParticipationInWorkOfBoards");

                    b.Property<string>("Num24NationalAward");

                    b.Property<int?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("AdditionalActivity");
                });

            modelBuilder.Entity("ScienceActivityRecorder.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("ProfileId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ScienceActivityRecorder.Models.ProfessionalActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastFillDate");

                    b.Property<string>("Num10OrganizationalWorkInEducationalInstitutions");

                    b.Property<string>("Num11ParticipationInValidationOfScientists");

                    b.Property<string>("Num12DegreeOfDoctor");

                    b.Property<string>("Num13PatentsAvailibility");

                    b.Property<string>("Num15DegreeOfDoctorOfPhilosophy");

                    b.Property<string>("Num16ManagementOfUkrainianOlympicWinnerStudent");

                    b.Property<string>("Num17OrganizingSocialActivities");

                    b.Property<string>("Num19CombinationOfTeachingAndPractice");

                    b.Property<string>("Num4ScientificManagement");

                    b.Property<string>("Num5ParticipationInInternationalProjects");

                    b.Property<string>("Num6LecturesInForeignLanguage");

                    b.Property<string>("Num7WorkInExpertBoard");

                    b.Property<string>("Num8ScientificGuidenceFunctions");

                    b.Property<string>("Num9MangementOfPriceWinnerStudent");

                    b.Property<int?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfessionalActivity");
                });

            modelBuilder.Entity("ScienceActivityRecorder.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcademicDisciplines");

                    b.Property<string>("AdvancedTraining");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Degree");

                    b.Property<string>("EducationalInstitution");

                    b.Property<string>("FirstName");

                    b.Property<string>("HomeAddress");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Position");

                    b.Property<string>("Seniority");

                    b.HasKey("Id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("ScienceActivityRecorder.Models.PublicationActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastFillDate");

                    b.Property<string>("Num14TeachingManualsAvailibility");

                    b.Property<string>("Num18PopularSciencePublicationsAvailibility");

                    b.Property<string>("Num1PublicationsInScienceMetricDatabases");

                    b.Property<string>("Num2PublicationsInUkrainianDatabases");

                    b.Property<string>("Num3TextbookAvailability");

                    b.Property<int?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("PublicationActivity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ScienceActivityRecorder.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ScienceActivityRecorder.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ScienceActivityRecorder.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ScienceActivityRecorder.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ScienceActivityRecorder.Models.AdditionalActivity", b =>
                {
                    b.HasOne("ScienceActivityRecorder.Models.Profile")
                        .WithMany("AdditionalActivity")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("ScienceActivityRecorder.Models.ProfessionalActivity", b =>
                {
                    b.HasOne("ScienceActivityRecorder.Models.Profile")
                        .WithMany("ProfessionalActivity")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("ScienceActivityRecorder.Models.PublicationActivity", b =>
                {
                    b.HasOne("ScienceActivityRecorder.Models.Profile")
                        .WithMany("PublicationActivity")
                        .HasForeignKey("ProfileId");
                });
#pragma warning restore 612, 618
        }
    }
}
