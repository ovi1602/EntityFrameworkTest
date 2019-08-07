using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Universitate.Entities;

namespace Universitate.Context
{
    public class UniversitateContext : DbContext
    {
        public static object Facultate { get; internal set; }
        public DbSet<Curs> Cursuri { get; set; }

        public DbSet<Facultate> Facultati { get; set; }

        public DbSet<Profesor> Profesori { get; set; }

        public DbSet<Student> Studenti { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=EVO507\\SQLEXPRESS;Database=Universitate;Trusted_Connection=True;ConnectRetryCount=0");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CursStudentLink>()
                            .HasKey(x => new { x.cursId, x.studentId });

            builder.Entity<Curs>()
                .HasMany(x => x.CursStudentLink)
                .WithOne(x => x.curs)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Student>()
                .HasMany(x => x.CursStudentLink)
                .WithOne(x => x.student)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
