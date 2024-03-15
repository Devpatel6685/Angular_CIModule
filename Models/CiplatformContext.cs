using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CIPLATFORM.Models;

public partial class CiplatformContext : DbContext
{
    public CiplatformContext()
    {
    }

    public CiplatformContext(DbContextOptions<CiplatformContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:defaultConnection");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USER__3214EC27B706F4A3");

            entity.ToTable("USER");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("AVATAR");
            entity.Property(e => e.Cityid).HasColumnName("CITYID");
            entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDATE");
            entity.Property(e => e.Deletedate)
                .HasColumnType("datetime")
                .HasColumnName("DELETEDATE");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(255)
                .HasColumnName("EMPLOYEEID");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Linkedinurl)
                .HasMaxLength(255)
                .HasColumnName("LINKEDINURL");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phonenumber).HasColumnName("PHONENUMBER");
            entity.Property(e => e.Profiletext).HasColumnName("PROFILETEXT");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("ROLE");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("TITLE");
            entity.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Whyivolunteer).HasColumnName("WHYIVOLUNTEER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
