﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tf.ShotView.Services.Db;

#nullable disable

namespace Tf.ShotView.Services.Db.Migrations
{
    [DbContext(typeof(ShotDbContext))]
    [Migration("20240923131330_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Tf.ShotView.Models.Db.RawShot", b =>
                {
                    b.Property<string>("ShootId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ablösung")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Anlage")
                        .HasColumnType("TEXT");

                    b.Property<int>("BahnNr")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Demonstration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExterneNummer")
                        .HasColumnType("TEXT");

                    b.Property<int>("Feuerart")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gruppe")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InsDel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LogEvent")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LogTyp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Match")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Mouche")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasseId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PrimaryScore")
                        .HasColumnType("REAL");

                    b.Property<int>("Schussart")
                        .HasColumnType("INTEGER");

                    b.Property<double>("SecondaryScore")
                        .HasColumnType("REAL");

                    b.Property<int>("StartNr")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stich")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SweepDirection")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TargetID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Teiler")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TimeSinceChange")
                        .HasColumnType("REAL");

                    b.Property<long>("TimeStamp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalArt")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Waffe")
                        .HasColumnType("INTEGER");

                    b.Property<double>("X")
                        .HasColumnType("REAL");

                    b.Property<double>("Y")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Zeit")
                        .HasColumnType("TEXT");

                    b.HasKey("ShootId");

                    b.ToTable("RawShots");
                });
#pragma warning restore 612, 618
        }
    }
}
