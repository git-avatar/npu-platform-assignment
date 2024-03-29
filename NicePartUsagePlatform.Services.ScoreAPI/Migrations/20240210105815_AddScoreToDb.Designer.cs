﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NicePartUsagePlatform.Services.ScoreAPI.Data;

#nullable disable

namespace NicePartUsagePlatform.Services.ScoreAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240210105815_AddScoreToDb")]
    partial class AddScoreToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NicePartUsagePlatform.Services.ScoreAPI.Models.Score", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreId"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Creativity")
                        .HasColumnType("int");

                    b.Property<int>("NpuId")
                        .HasColumnType("int");

                    b.Property<int>("Uniqueness")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ScoreId");

                    b.ToTable("Scores");

                    b.HasData(
                        new
                        {
                            ScoreId = 1,
                            CreatedDate = new DateTimeOffset(new DateTime(2024, 2, 10, 11, 58, 14, 922, DateTimeKind.Unspecified).AddTicks(1661), new TimeSpan(0, 1, 0, 0, 0)),
                            Creativity = 8,
                            NpuId = 1,
                            Uniqueness = 7,
                            UserId = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
