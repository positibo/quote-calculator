using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuoteCalculator.Entities
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlackListedEmail> BlackListedEmails { get; set; }
        public virtual DbSet<BlackListedMobile> BlackListedMobiles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BlackListedEmail>(entity =>
            {
                entity.ToTable("BlackListedEmail");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BlackListedMobile>(entity =>
            {
                entity.ToTable("BlackListedMobile");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Loan");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loan");

                entity.Property(e => e.AmountRequired).HasColumnType("money");

                entity.Property(e => e.EstablishmentFee).HasColumnType("money");

                entity.Property(e => e.Frequency)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RepaymentAmount).HasColumnType("money");

                entity.Property(e => e.TotalInterest).HasColumnType("money");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Duration).HasMaxLength(20);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
