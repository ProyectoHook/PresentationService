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
                    .OnDelete(DeleteBehavior.Cascade);
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

        }
    }
}
