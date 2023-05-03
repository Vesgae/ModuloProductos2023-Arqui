using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using ModuloProductos_v1.DTO;

namespace ModuloProductos_v1.Entities;

public partial class DbserviciosproductosvehiculosContext : DbContext
{
    public DbserviciosproductosvehiculosContext()
    {
    }

    public DbserviciosproductosvehiculosContext(DbContextOptions<DbserviciosproductosvehiculosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tbaccesorio> Tbaccesorios { get; set; }

    public virtual DbSet<Tbaccesorioenventum> Tbaccesorioenventa { get; set; }

    public virtual DbSet<Tbdisponibilidad> Tbdisponibilidads { get; set; }

    public virtual DbSet<Tbmarca> Tbmarcas { get; set; }

    public virtual DbSet<Tbmodelo> Tbmodelos { get; set; }

    public virtual DbSet<Tbproducto> Tbproductos { get; set; }

    public virtual DbSet<Tbpropietario> Tbpropietarios { get; set; }

    public virtual DbSet<Tbproveedor> Tbproveedors { get; set; }

    public virtual DbSet<Tbrepuesto> Tbrepuestos { get; set; }

    public virtual DbSet<Tbrepuestoenventum> Tbrepuestoenventa { get; set; }

    public virtual DbSet<Tbsucursal> Tbsucursals { get; set; }

    public virtual DbSet<Tbtipocombustible> Tbtipocombustibles { get; set; }

    public virtual DbSet<Tbtipoproducto> Tbtipoproductos { get; set; }

    public virtual DbSet<Tbtipovehiculo> Tbtipovehiculos { get; set; }

    public virtual DbSet<Tbvehiculo> Tbvehiculos { get; set; }

    public virtual DbSet<Tbvehiculoenventum> Tbvehiculoenventa { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("Server=localhost;Port=3315;Database=dbserviciosproductosvehiculos;Uid=root;Pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.1.0-mariadb"));
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Tbaccesorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Nombre).HasDefaultValueSql("''");
            
        });

        modelBuilder.Entity<Tbaccesorioenventum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });
        modelBuilder.Entity<Tbdisponibilidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tbmarca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tbmodelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Modelo).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tbproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.UrlFotografia).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tbpropietario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Apellido).HasDefaultValueSql("''");
            entity.Property(e => e.Correo).HasDefaultValueSql("''");
            entity.Property(e => e.Nombres).HasDefaultValueSql("''");
            entity.Property(e => e.Telefono).HasDefaultValueSql("''");
            modelBuilder.Entity<Tbpropietario>().Ignore(e => e.FechaNacimiento);
        });

        modelBuilder.Entity<Tbproveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Nombre).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tbrepuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tbrepuestoenventum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tbsucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Ciudad).HasDefaultValueSql("''");
            entity.Property(e => e.Dirección).HasDefaultValueSql("''");
            entity.Property(e => e.Nombre).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tbtipocombustible>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.TipoCombustible).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tbtipoproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.TipoProducto).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tbtipovehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.TipoVehiculo).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tbvehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Color).HasDefaultValueSql("'NO ESPECIFICADO'");
        });

        modelBuilder.Entity<Tbvehiculoenventum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public DbSet<ModuloProductos_v1.DTO.Repuesto> Repuesto { get; set; } = default!;
}
