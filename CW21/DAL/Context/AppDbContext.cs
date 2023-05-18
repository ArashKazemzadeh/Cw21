using System;
using System.Collections.Generic;
using CW21.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CW21.DAL.Context;

public partial class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appoinment> Appoinments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Expertise> Expertises { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=db_Maktab_CW21;User Id=sa;Password=09389059421;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appoinment>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appoinments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appoinments_Doctors");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appoinments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Appoinments_Patients");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PassWord).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Expertise).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.ExpertiseId)
                .HasConstraintName("FK_Doctors_Expertises");
        });

        modelBuilder.Entity<Expertise>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PassWord).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
