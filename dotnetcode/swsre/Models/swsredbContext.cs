ï»¿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace swsre.Models
{
    public partial class swsredbContext : DbContext
    {
        public swsredbContext()
        {
        }

        public swsredbContext(DbContextOptions<swsredbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tamount> Tamounts { get; set; }
        public virtual DbSet<Tdeduction> Tdeductions { get; set; }
        public virtual DbSet<Tpolicy> Tpolicies { get; set; }
        public virtual DbSet<Tpolicycoveragedetail> Tpolicycoveragedetails { get; set; }
        public virtual DbSet<Tpolicyperiod> Tpolicyperiods { get; set; }
        public virtual DbSet<VCatalog> VCatalogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=34.82.24.189;Database=swre_policydb;User Id=sa;Password=S0mbari@2022;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tamount>(entity =>
            {
                entity.HasKey(e => e.AmountId);

                entity.ToTable("TAMOUNT");

                entity.Property(e => e.AmountId).HasColumnName("AMOUNT_ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountTypeId).HasColumnName("AMOUNT_TYPE_ID");

                entity.Property(e => e.PcdId).HasColumnName("PCD_ID");

                entity.HasOne(d => d.Pcd)
                    .WithMany(p => p.Tamounts)
                    .HasForeignKey(d => d.PcdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TAMOUNT_TPOLICYCOVERAGEDETAIL");
            });

            modelBuilder.Entity<Tdeduction>(entity =>
            {
                entity.HasKey(e => e.DeductionId);

                entity.ToTable("TDEDUCTION");

                entity.Property(e => e.DeductionId).HasColumnName("DEDUCTION_ID");

                entity.Property(e => e.DeductionBasisamount).HasColumnName("DEDUCTION_BASISAMOUNT");

                entity.Property(e => e.DeductionFlatamount).HasColumnName("DEDUCTION_FLATAMOUNT");

                entity.Property(e => e.DeductionP).HasColumnName("DEDUCTION_P");

                entity.Property(e => e.Deductionbasis).HasColumnName("DEDUCTIONBASIS");

                entity.Property(e => e.Deductioncode).HasColumnName("DEDUCTIONCODE");

                entity.Property(e => e.Deductiongroup).HasColumnName("DEDUCTIONGROUP");

                entity.Property(e => e.PcdId).HasColumnName("PCD_ID");

                entity.HasOne(d => d.Pcd)
                    .WithMany(p => p.Tdeductions)
                    .HasForeignKey(d => d.PcdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TDEDUCTION_TPOLICYCOVERAGEDETAIL");
            });

            modelBuilder.Entity<Tpolicy>(entity =>
            {
                entity.HasKey(e => e.PolicyId);

                entity.ToTable("TPOLICY");

                entity.Property(e => e.PolicyId).HasColumnName("POLICY_ID");

                entity.Property(e => e.Activitystatuscode).HasColumnName("ACTIVITYSTATUSCODE");

                entity.Property(e => e.Expirationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRATIONDATE");

                entity.Property(e => e.Historyflag)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HISTORYFLAG")
                    .IsFixedLength();

                entity.Property(e => e.Inceptiondate)
                    .HasColumnType("datetime")
                    .HasColumnName("INCEPTIONDATE");

                entity.Property(e => e.PolicyNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("POLICY_NUMBER");

                entity.Property(e => e.PriorPolicyId).HasColumnName("PRIOR_POLICY_ID");

                entity.Property(e => e.Verifyflag)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VERIFYFLAG")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Tpolicycoveragedetail>(entity =>
            {
                entity.HasKey(e => e.PcdId);

                entity.ToTable("TPOLICYCOVERAGEDETAIL");

                entity.Property(e => e.PcdId).HasColumnName("PCD_ID");

                entity.Property(e => e.Coverageid).HasColumnName("COVERAGEID");

                entity.Property(e => e.PolicyId).HasColumnName("POLICY_ID");

                entity.Property(e => e.PolicyperiodId).HasColumnName("POLICYPERIOD_ID");

                entity.Property(e => e.Policyperiodrecord)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("POLICYPERIODRECORD")
                    .IsFixedLength();

                entity.Property(e => e.Policyrecord)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("POLICYRECORD")
                    .IsFixedLength();

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Tpolicycoveragedetails)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TPOLICYCOVERAGEDETAIL_TPOLICY");

                entity.HasOne(d => d.Policyperiod)
                    .WithMany(p => p.Tpolicycoveragedetails)
                    .HasForeignKey(d => d.PolicyperiodId)
                    .HasConstraintName("FK_TPOLICYCOVERAGEDETAIL_TPOLICYPERIOD");
            });

            modelBuilder.Entity<Tpolicyperiod>(entity =>
            {
                entity.HasKey(e => e.PolicyperiodId);

                entity.ToTable("TPOLICYPERIOD");

                entity.Property(e => e.PolicyperiodId).HasColumnName("POLICYPERIOD_ID");

                entity.Property(e => e.Effectivedate)
                    .HasColumnType("datetime")
                    .HasColumnName("EFFECTIVEDATE");

                entity.Property(e => e.Expirationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRATIONDATE");

                entity.Property(e => e.PolicyId).HasColumnName("POLICY_ID");

                entity.Property(e => e.PolicyperiodseqNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("POLICYPERIODSEQ_NO")
                    .IsFixedLength();

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Tpolicyperiods)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TPOLICYPERIOD_TPOLICY");
            });

            modelBuilder.Entity<VCatalog>(entity =>
            {
                entity.HasKey(e => e.CatalogId);

                entity.ToTable("V_CATALOG");

                entity.Property(e => e.CatalogId).HasColumnName("CATALOG_ID");

                entity.Property(e => e.CatalogName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATALOG_NAME");

                entity.Property(e => e.Code).HasColumnName("CODE");

                entity.Property(e => e.Codetype)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CODETYPE");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
