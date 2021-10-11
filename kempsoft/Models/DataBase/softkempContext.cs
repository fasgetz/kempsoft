using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace kempsoft.Models.DataBase
{
    public partial class softkempContext : DbContext
    {
        public softkempContext()
        {
        }

        public softkempContext(DbContextOptions<softkempContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ReadyProject> ReadyProjects { get; set; }
        public virtual DbSet<TypePrice> TypePrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Price>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price1)
                    .HasColumnType("money")
                    .HasColumnName("Price");

                entity.HasOne(d => d.IdTypePriceNavigation)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.IdTypePrice)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Prices_TypePrices");
            });

            modelBuilder.Entity<ReadyProject>(entity =>
            {
                entity.Property(e => e.LogoImg)
                    .HasMaxLength(100)
                    .HasColumnName("logoImg");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProjectImg).HasMaxLength(100);

                entity.Property(e => e.ProjectRoute).HasMaxLength(50);
            });

            modelBuilder.Entity<TypePrice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
