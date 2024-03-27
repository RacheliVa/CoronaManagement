using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class CoronaProjectContext : DbContext
{
    public CoronaProjectContext()
    {
    }

    public CoronaProjectContext(DbContextOptions<CoronaProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E0FAPSB\\SQLEXPRESS;Initial Catalog=CoronaProject; Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__address__3214EC07F4A46D3F");

            entity.ToTable("address");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.NumHouse)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numHouse");
            entity.Property(e => e.Street)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83FA7565DAC");

            entity.ToTable("customers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.BirthDate).HasColumnName("birthDate");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__customers__addre__267ABA7A");
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__diseases__3213E83FA6B0DF7D");

            entity.ToTable("diseases");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustId).HasColumnName("custId");
            entity.Property(e => e.DateIn).HasColumnName("dateIn");
            entity.Property(e => e.DateOut).HasColumnName("dateOut");

            entity.HasOne(d => d.Cust).WithMany(p => p.Diseases)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("FK__diseases__custId__2C3393D0");
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vaccinat__3213E83F5E215E19");

            entity.ToTable("vaccinations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustId).HasColumnName("custId");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("manufacturer");

            entity.HasOne(d => d.Cust).WithMany(p => p.Vaccinations)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("FK__vaccinati__custI__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
