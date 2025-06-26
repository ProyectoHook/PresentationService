using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence
{
    public class ServiceContext : DbContext
    {
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

            });

            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.HasKey(e => e.IdPresentation);
                entity.Property(e => e.IdPresentation)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .IsRequired()

                    .HasColumnType("varchar(50)");
                entity.Property(e => e.ActivityStatus)
                    .IsRequired()

                    .HasColumnType("bit");
                entity.Property(e => e.CreatedAt)
                    .IsRequired()

                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUserCreat)
                    .IsRequired()
                    .HasColumnType("uniqueidentifier");

                entity.HasMany(p => p.Slides)
                    .WithOne(s => s.Presentation)
                    .HasForeignKey(s => s.IdPresentation);

            });

            modelBuilder.Entity<Slide>(entity =>
            {
                // Clave primaria
                entity.HasKey(s => s.IdSlide);
                entity.Property(s => s.IdSlide)
                    .ValueGeneratedOnAdd();


                // Campo requerido
                entity.Property(s => s.Title)
                      .IsRequired()
                      .HasMaxLength(200); // opcional

                entity.Property(s => s.BackgroundColor)
                      .IsRequired();

                entity.Property(s => s.CreateAt)
                      .IsRequired();

                entity.Property(s => s.Position)
                      .IsRequired();

                // Relación obligatoria: Slide → Presentation (muchos a uno)
                entity.HasOne(s => s.Presentation)
                      .WithMany(p => p.Slides)
                      .HasForeignKey(s => s.IdPresentation)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();


                entity.HasOne(s => s.Ask)
                      .WithOne(a => a.Slide)
                      .HasForeignKey<Ask>(a => a.IdSlide)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Ask>(entity =>
            {
                entity.HasKey(a => a.IdAsk);
                entity.Property(a => a.IdAsk)
                    .ValueGeneratedOnAdd();

                entity.HasOne(s => s.Slide)
                    .WithOne(a => a.Ask)
                    .HasForeignKey<Ask>(a => a.IdSlide)
                    .IsRequired();

                entity.HasMany(o => o.Options)
                    .WithOne(a => a.Ask)
                    .HasForeignKey(o => o.IdAsk)
                    .IsRequired();
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(o => o.IdOption);
                entity.Property(o => o.IdOption)
                    .ValueGeneratedOnAdd();

                entity.Property(o => o.IsCorrect).IsRequired();

                entity.HasOne(o => o.Ask)
                      .WithMany(a => a.Options)
                      .HasForeignKey(o => o.IdAsk)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentType>().HasData(
                new ContentType { IdContentType = 1, ContentTypeName = "Texto" },
                new ContentType { IdContentType = 2, ContentTypeName = "Imagen" },
                //new ContentType { IdContentType = 3, ContentTypeName = "Video", url = "video-content", CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = null },
                new ContentType { IdContentType = 4, ContentTypeName = "Pregunta" }
            );

            modelBuilder.Entity<Presentation>().HasData(
                new Presentation { IdPresentation = 1, Title = "Presentacion de prueba completa", ActivityStatus = true, ModifiedAt = new DateTime(2025, 5, 25), CreatedAt = new DateTime(2025, 5, 25), IdUserCreat = Guid.Parse("00000000-0000-0000-0000-000000000000") },
                new Presentation { IdPresentation = 2, Title = "Michidemo full", ActivityStatus = true, ModifiedAt = new DateTime(2025, 5, 25), CreatedAt = new DateTime(2025, 5, 25), IdUserCreat = Guid.Parse("00000000-0000-0000-0000-000000000000") }

            );

            modelBuilder.Entity<Slide>().HasData(
               new Slide { IdSlide = 1, IdPresentation = 2, Title = "Michidemo Slides (pos 1)", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 1, BackgroundColor = "black", IdContentType = 2, Url = "https://i.pinimg.com/474x/f6/c4/de/f6c4dea389511b32e9688b108e78fe4c.jpg", Content ="Descripcion de imagen"},
               new Slide { IdSlide = 2, IdPresentation = 2, Title = "Michidemo Slides (pos 2)", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 2, BackgroundColor = "black", IdContentType = 2, Url = "https://i.pinimg.com/474x/c2/6e/9a/c26e9ad4e2125917d5965700e2a87635.jpg"},
               new Slide { IdSlide = 3, IdPresentation = 2, Title = "Michidemo Slides (pos 3)", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 3, BackgroundColor = "black", IdContentType = 2, Url = "https://i.pinimg.com/474x/34/a2/33/34a2331d5748b45f3b1ca5de1fda77a8.jpg", Content ="Descripcion de imagen"},
               new Slide { IdSlide = 4, IdPresentation = 2, Title = "Michidemo Slides (pos 4)", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 4, BackgroundColor = "black", IdContentType = 2, Url = "https://i.pinimg.com/474x/7a/e1/cf/7ae1cfe11811aa7ae62a375d59247cd1.jpg"},
               new Slide { IdSlide = 6, IdPresentation = 2, Title = "Michidemo Slides (pos 5)", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 5, BackgroundColor = "black", IdContentType = 2, Url = "https://i.pinimg.com/474x/9c/89/66/9c8966f0b1e1062367310236244b45e9.jpg", Content ="Descripcion de imagen"},
               new Slide { IdSlide = 5, IdPresentation = 2, Title = "Michidemo Slides (pos 6)", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 6, BackgroundColor = "black", IdContentType = 2, Url = "https://i.pinimg.com/474x/6f/ee/72/6fee72bad31ef67ddceb000a22836538.jpg"}
            );

            modelBuilder.Entity<Slide>().HasData(
               new Slide { IdSlide = 7,  IdPresentation = 1, Title = "Primer Slide (pos 1)",  Url = "https://ejemplo.com/slide1", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 1, BackgroundColor = "#FFFFFF", IdContentType = 1, Content = "Este es el texto introductorio de la presentacion" },
               new Slide { IdSlide = 8,  IdPresentation = 1, Title = "Segundo Slide (pos 2)", Url = "https://ejemplo.com/slide2", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 2, BackgroundColor = "#FFEEAA", IdContentType = 1, Content = "bla bla bla ...." },
               new Slide { IdSlide = 9,  IdPresentation = 1, Title = "Tercer Slide (pos 3)",  Url = "https://ejemplo.com/slide3", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 3, BackgroundColor = "#DDEEFF", IdContentType = 1, Content = "Fin de la presentacion. Muchas gracias." },
               new Slide { IdSlide = 10, IdPresentation = 1, Title = "Pregunta 1 (pos 5)", Url = "https://ejemplo.com/slide1", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 5, BackgroundColor = "#FFAAAA", IdContentType = 4, Content = "Este es el texto introductorio de la presentacion" },
               new Slide { IdSlide = 11, IdPresentation = 1, Title = "Pregunta 2 (pos 6)", Url = "https://ejemplo.com/slide2", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 6, BackgroundColor = "#BBEEAA", IdContentType = 4, Content = "bla bla bla ...." },
               new Slide { IdSlide = 12, IdPresentation = 1, Title = "Pregunta 3 (pos 4)", Url = "https://ejemplo.com/slide3", CreateAt = new DateTime(2025, 5, 25), ModifiedAt = new DateTime(2025, 5, 25), Position = 4, BackgroundColor = "#DDEEFF", IdContentType = 4, Content = "Ultima pregunta" }

            );

            modelBuilder.Entity<Ask>().HasData(
            new Ask { IdAsk = 1, IdSlide = 10, Name = "Pregunta Slide 1", Description = "Pregunta sencilla", AskText = "¿Cuál es la capital de Francia?", CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = null },
            new Ask { IdAsk = 2, IdSlide = 11, Name = "Pregunta Slide 2", Description = "Pregunta sobre geografía", AskText = "¿Cuál es el río más largo del mundo?", CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = null },
            new Ask { IdAsk = 3, IdSlide = 12, Name = "Pregunta Slide 3", Description = "Pregunta general", AskText = "¿Cuál es el planeta más grande del Sistema Solar?", CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = null }
            );

            modelBuilder.Entity<Option>().HasData(
                new Option { IdOption = 1, OptionText = "París", IsCorrect  = true,   IdAsk = 1, CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = new DateTime(2025, 5, 25) },
                new Option { IdOption = 2, OptionText = "Londres", IsCorrect = false, IdAsk = 1, CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = new DateTime(2025, 5, 25) },
                new Option { IdOption = 3, OptionText = "Madrid", IsCorrect = false,  IdAsk = 1, CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = new DateTime(2025, 5, 25) },
                new Option { IdOption = 4, OptionText = "Amazonas", IsCorrect = false, IdAsk = 2, CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = new DateTime(2025, 5, 25) },
                new Option { IdOption = 5, OptionText = "Nilo", IsCorrect = true, IdAsk = 2,      CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = new DateTime(2025, 5, 25) },
                new Option { IdOption = 6, OptionText = "Yangtsé", IsCorrect = false, IdAsk = 2,  CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = new DateTime(2025, 5, 25) },
                new Option { IdOption = 7, OptionText = "Saturno", IsCorrect = false, IdAsk = 3, CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = new DateTime(2025, 5, 25) },
                new Option { IdOption = 8, OptionText = "Júpiter", IsCorrect = true, IdAsk = 3,  CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = new DateTime(2025, 5, 25) },
                new Option { IdOption = 9, OptionText = "Neptuno", IsCorrect = false, IdAsk = 3, CreatedAt = new DateTime(2023, 1, 1), ModifiedAt = new DateTime(2025, 5, 25) }
            );

        }
    }
}

