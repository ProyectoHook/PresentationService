using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Persistence
{
    public class ServiceContext : DbContext
    {
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Ask> asks { get; set; }
        public DbSet<Option> options { get; set; }
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentType>(entity =>
            {
                entity.HasKey(e => e.IdContentType);
                entity.Property(e => e.IdContentType)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.ContentTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
                entity.Property(e => e.url)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime");

            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.HasKey(e => e.IdSlide);
                entity.Property(e => e.IdSlide)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
                entity.Property(e => e.CreateAt)
                    .IsRequired()
                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime");
                entity.Property(e => e.BackgroundColor)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnType("int");

                entity.HasOne(s => s.Presentation)
                    .WithMany(p => p.Slides)
                    .HasForeignKey(s => s.IdPresentation);
                //.OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(s => s.ContentType)
                    .WithMany(ct => ct.slides)
                    .HasForeignKey(s => s.IdContentType);
                //.OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Ask)
                    .WithMany(a => a.slides)
                    .HasForeignKey(s => s.IdAsk);
                //.OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.HasKey(e => e.IdPresentation);
                entity.Property(e => e.IdPresentation)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime");
                entity.Property(e => e.ActivityStatus)
                    .IsRequired()
                    .HasColumnType("bit");
                entity.Property(e => e.IdUserCreat)
                    .IsRequired()
                    .HasColumnType("uniqueidentifier");


            });
            modelBuilder.Entity<Ask>(entity =>
            {
                entity.HasKey(e => e.IdAsk);
                entity.Property(e => e.IdAsk)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime");
                entity.Property(e => e.AskText)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.IdOption);
                entity.Property(e => e.IdOption)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.OptionText)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime");
                entity.HasOne(e => e.Ask)
                    .WithMany(e => e.options)
                    .HasForeignKey(e => e.IdAsk)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentType>().HasData(
                new ContentType {IdContentType=1,ContentTypeName = "Texto", url = "text-content", CreatedAt = new DateTime(2023,1,1),ModifiedAt=null},
                new ContentType {IdContentType=2,ContentTypeName = "Imagen", url = "image-content", CreatedAt = new DateTime(2023,1,1),ModifiedAt=null},
                new ContentType {IdContentType=3,ContentTypeName = "Video", url = "video-content", CreatedAt = new DateTime(2023,1,1),ModifiedAt=null},
                new ContentType {IdContentType=4,ContentTypeName = "Pregunta", url = "question-content", CreatedAt = new DateTime(2023,1,1),ModifiedAt=null}
            );

            modelBuilder.Entity<Ask>().HasData(
                new Ask { IdAsk = 1, Name = "Capital de Francia", Description = "Pregunta sobre geografía europea", AskText = "¿Cuál es la capital de Francia?", Answer = "París", CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = null },
                new Ask { IdAsk=2,Name="Capital de Francia",Description = "Pregunta sobre geografía europea",AskText = "¿Cuál es la capital de Francia?",Answer = "París",CreatedAt = new DateTime(2023,1,1),ModifiedAt=null},
                new Ask { IdAsk=3,Name="Matemáticas básicas",Description = "Pregunta de aritmética simple",AskText = "¿Cuánto es 2 + 2?",Answer = "4",CreatedAt = new DateTime(2023,1,1),ModifiedAt=null},
                new Ask { IdAsk=4,Name="Historia universal",Description = "Pregunta sobre eventos históricos",AskText = "¿En qué año llegó Colón a América?",Answer = "1492",CreatedAt = new DateTime(2023,1,1),ModifiedAt=null}
            );

            modelBuilder.Entity<Presentation>().HasData(
                new Presentation { IdPresentation = 1, Title = "Demo", ActivityStatus = true, ModifiedAt = null , CreatedAt = new DateTime(2025,5,25), IdUserCreat = Guid.Parse("00000000-0000-0000-0000-000000000000") }                
            );


            modelBuilder.Entity<Slide>().HasData(
                new Slide { IdSlide = 1, IdPresentation = 1, Title = "Demo Slide (pos 1)", CreateAt = new DateTime(2025,5,25), ModifiedAt = new DateTime(2025,5,25), Position = 1, BackgroundColor = "black", IdAsk = null, IdContentType = 2, Content = "https://i.pinimg.com/474x/f6/c4/de/f6c4dea389511b32e9688b108e78fe4c.jpg"},
                new Slide { IdSlide = 2, IdPresentation = 1, Title = "Demo Slide (pos 2)", CreateAt = new DateTime(2025,5,25), ModifiedAt = new DateTime(2025,5,25), Position = 2, BackgroundColor = "black", IdAsk = null, IdContentType = 2, Content = "https://i.pinimg.com/474x/c2/6e/9a/c26e9ad4e2125917d5965700e2a87635.jpg"},
                new Slide { IdSlide = 3, IdPresentation = 1, Title = "Demo Slide (pos 3)", CreateAt = new DateTime(2025,5,25), ModifiedAt = new DateTime(2025,5,25), Position = 3, BackgroundColor = "black", IdAsk = null, IdContentType = 2, Content = "https://i.pinimg.com/474x/34/a2/33/34a2331d5748b45f3b1ca5de1fda77a8.jpg"},
                new Slide { IdSlide = 4, IdPresentation = 1, Title = "Demo Slide (pos 4)", CreateAt = new DateTime(2025,5,25), ModifiedAt = new DateTime(2025,5,25), Position = 4, BackgroundColor = "black", IdAsk = null, IdContentType = 2, Content = "https://i.pinimg.com/474x/7a/e1/cf/7ae1cfe11811aa7ae62a375d59247cd1.jpg"},
                new Slide { IdSlide = 6, IdPresentation = 1, Title = "Demo Slide (pos 5)", CreateAt = new DateTime(2025,5,25), ModifiedAt = new DateTime(2025,5,25), Position = 5, BackgroundColor = "black", IdAsk = null, IdContentType = 2, Content = "https://i.pinimg.com/474x/9c/89/66/9c8966f0b1e1062367310236244b45e9.jpg"},
                new Slide { IdSlide = 5, IdPresentation = 1, Title = "Demo Slide (pos 6)", CreateAt = new DateTime(2025,5,25), ModifiedAt = new DateTime(2025,5,25), Position = 6, BackgroundColor = "black", IdAsk = null, IdContentType = 2, Content = "https://i.pinimg.com/474x/6f/ee/72/6fee72bad31ef67ddceb000a22836538.jpg"}
            );


            modelBuilder.Entity<Option>().HasData(
                // Opciones para la pregunta 1 (Capital de Francia)
                new Option
                {
                    IdOption = 1,
                    OptionText = "Madrid",
                    IdAsk = 1,
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new Option
                {
                    IdOption = 2,
                    OptionText = "París",
                    IdAsk = 1,
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new Option
                {
                    IdOption = 3,
                    OptionText = "Berlín",
                    IdAsk = 1,
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },

                // Opciones para la pregunta 2 (Matemáticas básicas)
                new Option
                {
                    IdOption = 4,
                    OptionText = "3",
                    IdAsk = 2,
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new Option
                {
                    IdOption = 5,
                    OptionText = "4",
                    IdAsk = 2,
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new Option
                {
                    IdOption = 6,
                    OptionText = "5",
                    IdAsk = 2,
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },

                // Opciones para la pregunta 3 (Historia universal)
                new Option
                {
                    IdOption = 7,
                    OptionText = "1492",
                    IdAsk = 3,
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new Option
                {
                    IdOption = 8,
                    OptionText = "1501",
                    IdAsk = 3,
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new Option
                {
                    IdOption = 9,
                    OptionText = "1600",
                    IdAsk = 3,
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                }

            );
        }
        public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
        {
            public ServiceContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
               
                // Copia aquí la misma cadena que usás en appsettings.json
                //optionsBuilder.UseSqlServer("Server=Flor\\SQLEXPRESS;Database=Presentation;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Presentation;Trusted_Connection=True;");

                return new ServiceContext(optionsBuilder.Options);
            }
        }
    }
}

