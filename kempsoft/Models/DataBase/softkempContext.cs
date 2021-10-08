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

        public virtual DbSet<ReadyProject> ReadyProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<ReadyProject>(entity =>
            {
                entity.Property(e => e.LogoImg)
                    .HasMaxLength(100)
                    .HasColumnName("logoImg");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProjectImg).HasMaxLength(100);

                entity.Property(e => e.ProjectRoute).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
