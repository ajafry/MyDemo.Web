﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My.Demo.Data.Postgres;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace My.Demo.Data.Postgres.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20200503052328_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("My.Demo.Data.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Genre")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("My.Demo.Data.MoviePrincipal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<int?>("PrincipalId")
                        .HasColumnType("integer");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("PrincipalId");

                    b.ToTable("MoviePrincipals");
                });

            modelBuilder.Entity("My.Demo.Data.Principal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Principals");
                });

            modelBuilder.Entity("My.Demo.Data.MoviePrincipal", b =>
                {
                    b.HasOne("My.Demo.Data.Movie", "Movie")
                        .WithMany("Principals")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("My.Demo.Data.Principal", "Principal")
                        .WithMany()
                        .HasForeignKey("PrincipalId");
                });
#pragma warning restore 612, 618
        }
    }
}