﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VODTask.Membership.Database.Contexts;

#nullable disable

namespace VODTask.Membership.Database.Migrations
{
    [DbContext(typeof(VODContext))]
    [Migration("20230227122111_EntityUpdate")]
    partial class EntityUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VODTask.Membership.Database.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("VODTask.Membership.Database.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FilmUrl")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<bool>("Free")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("VODTask.Membership.Database.Entities.FilmGenre", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenres");
                });

            modelBuilder.Entity("VODTask.Membership.Database.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("VODTask.Membership.Database.Entities.SimilarFilm", b =>
                {
                    b.Property<int>("SimilarFilmId")
                        .HasColumnType("int");

                    b.Property<int>("ParentFilmId")
                        .HasColumnType("int");

                    b.HasKey("SimilarFilmId", "ParentFilmId");

                    b.HasIndex("ParentFilmId");

                    b.ToTable("SimilarFilms");
                });

            modelBuilder.Entity("VODTask.Membership.Database.Entities.Director", b =>
                {
                    b.HasOne("VODTask.Membership.Database.Entities.Film", null)
                        .WithMany("Directors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VODTask.Membership.Database.Entities.FilmGenre", b =>
                {
                    b.HasOne("VODTask.Membership.Database.Entities.Film", "Films")
                        .WithMany("FilmGenres")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VODTask.Membership.Database.Entities.Genre", "Genre")
                        .WithMany("FilmGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Films");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("VODTask.Membership.Database.Entities.SimilarFilm", b =>
                {
                    b.HasOne("VODTask.Membership.Database.Entities.Film", "ParentFilm")
                        .WithMany("SimilarFilms")
                        .HasForeignKey("ParentFilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParentFilm");
                });

            modelBuilder.Entity("VODTask.Membership.Database.Entities.Film", b =>
                {
                    b.Navigation("Directors");

                    b.Navigation("FilmGenres");

                    b.Navigation("SimilarFilms");
                });

            modelBuilder.Entity("VODTask.Membership.Database.Entities.Genre", b =>
                {
                    b.Navigation("FilmGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
