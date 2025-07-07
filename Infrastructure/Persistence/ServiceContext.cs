using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ServiceContext : DbContext
    {
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Ask> Asks { get; set; }
        public DbSet<Option> Options { get; set; }

        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*───────────────────────────────────────────
             * Presentation
             *───────────────────────────────────────────*/
            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.HasKey(e => e.IdPresentation);
                entity.Property(e => e.IdPresentation).ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("varchar(50)");

                entity.Property(e => e.ActivityStatus)
                      .IsRequired()
                      .HasColumnType("bit");

                entity.Property(e => e.CreatedAt)
                      .IsRequired()
                      .HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt)
                      .HasColumnType("datetime")
                      .IsRequired(false);

                entity.Property(e => e.IdUserCreat)
                      .IsRequired()
                      .HasColumnType("uniqueidentifier");

                entity.HasMany(p => p.Slides)
                      .WithOne(s => s.Presentation)
                      .HasForeignKey(s => s.IdPresentation)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            /*───────────────────────────────────────────
             * Slide
             *───────────────────────────────────────────*/
            modelBuilder.Entity<Slide>(entity =>
            {
                entity.HasKey(s => s.IdSlide);
                entity.Property(s => s.IdSlide).ValueGeneratedOnAdd();

                entity.Property(s => s.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(s => s.Content)
                      .IsRequired();

                entity.Property(s => s.Url)
                      .IsRequired(false);

                entity.Property(s => s.BackgroundColor)
                      .IsRequired();

                entity.Property(s => s.CreateAt)
                      .IsRequired();

                entity.Property(s => s.ModifiedAt)
                      .IsRequired(false);

                entity.Property(s => s.Position)
                      .IsRequired();

                entity.HasOne(s => s.Presentation)
                      .WithMany(p => p.Slides)
                      .HasForeignKey(s => s.IdPresentation)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Ask)
                      .WithOne(a => a.Slide)
                      .HasForeignKey<Ask>(a => a.IdSlide)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            /*───────────────────────────────────────────
             * Ask
             *───────────────────────────────────────────*/
            modelBuilder.Entity<Ask>(entity =>
            {
                entity.HasKey(a => a.IdAsk);
                entity.Property(a => a.IdAsk).ValueGeneratedOnAdd();

                entity.Property(a => a.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(a => a.Description)
                      .HasMaxLength(250)
                      .IsRequired(false);

                entity.Property(a => a.AskText)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.Property(a => a.CreatedAt)
                      .IsRequired();

                entity.Property(a => a.ModifiedAt)
                      .IsRequired(false);

                entity.HasMany(o => o.Options)
                      .WithOne(a => a.Ask)
                      .HasForeignKey(o => o.IdAsk)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            /*───────────────────────────────────────────
             * Option
             *───────────────────────────────────────────*/
            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(o => o.IdOption);
                entity.Property(o => o.IdOption).ValueGeneratedOnAdd();

                entity.Property(o => o.OptionText)
                      .IsRequired()
                      .HasMaxLength(250);

                entity.Property(o => o.IsCorrect)
                      .IsRequired();

                entity.Property(o => o.CreatedAt)
                      .IsRequired();

                entity.Property(o => o.ModifiedAt)
                      .IsRequired(false);

                entity.HasOne(o => o.Ask)
                      .WithMany(a => a.Options)
                      .HasForeignKey(o => o.IdAsk)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            /*───────────────────────────────────────────
             *              DATA SEED
             *───────────────────────────────────────────*/
            var seedDate = new DateTime(2025, 7, 7, 0, 0, 0, DateTimeKind.Utc);
            var userId = Guid.Parse("11111111-2222-3333-4444-555555555555");

            // Presentación
            modelBuilder.Entity<Presentation>().HasData(new Presentation
            {
                IdPresentation = 1,
                Title = "Presentación SLIDE‑X",
                ActivityStatus = true,
                CreatedAt = seedDate,
                IdUserCreat = userId
            });

            // Slides (5)
            modelBuilder.Entity<Slide>().HasData(
                new Slide
                {
                    IdSlide = 1,
                    Title = "Portada",
                    Content = "¡Bienvenidos a SlideX!",
                    Url = "https://i.ibb.co/VZKC6GW/1.jpg",
                    BackgroundColor = "#FFFFFF",
                    Position = 0,
                    CreateAt = seedDate,
                    IdPresentation = 1
                },
                new Slide
                {
                    IdSlide = 2,
                    Title = "¿Cómo funciona?1",
                    Content = "",
                    Url = "https://i.ibb.co/bg8yWmgV/2.jpg",
                    BackgroundColor = "#FDE68A",
                    Position = 1,
                    CreateAt = seedDate,
                    IdPresentation = 1
                },
                new Slide
                {
                    IdSlide = 3,
                    Title = "Contenido",
                    Content = "¿A quien está dirigido?",
                    Url = "https://i.ibb.co/35PGPbnC/3.jpg",
                    BackgroundColor = "#BFDBFE",
                    Position = 2,
                    CreateAt = seedDate,
                    IdPresentation = 1
                },
                new Slide
                {
                    IdSlide = 4,
                    Title = "Sobre nosotros",
                    Content = "",
                    Url = "https://i.ibb.co/ZpKkWjR5/4.jpg",
                    BackgroundColor = "#FCA5A5",
                    Position = 3,
                    CreateAt = seedDate,
                    IdPresentation = 1
                },
                new Slide
                {
                    IdSlide = 5,
                    Title = "¡Fin!",
                    Content = "¡Gracias por participar!",
                    Url = "https://i.ibb.co/993nxTdF/5.jpg",
                    BackgroundColor = "#D9F99D",
                    Position = 4,
                    CreateAt = seedDate,
                    IdPresentation = 1
                }
            );

            // Preguntas (2)
            modelBuilder.Entity<Ask>().HasData(
                new Ask
                {
                    IdAsk = 1,
                    IdSlide = 2,
                    Name = "Pregunta 1",
                    Description = "Que cosas son posibles con slide-x",
                    AskText = "¿Para que sirve SLIDE-X?",
                    CreatedAt = seedDate
                },
                new Ask
                {
                    IdAsk = 2,
                    IdSlide = 4,
                    Name = "Preugunta 2",
                    Description = "Pregunta sobre nosotros",
                    AskText = "¿Cómo nos llamamos?",
                    CreatedAt = seedDate
                }
            );

            // Opciones (8)
            modelBuilder.Entity<Option>().HasData(
                // Ask 1
                new Option { IdOption = 1, IdAsk = 1, OptionText = "Para hacer presentaciones en vivo", IsCorrect = true, CreatedAt = seedDate },
                new Option { IdOption = 2, IdAsk = 1, OptionText = "Para hacer llamadas online", IsCorrect = false, CreatedAt = seedDate },
                new Option { IdOption = 3, IdAsk = 1, OptionText = "Chat virtual", IsCorrect = false, CreatedAt = seedDate },
                new Option { IdOption = 4, IdAsk = 1, OptionText = "Para jugar en linea", IsCorrect = false, CreatedAt = seedDate },

                // Ask 2
                new Option { IdOption = 5, IdAsk = 2, OptionText = "Ctrl c + Ctrl v", IsCorrect = true, CreatedAt = seedDate },
                new Option { IdOption = 6, IdAsk = 2, OptionText = "GPTECH", IsCorrect = false, CreatedAt = seedDate },
                new Option { IdOption = 7, IdAsk = 2, OptionText = "ChatGptLovers", IsCorrect = false, CreatedAt = seedDate },
                new Option { IdOption = 8, IdAsk = 2, OptionText = "PlotTECH", IsCorrect = false, CreatedAt = seedDate }
            );
        }
    }
}
