using System;
using System.Collections.Generic;
using Base.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EarthFront.Tables
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Act> Act { get; set; } = null!;
        public virtual DbSet<Donate> Donate { get; set; } = null!;
        public virtual DbSet<UserFront> UserFront { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_Fun.Config.Db);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Act>(entity =>
            {
                entity.HasKey(e => e.Sn)
                    .HasName("PK_Act_1");

                entity.HasIndex(e => e.Id, "Act_Id")
                    .IsUnique();

                entity.Property(e => e.Caption).HasMaxLength(100);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DonateId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PlanCoin).HasColumnType("decimal(6, 1)");

                entity.Property(e => e.RealCoin).HasColumnType("decimal(6, 1)");

                entity.Property(e => e.Revised).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Donate>(entity =>
            {
                entity.HasKey(e => e.Sn);

                entity.HasIndex(e => e.Id, "Donate_Id")
                    .IsUnique();

                entity.Property(e => e.CorpId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.DonateCoin).HasColumnType("decimal(9, 1)");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RemainCoin).HasColumnType("decimal(9, 1)");
            });

            modelBuilder.Entity<UserFront>(entity =>
            {
                entity.HasKey(e => e.Sn)
                    .HasName("PK_UserFront_1");

                entity.HasIndex(e => e.Email, "UserFront_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "UserFront_Id")
                    .IsUnique();

                entity.Property(e => e.Account)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
