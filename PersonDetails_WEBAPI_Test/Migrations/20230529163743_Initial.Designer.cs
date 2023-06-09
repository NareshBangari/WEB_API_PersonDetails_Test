﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonDetails_WEBAPI_Test.Data;

#nullable disable

namespace PersonDetails_WEBAPI_Test.Migrations
{
    [DbContext(typeof(DbContextClass))]
    [Migration("20230529163743_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonDetails_WEBAPI_Test.Model.PersonDetails", b =>
                {
                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CurrentLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailId");

                    b.ToTable("PersonDetalisTest");
                });

            modelBuilder.Entity("PersonDetails_WEBAPI_Test.Model.TechnicalExperience", b =>
                {
                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PersonDetailsEmailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TechnologyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WorkedFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WorkedTo")
                        .HasColumnType("datetime2");

                    b.HasKey("CompanyName");

                    b.HasIndex("PersonDetailsEmailId");

                    b.ToTable("TechnicalExperiencesTest");
                });

            modelBuilder.Entity("PersonDetails_WEBAPI_Test.Model.TechnicalExperience", b =>
                {
                    b.HasOne("PersonDetails_WEBAPI_Test.Model.PersonDetails", null)
                        .WithMany("TechnicalExperiences")
                        .HasForeignKey("PersonDetailsEmailId");
                });

            modelBuilder.Entity("PersonDetails_WEBAPI_Test.Model.PersonDetails", b =>
                {
                    b.Navigation("TechnicalExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
