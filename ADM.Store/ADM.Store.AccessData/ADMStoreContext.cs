﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ADM.Store.AccessData.Entities;

namespace ADM.Store.AccessData
{
    internal partial class ADMStoreContext : DbContext
    {
        public ADMStoreContext()
        {
        }

        public ADMStoreContext(DbContextOptions<ADMStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookAccount> BookAccounts { get; set; } = null!;
        public virtual DbSet<BookAccountDetail> BookAccountDetails { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Gcompra> Gcompras { get; set; } = null!;
        public virtual DbSet<GcompraEstatus> GcompraEstatuses { get; set; } = null!;
        public virtual DbSet<GcompraLinea> GcompraLineas { get; set; } = null!;
        public virtual DbSet<GcompraLineaEstatus> GcompraLineaEstatuses { get; set; } = null!;
        public virtual DbSet<GcompraTipo> GcompraTipos { get; set; } = null!;
        public virtual DbSet<Gcuenta> Gcuentas { get; set; } = null!;
        public virtual DbSet<Gproveedor> Gproveedors { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemMaterial> ItemMaterials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=admstore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAccount>(entity =>
            {
                entity.ToTable("BookAccount");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotalPaid).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<BookAccountDetail>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.DateProcess).HasColumnType("date");

                entity.Property(e => e.IdItem).HasMaxLength(50);

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.IdBookAccountNavigation)
                    .WithMany(p => p.BookAccountDetails)
                    .HasForeignKey(d => d.IdBookAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookAccou__IdBoo__3B75D760");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.BookAccountDetails)
                    .HasForeignKey(d => d.IdItem)
                    .HasConstraintName("FK__BookAccou__IdIte__3C69FB99");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClientName).HasMaxLength(200);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.PhoneNumber).HasMaxLength(12);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Gcompra>(entity =>
            {
                entity.ToTable("GCompra");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FechaCompra).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.IdCompraEstatusNavigation)
                    .WithMany(p => p.Gcompras)
                    .HasForeignKey(d => d.IdCompraEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GCompra__IdCompr__3F466844");

                entity.HasOne(d => d.IdCompraTipoNavigation)
                    .WithMany(p => p.Gcompras)
                    .HasForeignKey(d => d.IdCompraTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GCompra__IdCompr__3E52440B");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Gcompras)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GCompra__IdProve__3D5E1FD2");
            });

            modelBuilder.Entity<GcompraEstatus>(entity =>
            {
                entity.ToTable("GCompraEstatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Estatus).HasMaxLength(50);
            });

            modelBuilder.Entity<GcompraLinea>(entity =>
            {
                entity.ToTable("GCompraLinea");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.FolioNota).HasMaxLength(50);

                entity.Property(e => e.PrecioAproxVenta).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.GcompraLineas)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GCompraLi__IdCom__412EB0B6");

                entity.HasOne(d => d.IdCompraLineaEstatusNavigation)
                    .WithMany(p => p.GcompraLineas)
                    .HasForeignKey(d => d.IdCompraLineaEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GCompraLi__IdCom__403A8C7D");
            });

            modelBuilder.Entity<GcompraLineaEstatus>(entity =>
            {
                entity.ToTable("GCompraLineaEstatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Estatus).HasMaxLength(100);
            });

            modelBuilder.Entity<GcompraTipo>(entity =>
            {
                entity.ToTable("GCompraTipo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Estatus).HasMaxLength(200);
            });

            modelBuilder.Entity<Gcuenta>(entity =>
            {
                entity.ToTable("GCuenta");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(300);
            });

            modelBuilder.Entity<Gproveedor>(entity =>
            {
                entity.ToTable("GProveedor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Calle).HasMaxLength(200);

                entity.Property(e => e.Cp)
                    .HasMaxLength(6)
                    .HasColumnName("CP");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Estado).HasMaxLength(5);

                entity.Property(e => e.Municipio).HasMaxLength(200);

                entity.Property(e => e.NoExt).HasMaxLength(20);

                entity.Property(e => e.NoInt).HasMaxLength(20);

                entity.Property(e => e.Nombre).HasMaxLength(300);

                entity.Property(e => e.Telefono).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.ItemIdCategoryNavigations)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__IdCategory__4222D4EF");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__IdMaterial__440B1D61");

                entity.HasOne(d => d.IdSubCategoryNavigation)
                    .WithMany(p => p.ItemIdSubCategoryNavigations)
                    .HasForeignKey(d => d.IdSubCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__IdSubCateg__4316F928");
            });

            modelBuilder.Entity<ItemMaterial>(entity =>
            {
                entity.ToTable("ItemMaterial");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
