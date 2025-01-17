﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using PTM.DAL.Entities;

namespace PTM.DAL.DataContext;
public partial class PTMDBContext : DbContext
{
    public PTMDBContext(DbContextOptions<PTMDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationLog> ApplicationLogs { get; set; }

    public virtual DbSet<PtmCategory> PtmCategories { get; set; }

    public virtual DbSet<PtmParkinglot> PtmParkinglots { get; set; }

    public virtual DbSet<PtmRole> PtmRoles { get; set; }

    public virtual DbSet<PtmTicket> PtmTickets { get; set; }

    public virtual DbSet<PtmUser> PtmUsers { get; set; }

    public virtual DbSet<PtmUserotp> PtmUserotps { get; set; }

    public virtual DbSet<PtmVehicle> PtmVehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationLog>(entity =>
        {
            entity.ToTable("APPLICATION_LOGS");

            entity.Property(e => e.Eventdatetime).HasColumnName("EVENTDATETIME");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPADDRESS");
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.Useremail)
                .HasMaxLength(255)
                .HasColumnName("USEREMAIL");
            entity.Property(e => e.Userid).HasColumnName("USERID");
        });

        modelBuilder.Entity<PtmCategory>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("PK__PTM_CATE__A50F9896263A4064");

            entity.ToTable("PTM_CATEGORIES");

            entity.Property(e => e.Categoryid).HasColumnName("CATEGORYID");
            entity.Property(e => e.Categoryname)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CATEGORYNAME");
            entity.Property(e => e.Createdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEDATE");
            entity.Property(e => e.Imageurl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IMAGEURL");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("ISACTIVE");
            entity.Property(e => e.Parentcategoryid).HasColumnName("PARENTCATEGORYID");
            entity.Property(e => e.Updatedate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATEDATE");

            entity.HasOne(d => d.Parentcategory).WithMany(p => p.InverseParentcategory)
                .HasForeignKey(d => d.Parentcategoryid)
                .HasConstraintName("FK__PTM_CATEG__PAREN__5535A963");
        });

        modelBuilder.Entity<PtmParkinglot>(entity =>
        {
            entity.HasKey(e => e.Parkinglotid).HasName("PK__PTM_PARK__322FAF861A3DDEBB");

            entity.ToTable("PTM_PARKINGLOTS");

            entity.Property(e => e.Parkinglotid).HasColumnName("PARKINGLOTID");
            entity.Property(e => e.Availablespaces).HasColumnName("AVAILABLESPACES");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Lotname)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOTNAME");
            entity.Property(e => e.Totalspaces).HasColumnName("TOTALSPACES");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.PtmParkinglots)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_PTM_PARKINGLOTS_PTM_USERS");
        });

        modelBuilder.Entity<PtmRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PMT_ROLES");

            entity.ToTable("PTM_ROLES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<PtmTicket>(entity =>
        {
            entity.HasKey(e => e.Ticketid).HasName("PK__PTM_TICK__19441073869410E4");

            entity.ToTable("PTM_TICKETS");

            entity.Property(e => e.Ticketid).HasColumnName("TICKETID");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("DISCOUNT");
            entity.Property(e => e.Expirationdate)
                .HasColumnType("datetime")
                .HasColumnName("EXPIRATIONDATE");
            entity.Property(e => e.Fineamount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("FINEAMOUNT");
            entity.Property(e => e.Intime)
                .HasColumnType("datetime")
                .HasColumnName("INTIME");
            entity.Property(e => e.Ispaid).HasColumnName("ISPAID");
            entity.Property(e => e.Issuedate)
                .HasColumnType("datetime")
                .HasColumnName("ISSUEDATE");
            entity.Property(e => e.Outtime)
                .HasColumnType("datetime")
                .HasColumnName("OUTTIME");
            entity.Property(e => e.Parkinglotid).HasColumnName("PARKINGLOTID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.Ticketnumber).HasColumnName("TICKETNUMBER");
            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.Vehicleid).HasColumnName("VEHICLEID");

            entity.HasOne(d => d.Parkinglot).WithMany(p => p.PtmTickets)
                .HasForeignKey(d => d.Parkinglotid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PARKINGLOT");

            entity.HasOne(d => d.User).WithMany(p => p.PtmTickets)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.PtmTickets)
                .HasForeignKey(d => d.Vehicleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VEHICLE");
        });

        modelBuilder.Entity<PtmUser>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__PTM_USER__C5B196026D703DF0");

            entity.ToTable("PTM_USERS");

            entity.HasIndex(e => e.Username, "UQ__PTM_USER__B15BE12E20AFAFA6").IsUnique();

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.Apikey)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("APIKEY");
            entity.Property(e => e.Extension)
                .HasMaxLength(50)
                .HasColumnName("EXTENSION");
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .HasColumnName("FAX");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Isblocked).HasColumnName("ISBLOCKED");
            entity.Property(e => e.Isremindernotification).HasColumnName("ISREMINDERNOTIFICATION");
            entity.Property(e => e.Lastlogin)
                .HasColumnType("datetime")
                .HasColumnName("LASTLOGIN");
            entity.Property(e => e.Lastotplogin)
                .HasColumnType("datetime")
                .HasColumnName("LASTOTPLOGIN");
            entity.Property(e => e.Loginattempt).HasColumnName("LOGINATTEMPT");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Passwordupdatedon)
                .HasColumnType("datetime")
                .HasColumnName("PASSWORDUPDATEDON");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("PHONE");
            entity.Property(e => e.Signupdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("SIGNUPDATE");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("USERNAME");
            entity.Property(e => e.Usertype)
                .HasMaxLength(50)
                .HasColumnName("USERTYPE");
            entity.Property(e => e.Usertypeid).HasColumnName("USERTYPEID");
        });

        modelBuilder.Entity<PtmUserotp>(entity =>
        {
            entity.ToTable("PTM_USEROTP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Expirationtime)
                .HasColumnType("datetime")
                .HasColumnName("EXPIRATIONTIME");
            entity.Property(e => e.Isused).HasColumnName("ISUSED");
            entity.Property(e => e.Otpcode).HasColumnName("OTPCODE");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.PtmUserotps)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_PTM_USEROTP_PTM_USERS");
        });

        modelBuilder.Entity<PtmVehicle>(entity =>
        {
            entity.HasKey(e => e.Vehicleid).HasName("PK__PTM_VEHI__D4BD3E73C8EB693C");

            entity.ToTable("PTM_VEHICLES");

            entity.HasIndex(e => e.Licenseplate, "UQ__PTM_VEHI__5E23436B576421D9").IsUnique();

            entity.Property(e => e.Vehicleid).HasColumnName("VEHICLEID");
            entity.Property(e => e.Categoryid).HasColumnName("CATEGORYID");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Licenseplate)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LICENSEPLATE");
            entity.Property(e => e.Ownername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OWNERNAME");

            entity.HasOne(d => d.Category).WithMany(p => p.PtmVehicles)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__PTM_VEHIC__CATEG__5CD6CB2B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}