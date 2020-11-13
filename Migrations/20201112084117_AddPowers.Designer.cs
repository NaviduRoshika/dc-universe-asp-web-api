﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using alone_mysql_dc_comics.Data;

namespace alone_mysql_dc_comics.Migrations
{
    [DbContext(typeof(DcDbContext))]
    [Migration("20201112084117_AddPowers")]
    partial class AddPowers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("alone_mysql_dc_comics.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Origin")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("alone_mysql_dc_comics.Models.CharacterPower", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("PowerId")
                        .HasColumnType("int");

                    b.Property<int>("PowerStatus")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "PowerId");

                    b.HasIndex("PowerId");

                    b.ToTable("CharacterPowers");
                });

            modelBuilder.Entity("alone_mysql_dc_comics.Models.Family", b =>
                {
                    b.Property<int>("FamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("FatherName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MotherName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Relationship")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("child")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("FamilyId");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Families");
                });

            modelBuilder.Entity("alone_mysql_dc_comics.Models.Power", b =>
                {
                    b.Property<int>("PowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PowerName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("PowerId");

                    b.ToTable("Powers");
                });

            modelBuilder.Entity("alone_mysql_dc_comics.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TeamType")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("alone_mysql_dc_comics.Models.Character", b =>
                {
                    b.HasOne("alone_mysql_dc_comics.Models.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alone_mysql_dc_comics.Models.CharacterPower", b =>
                {
                    b.HasOne("alone_mysql_dc_comics.Models.Character", "Character")
                        .WithMany("CharacterPowers")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("alone_mysql_dc_comics.Models.Power", "Power")
                        .WithMany("CharacterPowers")
                        .HasForeignKey("PowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alone_mysql_dc_comics.Models.Family", b =>
                {
                    b.HasOne("alone_mysql_dc_comics.Models.Character", "Character")
                        .WithOne("Family")
                        .HasForeignKey("alone_mysql_dc_comics.Models.Family", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}