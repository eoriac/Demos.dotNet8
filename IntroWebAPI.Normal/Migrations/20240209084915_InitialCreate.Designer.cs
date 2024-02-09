﻿// <auto-generated />
using System;
using IntroWebAPI.Normal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntroWebAPI.Normal.Migrations
{
    [DbContext(typeof(WeatherAPIContext))]
    [Migration("20240209084915_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("IntroWebAPI.Normal.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("IntroWebAPI.Normal.WeatherForecast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CityId")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2e648dae-7e7d-4289-a5d4-4dedca70ca8d"),
                            CityId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Date = new DateOnly(2024, 2, 13),
                            Location = "Madrid",
                            Summary = "Freezing",
                            TemperatureC = -6
                        },
                        new
                        {
                            Id = new Guid("f011e50e-98eb-4f8c-90c8-cd2dfbd5b27a"),
                            CityId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Date = new DateOnly(2024, 2, 11),
                            Location = "Valencia",
                            Summary = "Chilly",
                            TemperatureC = 19
                        });
                });
#pragma warning restore 612, 618
        }
    }
}