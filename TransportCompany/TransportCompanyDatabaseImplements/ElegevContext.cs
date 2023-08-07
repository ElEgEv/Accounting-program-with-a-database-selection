using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using TransportCompanyDatabaseImplements.Models;

namespace TransportCompanyDatabaseImplements;

public partial class ElegevContext : DbContext
{
    public ElegevContext()
    {
    }

    public ElegevContext(DbContextOptions<ElegevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<Trucking> Truckings { get; set; }

    public virtual DbSet<TypeTransportation> TypeTransportations { get; set; }

    string dbName = ConfigurationManager.AppSettings["connectToDb"];

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(dbName);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cargo_pkey");

            entity.ToTable("cargo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TypeCargo)
                .HasMaxLength(255)
                .HasColumnName("type_cargo");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
            entity.Property(e => e.Telephone)
                .HasMaxLength(255)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transport_pkey");

            entity.ToTable("transport");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TransportType)
                .HasMaxLength(255)
                .HasColumnName("transport_type");
        });

        modelBuilder.Entity<Trucking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trucking_pkey");

            entity.ToTable("trucking");

            entity.HasIndex(e => e.CargoId, "IX_trucking_cargo_id");

            entity.HasIndex(e => e.ClientId, "IX_trucking_client_id");

            entity.HasIndex(e => e.TransportId, "IX_trucking_transport_id");

            entity.HasIndex(e => e.TransportationId, "IX_trucking_transportation_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CargoId).HasColumnName("cargo_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_start");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TransportId).HasColumnName("transport_id");
            entity.Property(e => e.TransportationId).HasColumnName("transportation_id");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Truckings)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cargo_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Truckings)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_id");

            entity.HasOne(d => d.Transport).WithMany(p => p.Truckings)
                .HasForeignKey(d => d.TransportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transport_id");

            entity.HasOne(d => d.Transportation).WithMany(p => p.Truckings)
                .HasForeignKey(d => d.TransportationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("type_transportation_id");
        });

        modelBuilder.Entity<TypeTransportation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_transportation_pkey");

            entity.ToTable("type_transportation");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TransportationType)
                .HasMaxLength(255)
                .HasColumnName("transportation_type");
        });

        modelBuilder.HasSequence("seq_cargo");
        modelBuilder.HasSequence("seq_client");
        modelBuilder.HasSequence("seq_trucking");
        modelBuilder.HasSequence("seq_type_transport");
        modelBuilder.HasSequence("seq_type_transportation");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
