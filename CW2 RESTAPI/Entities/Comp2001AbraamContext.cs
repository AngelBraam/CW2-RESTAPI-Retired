using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CW2_RESTAPI.Entities;

public partial class Comp2001AbraamContext : DbContext
{
    public Comp2001AbraamContext()
    {
    }

    public Comp2001AbraamContext(DbContextOptions<Comp2001AbraamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bool> Bools { get; set; }

    public virtual DbSet<DeletionRecord> DeletionRecords { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<ProfileMicroService> ProfileMicroServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dist-6-505.uopnet.plymouth.ac.uk;Database=COMP2001_ABraam;user id=ABraam; pwd=IveD455*;Trusted_Connection=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bool>(entity =>
        {
            entity.HasKey(e => e.BoolId).HasName("PK__Bool__3DA0A0BCBF252AFA");

            entity.ToTable("Bool");

            entity.Property(e => e.BoolId).HasColumnName("BoolID");
            entity.Property(e => e.FkEmail)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FK_Email");

            entity.HasOne(d => d.FkEmailNavigation).WithMany(p => p.Bool)
                .HasForeignKey(d => d.FkEmail)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Bool__FK_Email__797309D9");
        });

        modelBuilder.Entity<DeletionRecord>(entity =>
        {
            entity.HasKey(e => e.DeletionId).HasName("PK__deletion__F6DF4CCBEF40A317");

            entity.ToTable("deletionRecord");

            entity.Property(e => e.DeletionId).HasColumnName("deletionID");
            entity.Property(e => e.DeletionDate).HasColumnName("deletionDATE");
            entity.Property(e => e.Operation)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA477983ABC16");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.FkBoolId).HasColumnName("FK_BoolID");
            entity.Property(e => e.MemberLocation)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.FkBool).WithMany(p => p.Location)
                .HasForeignKey(d => d.FkBoolId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Location__FK_Boo__7C4F7684");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Profile__A9D10535A9EDC45A");

            entity.ToTable("Profile", tb => tb.HasTrigger("UpdateEmail"));

            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AboutMe)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Birthday)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProfileMicroService>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ProfileMicroService");

            entity.Property(e => e.AboutMe)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Birthday)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MemberLocation)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
