﻿// <auto-generated />
using System;
using Asp.NetProject.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Primary_HealthCare_System.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231018194027_PatientEducation")]
    partial class PatientEducation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Asp.NetProject.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Alert", b =>
                {
                    b.Property<int>("AlertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlertId"), 1L, 1);

                    b.Property<string>("IntendedUser")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("AlertId");

                    b.HasIndex("IntendedUser");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Appointments", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"), 1L, 1);

                    b.Property<DateTime>("AppointmentCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clinician")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentId");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Counselling_Sessions", b =>
                {
                    b.Property<int>("SessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessionID"), 1L, 1);

                    b.Property<int?>("AppointemtID")
                        .HasColumnType("int");

                    b.Property<string>("CounsellorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SessionCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SessionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SessionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionID");

                    b.HasIndex("AppointemtID");

                    b.HasIndex("CounsellorID");

                    b.ToTable("Counselling_Sessions");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackID"), 1L, 1);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int>("ComfortRating")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommunicationRating")
                        .HasColumnType("int");

                    b.Property<string>("CounselorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EffectivenessRating")
                        .HasColumnType("int");

                    b.Property<int>("OverallRating")
                        .HasColumnType("int");

                    b.Property<DateTime>("SessionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FeedbackID");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Medical_File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Allergies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmergencyPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyPersonConact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("PatientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FileId");

                    b.HasIndex("PatientID");

                    b.ToTable("Medical_File");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Medical_Record", b =>
                {
                    b.Property<int>("RecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordID"), 1L, 1);

                    b.Property<string>("CounselorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FollowUpInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FollowUpPlans")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeworkAssigned")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IssuesDiscussed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LabResults")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NextSessionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Procedures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Progress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SessionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TreatmentPlan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecordID");

                    b.ToTable("Medical_Record");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.PatientEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PatientEducation");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Referal", b =>
                {
                    b.Property<int>("ReferralID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReferralID"), 1L, 1);

                    b.Property<string>("AdditionalNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CounselingSessionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReferralDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferralReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferringDoctorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReferralID");

                    b.ToTable("Referal");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.RefillRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDnumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Medication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PatientID");

                    b.HasIndex("UserId");

                    b.ToTable("RefillRequest");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ReminderMessage")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ReminderTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientID");

                    b.ToTable("Reminder");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Alert", b =>
                {
                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", "CurrentUser")
                        .WithMany()
                        .HasForeignKey("IntendedUser");

                    b.Navigation("CurrentUser");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Appointments", b =>
                {
                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", "MAinUSer")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.Navigation("MAinUSer");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Counselling_Sessions", b =>
                {
                    b.HasOne("Primary_HealthCare_System.Models.Appointments", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointemtID");

                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", "Counsellor")
                        .WithMany()
                        .HasForeignKey("CounsellorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Counsellor");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Medical_File", b =>
                {
                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", "PatinetUser")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatinetUser");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.RefillRequest", b =>
                {
                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", "MAinUSer")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MAinUSer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Primary_HealthCare_System.Models.Reminder", b =>
                {
                    b.HasOne("Asp.NetProject.Areas.Identity.Data.ApplicationUser", "MAinUSer")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.Navigation("MAinUSer");
                });
#pragma warning restore 612, 618
        }
    }
}
