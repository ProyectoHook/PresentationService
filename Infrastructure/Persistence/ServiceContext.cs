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
        public DbSet<Ask> Asks { get; set; }
        public DbSet<Option> Options { get; set; }
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
                    .HasColumnType("datetime")
                    .IsRequired(false);

                entity.Property(e => e.IdUserCreat)
                    .IsRequired()
                    .HasColumnType("uniqueidentifier");

                entity.HasMany(p => p.Slides)
                    .WithOne(s => s.Presentation)
                    .HasForeignKey(s => s.IdPresentation)
                    .OnDelete(DeleteBehavior.Cascade) // Cambiado a Cascade para borrar slides automáticamente
                    .IsRequired();
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.HasKey(s => s.IdSlide);
                entity.Property(s => s.IdSlide)
                    .ValueGeneratedOnAdd();

                entity.Property(s => s.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(s => s.BackgroundColor)
                      .IsRequired();

                entity.Property(s => s.CreateAt)
                      .IsRequired();

                entity.Property(s => s.Position)
                      .IsRequired();

                entity.HasOne(s => s.Presentation)
                      .WithMany(p => p.Slides)
                      .HasForeignKey(s => s.IdPresentation)
                      .OnDelete(DeleteBehavior.Cascade) // Igual que arriba, por consistencia
                      .IsRequired();

                entity.HasOne(s => s.Ask)
                      .WithOne(a => a.Slide)
                      .HasForeignKey<Ask>(a => a.IdSlide)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Cascade); // Cambiado a Cascade para borrar pregunta si se borra slide
            });

            modelBuilder.Entity<Ask>(entity =>
            {
                entity.HasKey(a => a.IdAsk);
                entity.Property(a => a.IdAsk)
                    .ValueGeneratedOnAdd();

                entity.HasMany(o => o.Options)
                    .WithOne(a => a.Ask)
                    .HasForeignKey(o => o.IdAsk)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade); // Cascada para borrar opciones si se borra pregunta
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
                      .OnDelete(DeleteBehavior.Cascade); // Igual que arriba
            });
        }



    }
}

