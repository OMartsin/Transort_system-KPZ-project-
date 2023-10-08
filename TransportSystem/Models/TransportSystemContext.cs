using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class TransportSystemContext : DbContext
{
    public TransportSystemContext()
    {
    }

    public TransportSystemContext(DbContextOptions<TransportSystemContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<Accounting> Accounting { get; set; }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<DeliveryLog> DeliveryLog { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriverContract> DriverContracts { get; set; }

    public virtual DbSet<DriverLicense> DriverLicenses { get; set; }

    public virtual DbSet<LicenseCategory> LicenseCategories { get; set; }

    public virtual DbSet<Trailer> Trailers { get; set; }

    public virtual DbSet<TransportInsurance> TransportInsurances { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<Truck> Trucks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=transport_system;user=root;password=12345678", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Accounting>(entity =>
        {
            entity.HasKey(e => e.OperationId).HasName("PRIMARY");

            entity.ToTable("accounting");

            entity.HasIndex(e => e.OperationAgentId, "accounting_agent_id_idx");

            entity.Property(e => e.OperationId).HasColumnName("OperationID");
            entity.Property(e => e.OperationDescription).HasMaxLength(120);
            entity.Property(e => e.OperationName).HasMaxLength(45);

            entity.HasOne(d => d.OperationAgent).WithMany(p => p.Accounting)
                .HasForeignKey(d => d.OperationAgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accounting_agent_id");
        });

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentId).HasName("PRIMARY");

            entity.ToTable("agents");

            entity.HasIndex(e => e.AgentEdrpou, "AgentEDRPOU_UNIQUE").IsUnique();

            entity.HasIndex(e => e.AgentName, "AgentName_UNIQUE").IsUnique();

            entity.Property(e => e.AgentEdrpou)
                .HasMaxLength(15)
                .HasColumnName("AgentEDRPOU");
            entity.Property(e => e.AgentIpn)
                .HasMaxLength(15)
                .HasColumnName("AgentIPN");
            entity.Property(e => e.AgentName).HasMaxLength(45);
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("PRIMARY");

            entity.ToTable("cargos");

            entity.Property(e => e.CargoId).HasColumnName("CargoID");
            entity.Property(e => e.CargoName).HasMaxLength(45);
        });

        modelBuilder.Entity<DeliveryLog>(entity =>
        {
            entity.HasKey(e => e.DeliveryLogId).HasName("PRIMARY");

            entity.ToTable("deliverylog");

            entity.HasIndex(e => e.TripId, "log_trip_id_idx");

            entity.Property(e => e.LogOperationName).HasMaxLength(45);
            entity.Property(e => e.LogOperationDescription).HasMaxLength(120);
            entity.Property(e => e.LogOperationLocationCity).HasMaxLength(45);
            entity.Property(e => e.OperationDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Trip).WithMany(p => p.DeliveryLog)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("log_trip_id");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PRIMARY");

            entity.ToTable("drivers");

            entity.HasIndex(e => e.DriverIndividualTaxNumber, "DriverIndividualTaxNumber_UNIQUE").IsUnique();

            entity.HasIndex(e => e.DriverPhoneNumber, "DriverPhoneNumber_UNIQUE").IsUnique();

            entity.HasIndex(e => e.DriversPassportNumber, "DriversPassportNumber_UNIQUE").IsUnique();

            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.DriverIndividualTaxNumber).HasMaxLength(12);
            entity.Property(e => e.DriverName).HasMaxLength(30);
            entity.Property(e => e.DriverNationality).HasMaxLength(30);
            entity.Property(e => e.DriverPatronymic).HasMaxLength(30);
            entity.Property(e => e.DriverPhoneNumber).HasMaxLength(20);
            entity.Property(e => e.DriverSurname).HasMaxLength(30);
            entity.Property(e => e.DriversPassportNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<DriverContract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PRIMARY");

            entity.ToTable("drivercontract");

            entity.HasIndex(e => e.ContractNumber, "DriverContractNumber_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ContractDriverId, "contract_driver_id_idx");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.ContractDriverId).HasColumnName("ContractDriverID");

            entity.HasOne(d => d.ContractDriver).WithMany(p => p.DriverContracts)
                .HasForeignKey(d => d.ContractDriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_driver_id");
        });

        modelBuilder.Entity<DriverLicense>(entity =>
        {
            entity.HasKey(e => e.LicenseId).HasName("PRIMARY");

            entity.ToTable("driverlicenses");

            entity.HasIndex(e => e.DriverId, "DriverID");

            entity.Property(e => e.LicenseId).HasColumnName("LicenseID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.LicenseNumber).HasMaxLength(20);

            entity.HasOne(d => d.Driver).WithMany(p => p.DriverLicenses)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("driverlicenses_ibfk_1");

            entity.HasMany(d => d.Categories).WithMany(p => p.Licenses)
                .UsingEntity<Dictionary<string, object>>(
                    "Driverlicensecategory",
                    r => r.HasOne<LicenseCategory>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("licenses_driverlicensecategories_id"),
                    l => l.HasOne<DriverLicense>().WithMany()
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("driverlicensecategories_ibfk_1"),
                    j =>
                    {
                        j.HasKey("LicenseId", "CategoryId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("driverlicensecategories");
                        j.HasIndex(new[] { "LicenseId" }, "driverlicensecategories_ibfk_1_idx");
                        j.HasIndex(new[] { "CategoryId" }, "licenses_driverlicensecategories_id_idx");
                        j.IndexerProperty<int>("LicenseId").HasColumnName("LicenseID");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("CategoryID");
                    });
        });

        modelBuilder.Entity<LicenseCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("licensecategories");

            entity.HasIndex(e => e.CategoryCode, "CategoryCode_UNIQUE").IsUnique();

            entity.HasIndex(e => e.CategoryDescription, "CategoryDescription_UNIQUE").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryCode).HasMaxLength(5);
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
        });

        modelBuilder.Entity<Trailer>(entity =>
        {
            entity.HasKey(e => e.TrailerId).HasName("PRIMARY");

            entity.ToTable("trailers");

            entity.HasIndex(e => e.TrailerNumberPlate, "TrailerNumberPlate_UNIQUE").IsUnique();

            entity.Property(e => e.TrailerModel).HasMaxLength(30);
            entity.Property(e => e.TrailerNumberPlate).HasMaxLength(10);
            entity.Property(e => e.TrailerType).HasMaxLength(45);
            entity.Property(e => e.TrailerTyresType).HasMaxLength(128);
            entity.Property(e => e.TrailerVendor).HasMaxLength(30);
        });

        modelBuilder.Entity<TransportInsurance>(entity =>
        {
            entity.HasKey(e => e.TransportInsuranceId).HasName("PRIMARY");

            entity.ToTable("transportinsurance");

            entity.HasIndex(e => e.InsuranceAgentId, "insurance_agent_id_idx");

            entity.HasIndex(e => e.InsuranceTrailerId, "insurance_trailer_id_idx");

            entity.HasIndex(e => e.InsuranceTruckId, "insurance_truck_id_idx");

            entity.Property(e => e.InsuranceAgentId).HasColumnName("InsuranceAgentID");
            entity.Property(e => e.InsuranceTrailerId).HasColumnName("InsuranceTrailerID");
            entity.Property(e => e.InsuranceTruckId).HasColumnName("InsuranceTruckID");
            entity.Property(e => e.PolicyNumber).HasMaxLength(50);

            entity.HasOne(d => d.InsuranceAgent).WithMany(p => p.TransportInsurances)
                .HasForeignKey(d => d.InsuranceAgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("insurance_agent_id");

            entity.HasOne(d => d.InsuranceTrailer).WithMany(p => p.Transportinsurances)
                .HasForeignKey(d => d.InsuranceTrailerId)
                .HasConstraintName("insurance_trailer_id");

            entity.HasOne(d => d.InsuranceTruck).WithMany(p => p.TransportInsurances)
                .HasForeignKey(d => d.InsuranceTruckId)
                .HasConstraintName("insurance_truck_id");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PRIMARY");

            entity.ToTable("trips");

            entity.HasIndex(e => e.TripAgentId, "trip_agent_id_idx");

            entity.HasIndex(e => e.TripCargoId, "trip_cargo_id_idx");

            entity.HasIndex(e => e.TripDriver2Id, "trip_driver2_id_idx");

            entity.HasIndex(e => e.TripDriver1Id, "trip_driver_id_idx");

            entity.HasIndex(e => e.TripTrailerId, "trip_trailer_id_idx");

            entity.HasIndex(e => e.TripTruckId, "trip_truck_id_idx");

            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.TripAgentId).HasColumnName("TripAgentID");
            entity.Property(e => e.TripCargoId).HasColumnName("TripCargoID");
            entity.Property(e => e.TripDriver1Id).HasColumnName("TripDriver1ID");
            entity.Property(e => e.TripDriver2Id).HasColumnName("TripDriver2ID");
            entity.Property(e => e.TripTrailerId).HasColumnName("TripTrailerID");
            entity.Property(e => e.TripTruckId).HasColumnName("TripTruckID");

            entity.HasOne(d => d.TripAgent).WithMany(p => p.Trips)
                .HasForeignKey(d => d.TripAgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trip_agent_id");

            entity.HasOne(d => d.TripCargo).WithMany(p => p.Trips)
                .HasForeignKey(d => d.TripCargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trip_cargo_id");

            entity.HasOne(d => d.TripDriver1).WithMany(p => p.TripDriver)
                .HasForeignKey(d => d.TripDriver1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trip_driver_id");

            entity.HasOne(d => d.TripDriver2).WithMany(p => p.TripDriver)
                .HasForeignKey(d => d.TripDriver2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trip_driver2_id");

            entity.HasOne(d => d.TripTrailer).WithMany(p => p.Trips)
                .HasForeignKey(d => d.TripTrailerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trip_trailer_id");

            entity.HasOne(d => d.TripTruck).WithMany(p => p.Trips)
                .HasForeignKey(d => d.TripTruckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trip_truck_id");
        });

        modelBuilder.Entity<Truck>(entity =>
        {
            entity.HasKey(e => e.TruckId).HasName("PRIMARY");

            entity.ToTable("trucks");

            entity.HasIndex(e => e.TruckNumberPlate, "TruckNumberPlate_UNIQUE").IsUnique();

            entity.Property(e => e.TruckFrontTyresType).HasMaxLength(128);
            entity.Property(e => e.TruckFuelType).HasMaxLength(10);
            entity.Property(e => e.TruckModel).HasMaxLength(30);
            entity.Property(e => e.TruckNumberPlate).HasMaxLength(10);
            entity.Property(e => e.TruckRearTyperType).HasMaxLength(128);
            entity.Property(e => e.TruckVendor).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "Username_UNIQUE").IsUnique();

            entity.HasIndex(e => e.AgentId, "user_agent_id");

            entity.HasIndex(e => e.DriverId, "user_driver_id");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasColumnType("enum('agent','driver','administrator')");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Agent).WithMany(p => p.Users)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_agent_id");

            entity.HasOne(d => d.Driver).WithMany(p => p.Users)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_driver_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
