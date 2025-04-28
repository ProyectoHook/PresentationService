using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
                entity.HasOne(e => e.Presentation)
                    .WithMany(e => e.Slides)
                    .HasForeignKey(e => e.IdPresentation)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.ContentType)
                    .WithMany(e => e.slides)
                    .HasForeignKey(e => e.IdContentType)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Ask)
                    .WithMany(e => e.slides)
                    .HasForeignKey(e => e.IdAsk)
                    .OnDelete(DeleteBehavior.Cascade);
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
                new ContentType
                {
                    IdContentType = 1,
                    ContentTypeName = "Texto",
                    url = "text-content",
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new ContentType
                {
                    IdContentType = 2,
                    ContentTypeName = "Imagen",
                    url = "image-content",
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new ContentType
                {
                    IdContentType = 3,
                    ContentTypeName = "Video",
                    url = "video-content",
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new ContentType
                {
                    IdContentType = 4,
                    ContentTypeName = "Pregunta",
                    url = "question-content",
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                }
            );

            modelBuilder.Entity<Ask>().HasData(
                new Ask
                {
                    IdAsk = 1,
                    Name = "Capital de Francia",
                    Description = "Pregunta sobre geografía europea",
                    AskText = "¿Cuál es la capital de Francia?",
                    Answer = "París",
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new Ask
                {
                    IdAsk = 2,
                    Name = "Matemáticas básicas",
                    Description = "Pregunta de aritmética simple",
                    AskText = "¿Cuánto es 2 + 2?",
                    Answer = "4",
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                },
                new Ask
                {
                    IdAsk = 3,
                    Name = "Historia universal",
                    Description = "Pregunta sobre eventos históricos",
                    AskText = "¿En qué año llegó Colón a América?",
                    Answer = "1492",
                    CreatedAt = new DateTime(2023, 1, 1),
                    ModifiedAt = null
                }
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

    }
}
