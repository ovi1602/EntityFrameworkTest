﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Universitate.Context;

namespace Universitate.Migrations
{
    [DbContext(typeof(UniversitateContext))]
    partial class UniversitateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Universitate.Entities.Curs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultateId");

                    b.Property<string>("Nume");

                    b.Property<int?>("ProfesorId");

                    b.HasKey("Id");

                    b.HasIndex("FacultateId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("Cursuri");
                });

            modelBuilder.Entity("Universitate.Entities.CursStudentLink", b =>
                {
                    b.Property<int>("cursId");

                    b.Property<int>("studentId");

                    b.HasKey("cursId", "studentId");

                    b.HasIndex("studentId");

                    b.ToTable("CursStudentLink");
                });

            modelBuilder.Entity("Universitate.Entities.Facultate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nume");

                    b.HasKey("Id");

                    b.ToTable("Facultati");
                });

            modelBuilder.Entity("Universitate.Entities.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nume");

                    b.HasKey("Id");

                    b.ToTable("Profesori");
                });

            modelBuilder.Entity("Universitate.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultateId");

                    b.Property<string>("Nume");

                    b.HasKey("Id");

                    b.HasIndex("FacultateId");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("Universitate.Entities.Curs", b =>
                {
                    b.HasOne("Universitate.Entities.Facultate", "Facultate")
                        .WithMany("Cursuri")
                        .HasForeignKey("FacultateId");

                    b.HasOne("Universitate.Entities.Profesor", "Profesor")
                        .WithMany("Cursuri")
                        .HasForeignKey("ProfesorId");
                });

            modelBuilder.Entity("Universitate.Entities.CursStudentLink", b =>
                {
                    b.HasOne("Universitate.Entities.Curs", "curs")
                        .WithMany("CursStudentLink")
                        .HasForeignKey("cursId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Universitate.Entities.Student", "student")
                        .WithMany("CursStudentLink")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Universitate.Entities.Student", b =>
                {
                    b.HasOne("Universitate.Entities.Facultate", "Facultate")
                        .WithMany("Studenti")
                        .HasForeignKey("FacultateId");
                });
#pragma warning restore 612, 618
        }
    }
}
