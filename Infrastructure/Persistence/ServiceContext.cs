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
                      .HasForeignKey<Ask>(a => a.SlideId)
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
                    .HasForeignKey<Ask>(a => a.SlideId)
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

            


           





        }

      
    }
}

