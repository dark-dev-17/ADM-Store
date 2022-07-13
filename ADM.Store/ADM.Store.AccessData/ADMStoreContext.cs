using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ADM.Store.AccessData.Entities;

namespace ADM.Store.AccessData
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

        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemCategoryCat> ItemCategoryCats { get; set; } = null!;
        public virtual DbSet<ItemMaterialCat> ItemMaterialCats { get; set; } = null!;
        public virtual DbSet<ItemOption> ItemOptions { get; set; } = null!;
        public virtual DbSet<ItemStatus> ItemStatuses { get; set; } = null!;
        public virtual DbSet<ItemTag> ItemTags { get; set; } = null!;
        public virtual DbSet<ItemTagsCat> ItemTagsCats { get; set; } = null!;
        public virtual DbSet<ItemThemeCat> ItemThemeCats { get; set; } = null!;
        public virtual DbSet<ItemTypeCat> ItemTypeCats { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=admstore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemCode)
                    .HasName("PK__Item__3ECC0FEBE991419D");

                entity.ToTable("Item");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ColorCode).HasMaxLength(100);

                entity.Property(e => e.ColorName).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.ItemDescription).HasColumnType("text");

                entity.Property(e => e.Size).HasMaxLength(10);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.ItemCategoryNavigations)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__Category__36B12243");

                entity.HasOne(d => d.ItemStatusNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__ItemStatus__33D4B598");

                entity.HasOne(d => d.ItemTypeNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__ItemType__34C8D9D1");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Material)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__Material__35BCFE0A");

                entity.HasOne(d => d.SubCategoryNavigation)
                    .WithMany(p => p.ItemSubCategoryNavigations)
                    .HasForeignKey(d => d.SubCategory)
                    .HasConstraintName("FK__Item__SubCategor__37A5467C");
            });

            modelBuilder.Entity<ItemCategoryCat>(entity =>
            {
                entity.ToTable("ItemCategoryCat");

                entity.Property(e => e.CategoryName).HasMaxLength(150);

                entity.HasOne(d => d.ItemTypeNavigation)
                    .WithMany(p => p.ItemCategoryCats)
                    .HasForeignKey(d => d.ItemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemCateg__ItemT__38996AB5");
            });

            modelBuilder.Entity<ItemMaterialCat>(entity =>
            {
                entity.ToTable("ItemMaterialCat");

                entity.Property(e => e.MaterialName).HasMaxLength(150);

                entity.HasOne(d => d.ItemTypeNavigation)
                    .WithMany(p => p.ItemMaterialCats)
                    .HasForeignKey(d => d.ItemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemMater__ItemT__3A81B327");
            });

            modelBuilder.Entity<ItemOption>(entity =>
            {
                entity.ToTable("ItemOption");

                entity.Property(e => e.ColorCode).HasMaxLength(100);

                entity.Property(e => e.ColorName).HasMaxLength(100);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemDescription).HasColumnType("text");

                entity.Property(e => e.Size).HasMaxLength(10);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Variation).HasMaxLength(3);

                entity.HasOne(d => d.ItemCodeNavigation)
                    .WithMany(p => p.ItemOptions)
                    .HasForeignKey(d => d.ItemCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemOptio__ItemC__3B75D760");
            });

            modelBuilder.Entity<ItemStatus>(entity =>
            {
                entity.ToTable("ItemStatus");

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<ItemTag>(entity =>
            {
                entity.HasKey(e => new { e.ItemCode, e.ItemTag1 })
                    .HasName("PK__ItemTag__AC8020E3E914CFD6");

                entity.ToTable("ItemTag");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemTag1).HasColumnName("ItemTag");
            });

            modelBuilder.Entity<ItemTagsCat>(entity =>
            {
                entity.ToTable("ItemTagsCat");

                entity.Property(e => e.TagName).HasMaxLength(200);

                entity.HasOne(d => d.ItemTypeNavigation)
                    .WithMany(p => p.ItemTagsCats)
                    .HasForeignKey(d => d.ItemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemTagsC__ItemT__3C69FB99");
            });

            modelBuilder.Entity<ItemThemeCat>(entity =>
            {
                entity.ToTable("ItemThemeCat");

                entity.Property(e => e.ThemeName).HasMaxLength(50);

                entity.HasOne(d => d.ItemTypeNavigation)
                    .WithMany(p => p.ItemThemeCats)
                    .HasForeignKey(d => d.ItemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemTheme__ItemT__3D5E1FD2");
            });

            modelBuilder.Entity<ItemTypeCat>(entity =>
            {
                entity.ToTable("ItemTypeCat");

                entity.Property(e => e.TypeName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
