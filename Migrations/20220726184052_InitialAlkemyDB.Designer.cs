﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using alkemy_challenge_backend.Data;

#nullable disable

namespace alkemy_challenge_backend.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20220726184052_InitialAlkemyDB")]
    partial class InitialAlkemyDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("alkemy_challenge_backend.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("History")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Weight")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("alkemy_challenge_backend.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("MyProperty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("alkemy_challenge_backend.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharactersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CharacterMovie");
                });

            modelBuilder.Entity("alkemy_challenge_backend.Models.Movie", b =>
                {
                    b.HasOne("alkemy_challenge_backend.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("alkemy_challenge_backend.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("alkemy_challenge_backend.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}