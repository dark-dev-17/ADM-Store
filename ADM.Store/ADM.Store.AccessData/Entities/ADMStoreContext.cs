using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADM.Store.AccessData.Entities
{
    public partial class ADMStoreContext : DbContext
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
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemMaterial> ItemMaterials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=admstore;Trusted_Connection=True;");
#pragma warning restore CS1030 // #warning directive
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

                entity.Property(e => e.IdItem).HasMaxLength(50);

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.IdBookAccountNavigation)
                    .WithMany(p => p.BookAccountDetails)
                    .HasForeignKey(d => d.IdBookAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookAccou__IdBoo__36B12243");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.BookAccountDetails)
                    .HasForeignKey(d => d.IdItem)
                    .HasConstraintName("FK__BookAccou__IdIte__37A5467C");
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
                    .HasConstraintName("FK__Item__IdCategory__2F10007B");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__IdMaterial__30F848ED");

                entity.HasOne(d => d.IdSubCategoryNavigation)
                    .WithMany(p => p.ItemIdSubCategoryNavigations)
                    .HasForeignKey(d => d.IdSubCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__IdSubCateg__300424B4");
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
