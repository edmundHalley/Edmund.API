using Edmund.API.Domain.Models;
using Edmund.API.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<EducationalStage> EducationalStages { get; set; }
        public DbSet<EducationalStageSubject> EducationalStageSubjects { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<MarksRecord> MarksRecords { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSubject> UserSubjects { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //EducationalStage

            builder.Entity<EducationalStage>().ToTable("EducationalStage");
            builder.Entity<EducationalStage>().HasKey(a => a.Id);
            builder.Entity<EducationalStage>().Property(a => a.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<EducationalStage>().Property(a => a.Name)
                .IsRequired().HasMaxLength(30);

            builder.Entity<EducationalStage>().HasData(
                new EducationalStage
                {
                    Id = 1,
                    Name = "Inicial"
                },
                new EducationalStage
                {
                    Id = 2,
                    Name = "Primaria"
                },
                new EducationalStage
                {
                    Id = 3,
                    Name = "Secundaria"
                });

            builder.Entity<EducationalStage>()
                .HasMany(a => a.Users)
                .WithOne(a => a.EducationalStage)
                .HasForeignKey(a => a.EducationalStageId);

            builder.Entity<EducationalStage>()
                .HasMany(a => a.Classrooms)
                .WithOne(a => a.EducationalStage)
                .HasForeignKey(a => a.EducationalStageId);

            //Classroom

            builder.Entity<Classroom>().ToTable("Classroom");
            builder.Entity<Classroom>().HasKey(a => a.Id);
            builder.Entity<Classroom>().Property(a => a.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Classroom>().Property(a => a.Name)
                .IsRequired().HasMaxLength(30);

            builder.Entity<Classroom>().HasData(
                new Classroom {
                    Id = 1,
                    Name = "3 años",
                    EducationalStageId = 1
                },
                new Classroom
                {
                    Id = 2,
                    Name = "4 años",
                    EducationalStageId = 1
                },
                new Classroom
                {
                    Id = 3,
                    Name = "5 años",
                    EducationalStageId = 1
                },
                new Classroom
                {
                    Id = 4,
                    Name = "1° Grado de Primaria",
                    EducationalStageId = 2
                },
                new Classroom
                {
                    Id = 5,
                    Name = "2° Grado de Primaria",
                    EducationalStageId = 2
                },
                new Classroom
                {
                    Id = 6,
                    Name = "3° Grado de Primaria",
                    EducationalStageId = 2
                },
                new Classroom
                {
                    Id = 7,
                    Name = "4° Grado de Primaria",
                    EducationalStageId = 2
                },
                new Classroom
                {
                    Id = 8,
                    Name = "5° Grado de Primaria",
                    EducationalStageId = 2
                },
                new Classroom
                {
                    Id = 9,
                    Name = "6° Grado de Primaria",
                    EducationalStageId = 2
                },
                new Classroom
                {
                    Id = 10,
                    Name = "1° Año de Secundaria",
                    EducationalStageId = 3
                },
                new Classroom
                {
                    Id = 11,
                    Name = "2° Año de Secundaria",
                    EducationalStageId = 3
                },
                new Classroom
                {
                    Id = 12,
                    Name = "3° Año de Secundaria",
                    EducationalStageId = 3
                },
                new Classroom
                {
                    Id = 13,
                    Name = "4° Año de Secundaria",
                    EducationalStageId = 3
                },
                new Classroom
                {
                    Id = 14,
                    Name = "5° Año de Secundaria",
                    EducationalStageId = 3
                });

            builder.Entity<Classroom>()
                .HasMany(a => a.Users)
                .WithOne(a => a.Classroom)
                .HasForeignKey(a => a.ClassroomId);

            builder.Entity<Classroom>()
                .HasMany(a => a.Subjects)
                .WithOne(a => a.Classroom)
                .HasForeignKey(a => a.ClassroomId);

            //EducationalStageSubject

            builder.Entity<EducationalStageSubject>().ToTable("EducationalStageSubject");
            builder.Entity<EducationalStageSubject>().HasKey(a => new
            {
                a.EducationalStageId,
                a.SubjectId
            });

            builder.Entity<EducationalStageSubject>().HasData(
                new EducationalStageSubject
                {
                    EducationalStageId = 1,
                    SubjectId = 1
                });

            builder.Entity<EducationalStageSubject>()
                .HasOne(ap => ap.EducationalStage)
                .WithMany(a => a.EducationalStageSubjects)
                .HasForeignKey(ap => ap.EducationalStageId);

            builder.Entity<EducationalStageSubject>()
                .HasOne(ap => ap.Subject)
                .WithMany(a => a.EducationalStageSubjects)
                .HasForeignKey(ap => ap.SubjectId);

            //Mark

            builder.Entity<Mark>().ToTable("Mark");
            builder.Entity<Mark>().HasKey(a => a.Id);
            builder.Entity<Mark>().Property(a => a.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Mark>().Property(a => a.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Mark>().Property(a => a.Percentage)
                .IsRequired();
            builder.Entity<Mark>().Property(a => a.Score)
                .IsRequired();
            builder.Entity<Mark>().Property(a => a.StudentId)
                .IsRequired();
            builder.Entity<Mark>().Property(a => a.TeacherId)
                .IsRequired();
            builder.Entity<Mark>().Property(a => a.MarksRecordId)
                .IsRequired();
            builder.Entity<Mark>().Property(a => a.SubjectId)
                .IsRequired();

            builder.Entity<Mark>().HasData(
                new Mark
                {
                    Id = 1,
                    Name = "Trabajo Final",
                    Percentage = 20,
                    Score = 10,
                    StudentId = 3,
                    TeacherId = 2,
                    MarksRecordId = 1,
                    SubjectId = 1
                });

            //MarksRecord

            builder.Entity<MarksRecord>().ToTable("MarksRecord");
            builder.Entity<MarksRecord>().HasKey(a => a.Id);
            builder.Entity<MarksRecord>().Property(a => a.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MarksRecord>().Property(a => a.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<MarksRecord>().Property(a => a.GPA)
                .IsRequired();
            builder.Entity<MarksRecord>().Property(a => a.SubjectId)
                .IsRequired();
            builder.Entity<MarksRecord>().Property(a => a.UserId)
                .IsRequired();
            builder.Entity<MarksRecord>().HasData(
                new MarksRecord
                {
                    Id = 1,
                    Name = "Reporte de Notas del Primer Bimestre",
                    GPA = 16,
                    SubjectId = 1,
                    UserId = 3
                });

            builder.Entity<MarksRecord>()
                .HasMany(a => a.Marks)
                .WithOne(a => a.MarksRecord)
                .HasForeignKey(a => a.MarksRecordId);

            //Subject

            builder.Entity<Subject>().ToTable("Subject");
            builder.Entity<Subject>().HasKey(a => a.Id);
            builder.Entity<Subject>().Property(a => a.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subject>().Property(a => a.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "Matemática",
                    ClassroomId = 4                    
                },
                new Subject
                {
                    Id = 2,
                    Name = "Comunicación",
                    ClassroomId = 4
                },
                new Subject
                {
                    Id = 3,
                    Name = "Ciencia y Tecnología",
                    ClassroomId = 4
                },
                 new Subject
                 {
                     Id = 4,
                     Name = "Religión",
                     ClassroomId = 4
                 },
                new Subject
                {
                    Id = 5,
                    Name = "Razonamiento Verbal",
                    ClassroomId = 4
                },
                new Subject
                {
                    Id = 6,
                    Name = "Razonamiento Matemático",
                    ClassroomId = 4
                },
                new Subject
                {
                    Id = 7,
                    Name = "Educación Motriz",
                    ClassroomId = 1
                },
                new Subject
                {
                    Id = 8,
                    Name = "Biologia",
                    ClassroomId = 10
                },
                new Subject
                {
                    Id = 9,
                    Name = "Geometría",
                    ClassroomId = 10
                });

            builder.Entity<Subject>()
                .HasMany(a => a.Marks)
                .WithOne(a => a.Subject)
                .HasForeignKey(a => a.SubjectId);

            builder.Entity<Subject>()
                .HasMany(a => a.MarksRecords)
                .WithOne(a => a.Subject)
                .HasForeignKey(a => a.SubjectId);

            //User

            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(a => a.Id);
            builder.Entity<User>().Property(a => a.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(a => a.FirstName)
                .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(a => a.LastName)
                .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(a => a.Username)
                .IsRequired().HasMaxLength(30);
            builder.Entity<User>().HasIndex(a => a.Username).IsUnique();
            builder.Entity<User>().Property(a => a.Email)
                .IsRequired().HasMaxLength(30);
            builder.Entity<User>().HasIndex(a => a.Email).IsUnique();
            builder.Entity<User>().Property(a => a.Identification)
                .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(a => a.Password)
                .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(a => a.PhoneNumber)
                .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(a => a.Birth)
                .IsRequired();
            builder.Entity<User>().Property(a => a.Sex)
                .IsRequired();
            builder.Entity<User>().Property(a => a.Address)
                .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(a => a.Type)
                .IsRequired();
            builder.Entity<User>().Property(a => a.UserId)
                .IsRequired();
            builder.Entity<User>().Property(a => a.EducationalStageId)
                .IsRequired();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "carmen186_@hotmail.com",
                    Password = "admin",
                    FirstName = "Carmen",
                    LastName = "Castillo",
                    Identification = "08499143",
                    PhoneNumber = "912921139",
                    Sex = true,
                    Address = "Jr. Augusto Aguirre 3068",
                    Type = true,
                },
                new User
                {
                    Id = 2,
                    Username = "profesor1",
                    Email = "profesor@gmail.com",
                    Password = "profesor",
                    FirstName = "Profesor",
                    LastName = "1",
                    Identification = "42949109",
                    PhoneNumber = "986473670",
                    Sex = true,
                    Address = "Jr. San Martin 4098",
                    Type = true,
                    EducationalStageId = 3,
                    ClassroomId = 10
                },
                new User
                {
                    Id = 3,
                    Username = "alumno1",
                    Email = "alumno@gmail.com",
                    Password = "alumno",
                    FirstName = "alumno",
                    LastName = "1",
                    Identification = "32949109",
                    PhoneNumber = "914673670",
                    Sex = false,
                    Address = "Jr. Carlo Magno 456",
                    Type = false,
                    EducationalStageId = 3,
                    ClassroomId = 10
                });

            builder.Entity<User>()
                .HasMany(a => a.Marks)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.StudentId);

            //UserSubject

            builder.Entity<UserSubject>().ToTable("UserSubject");
            builder.Entity<UserSubject>().HasKey(a => new
            {
                a.UserId,
                a.SubjectId
            });

            builder.Entity<UserSubject>()
                .HasOne(ap => ap.User)
                .WithMany(a => a.UserSubjects)
                .HasForeignKey(ap => ap.UserId);

            builder.Entity<UserSubject>()
                .HasOne(ap => ap.Subject)
                .WithMany(a => a.UserSubjects)
                .HasForeignKey(ap => ap.SubjectId);

            builder.Entity<UserSubject>().HasData(
                new UserSubject
                {
                    UserId = 2,
                    SubjectId = 1
                },
                new UserSubject
                {
                    UserId = 3,
                    SubjectId = 1
                },
                new UserSubject
                {
                    UserId = 3,
                    SubjectId = 2
                }
                );




            builder.ApplySnakeCaseNamingConvention();
        }

    }
}
