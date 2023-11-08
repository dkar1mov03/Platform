﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecruitmentPlatform.Data.DbContexts;

#nullable disable

namespace RecruitmentPlatform.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231108103732_InitialMigrations")]
    partial class InitialMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RecruitmentPlatform.Domain.Entities.ChatMessengers.ChatMessenger", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("EmployeerId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<long?>("JobSeekerId")
                        .HasColumnType("bigint");

                    b.Property<string>("MessageContent")
                        .HasColumnType("text");

                    b.Property<int>("MessageType")
                        .HasColumnType("integer");

                    b.Property<long>("ReceiverId")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeerId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("ChatMessengers");
                });

            modelBuilder.Entity("RecruitmentPlatform.Domain.Entities.Employeers.Employeer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Industry")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employeers");
                });

            modelBuilder.Entity("RecruitmentPlatform.Domain.Entities.JobAplications.JobAplication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AdditionalDocuments")
                        .HasColumnType("text");

                    b.Property<string>("CoverLetter")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("JobAplicationType")
                        .HasColumnType("integer");

                    b.Property<long>("JobListId")
                        .HasColumnType("bigint");

                    b.Property<long>("JobSeekerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("JobListId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JobAplications");
                });

            modelBuilder.Entity("RecruitmentPlatform.Domain.Entities.JobLists.JobList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<long?>("EmployeerId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<long?>("JobSeekerId")
                        .HasColumnType("bigint");

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("RequiredSkills")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeerId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JobLists");
                });

            modelBuilder.Entity("RecruitmentPlatform.Domain.Entities.JobSeekers.JobSeeker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Experience")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Preferences")
                        .HasColumnType("text");

                    b.Property<string>("ResumeLink")
                        .HasColumnType("text");

                    b.Property<string>("Skills")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("JobSeekers");
                });

            modelBuilder.Entity("RecruitmentPlatform.Domain.Entities.ChatMessengers.ChatMessenger", b =>
                {
                    b.HasOne("RecruitmentPlatform.Domain.Entities.Employeers.Employeer", "Employeer")
                        .WithMany()
                        .HasForeignKey("EmployeerId");

                    b.HasOne("RecruitmentPlatform.Domain.Entities.JobSeekers.JobSeeker", "JobSeeker")
                        .WithMany()
                        .HasForeignKey("JobSeekerId");

                    b.Navigation("Employeer");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("RecruitmentPlatform.Domain.Entities.JobAplications.JobAplication", b =>
                {
                    b.HasOne("RecruitmentPlatform.Domain.Entities.JobLists.JobList", "JobList")
                        .WithMany()
                        .HasForeignKey("JobListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentPlatform.Domain.Entities.JobSeekers.JobSeeker", "JobSeeker")
                        .WithMany()
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobList");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("RecruitmentPlatform.Domain.Entities.JobLists.JobList", b =>
                {
                    b.HasOne("RecruitmentPlatform.Domain.Entities.Employeers.Employeer", "Employeer")
                        .WithMany()
                        .HasForeignKey("EmployeerId");

                    b.HasOne("RecruitmentPlatform.Domain.Entities.JobSeekers.JobSeeker", "JobSeeker")
                        .WithMany()
                        .HasForeignKey("JobSeekerId");

                    b.Navigation("Employeer");

                    b.Navigation("JobSeeker");
                });
#pragma warning restore 612, 618
        }
    }
}