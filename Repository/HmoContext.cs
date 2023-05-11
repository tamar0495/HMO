using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.DBModels;

public partial class HmoContext : DbContext
{
    public HmoContext()
    {
    }

    public HmoContext(DbContextOptions<HmoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    public virtual DbSet<VaccinationsDate> VaccinationsDates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FVU1ABL; Initial Catalog = HMO; Integrated Security = True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("members");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.BuildingNumber).HasColumnName("buildingNumber");
            entity.Property(e => e.CellPhoneNumber)
                .HasMaxLength(25)
                .HasColumnName("cellPhoneNumber");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .HasColumnName("city");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("fullName");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(20)
                .HasColumnName("idNumber");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.PositiveResultDate)
                .HasColumnType("date")
                .HasColumnName("positiveResultDate");
            entity.Property(e => e.RecoveryDate)
                .HasColumnType("date")
                .HasColumnName("recoveryDate");
            entity.Property(e => e.Street)
                .HasMaxLength(200)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.ToTable("vaccinations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Manufaktorer)
                .HasMaxLength(100)
                .HasColumnName("manufaktorer");
        });

        modelBuilder.Entity<VaccinationsDate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_vaccinesDates");

            entity.ToTable("vaccinationsDates");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.VaccinationNumber).HasColumnName("vaccinationNumber");
            entity.Property(e => e.VaccineId).HasColumnName("vaccineId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
