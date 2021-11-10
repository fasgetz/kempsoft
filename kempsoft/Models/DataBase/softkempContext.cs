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

        public virtual DbSet<EmailsSender> sendersEmail { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentsStatus> PaymentsStatuses { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ReadyProject> ReadyProjects { get; set; }
        public virtual DbSet<StatusPay> StatusPays { get; set; }
        public virtual DbSet<TypePrice> TypePrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");


            modelBuilder.Entity<EmailsSender>(entity =>
            {
                entity.ToTable("EmailSender");

                entity.HasKey(i => i.Id);

                entity.Property(e => e.email).HasColumnName("email").HasMaxLength(100);

            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.ContactName).HasColumnName("contactName");

                entity.Property(e => e.ContactPhone).HasColumnName("contactPhone");

                entity.Property(e => e.CountDays).HasColumnName("countDays");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("orderId");

                entity.Property(e => e.PriceId).HasColumnName("priceId");

                entity.Property(e => e.SumPayment).HasColumnType("money");

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .HasColumnName("userId");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PriceId)
                    .HasConstraintName("FK_Payment_Prices");
            });

            modelBuilder.Entity<PaymentsStatus>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreated");

                entity.Property(e => e.IdPayment).HasColumnName("idPayment");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.HasOne(d => d.IdPaymentNavigation)
                    .WithMany(p => p.PaymentsStatuses)
                    .HasForeignKey(d => d.IdPayment)
                    .HasConstraintName("FK_PaymentsStatuses_Payment");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.PaymentsStatuses)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_PaymentsStatuses_StatusPay");
            });

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

            modelBuilder.Entity<StatusPay>(entity =>
            {
                entity.ToTable("StatusPay");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
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
