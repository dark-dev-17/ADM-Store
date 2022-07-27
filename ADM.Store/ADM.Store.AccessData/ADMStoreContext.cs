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

        public virtual DbSet<BussinesAccount> BussinesAccounts { get; set; } = null!;
        public virtual DbSet<BussinesAccountHistory> BussinesAccountHistories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<IncommingPayment> IncommingPayments { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemCategoryCat> ItemCategoryCats { get; set; } = null!;
        public virtual DbSet<ItemMaterialCat> ItemMaterialCats { get; set; } = null!;
        public virtual DbSet<ItemOption> ItemOptions { get; set; } = null!;
        public virtual DbSet<ItemStatus> ItemStatuses { get; set; } = null!;
        public virtual DbSet<ItemTag> ItemTags { get; set; } = null!;
        public virtual DbSet<ItemTagsCat> ItemTagsCats { get; set; } = null!;
        public virtual DbSet<ItemThemeCat> ItemThemeCats { get; set; } = null!;
        public virtual DbSet<ItemTypeCat> ItemTypeCats { get; set; } = null!;
        public virtual DbSet<OutgoingPayment> OutgoingPayments { get; set; } = null!;
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; } = null!;
        public virtual DbSet<SalesOrder> SalesOrders { get; set; } = null!;
        public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; } = null!;
        public virtual DbSet<SalesOrderType> SalesOrderTypes { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierContact> SupplierContacts { get; set; } = null!;
        public virtual DbSet<SupplierLocation> SupplierLocations { get; set; } = null!;
        public virtual DbSet<SupplierStatusCat> SupplierStatusCats { get; set; } = null!;

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
            modelBuilder.Entity<BussinesAccount>(entity =>
            {
                entity.ToTable("BussinesAccount");

                entity.Property(e => e.AccountName).HasMaxLength(150);

                entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<BussinesAccountHistory>(entity =>
            {
                entity.ToTable("BussinesAccountHistory");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.DocRefType).HasMaxLength(3);

                entity.Property(e => e.HistoryType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FirtName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<IncommingPayment>(entity =>
            {
                entity.ToTable("IncommingPayment");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.BussinesAccountNavigation)
                    .WithMany(p => p.IncommingPayments)
                    .HasForeignKey(d => d.BussinesAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incomming__Bussi__70DDC3D8");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.IncommingPayments)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incomming__Custo__6EF57B66");

                entity.HasOne(d => d.DocNumNavigation)
                    .WithMany(p => p.IncommingPayments)
                    .HasForeignKey(d => d.DocNum)
                    .HasConstraintName("FK__Incomming__DocNu__6FE99F9F");
            });

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
                entity.HasKey(e => new { e.ItemCode, e.Variation })
                    .HasName("PK__tmp_ms_x__D8C03FDC4C437608");

                entity.ToTable("ItemOption");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.Variation).HasMaxLength(3);

                entity.Property(e => e.ColorCode).HasMaxLength(100);

                entity.Property(e => e.ColorName).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.ItemDescription).HasColumnType("text");

                entity.Property(e => e.Size).HasMaxLength(10);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.ItemCodeNavigation)
                    .WithMany(p => p.ItemOptions)
                    .HasForeignKey(d => d.ItemCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemOptio__ItemC__02FC7413");
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

            modelBuilder.Entity<OutgoingPayment>(entity =>
            {
                entity.ToTable("OutgoingPayment");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.BussinesAccountNavigation)
                    .WithMany(p => p.OutgoingPayments)
                    .HasForeignKey(d => d.BussinesAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OutgoingP__Bussi__72C60C4A");

                entity.HasOne(d => d.DocNumNavigation)
                    .WithMany(p => p.OutgoingPayments)
                    .HasForeignKey(d => d.DocNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OutgoingP__DocNu__71D1E811");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.DocNum)
                    .HasName("PK__Purchase__420AEAF15E5BF624");

                entity.ToTable("PurchaseOrder");

                entity.Property(e => e.CanceledBy).HasMaxLength(200);

                entity.Property(e => e.CandeledDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.DocDate).HasColumnType("date");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DocTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Supplier).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.SupplierNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.Supplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PurchaseO__Suppl__5629CD9C");

                entity.HasOne(d => d.SupplierContactNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.SupplierContact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PurchaseO__Suppl__5812160E");

                entity.HasOne(d => d.SupplierLocationNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.SupplierLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PurchaseO__Suppl__571DF1D5");
            });

            modelBuilder.Entity<PurchaseOrderItem>(entity =>
            {
                entity.HasKey(e => e.DocNum)
                    .HasName("PK__tmp_ms_x__420AEAF171D48FC1");

                entity.ToTable("PurchaseOrderItem");

                entity.Property(e => e.DocNum).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.Reference1).HasMaxLength(50);

                entity.Property(e => e.Reference2).HasMaxLength(50);

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.Variation).HasMaxLength(3);

                entity.HasOne(d => d.DocNumNavigation)
                    .WithOne(p => p.PurchaseOrderItem)
                    .HasForeignKey<PurchaseOrderItem>(d => d.DocNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PurchaseO__DocNu__6D0D32F4");

                entity.HasOne(d => d.ItemCodeNavigation)
                    .WithMany(p => p.PurchaseOrderItems)
                    .HasForeignKey(d => d.ItemCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PurchaseO__ItemC__6E01572D");
            });

            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.HasKey(e => e.DocNum)
                    .HasName("PK__SalesOrd__420AEAF1FD3E8C1C");

                entity.ToTable("SalesOrder");

                entity.Property(e => e.CanceledBy).HasMaxLength(200);

                entity.Property(e => e.CandeledDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.DocDate).HasColumnType("date");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DocTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.SalesOrders)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SalesOrde__Custo__73BA3083");

                entity.HasOne(d => d.DocTypeNavigation)
                    .WithMany(p => p.SalesOrders)
                    .HasForeignKey(d => d.DocType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SalesOrde__DocTy__74AE54BC");
            });

            modelBuilder.Entity<SalesOrderItem>(entity =>
            {
                entity.ToTable("SalesOrderItem");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.Reference1).HasMaxLength(50);

                entity.Property(e => e.Reference2).HasMaxLength(50);

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.Variation).HasMaxLength(3);

                entity.HasOne(d => d.DocNumNavigation)
                    .WithMany(p => p.SalesOrderItems)
                    .HasForeignKey(d => d.DocNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SalesOrde__DocNu__75A278F5");

                entity.HasOne(d => d.ItemCodeNavigation)
                    .WithMany(p => p.SalesOrderItems)
                    .HasForeignKey(d => d.ItemCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SalesOrde__ItemC__76969D2E");
            });

            modelBuilder.Entity<SalesOrderType>(entity =>
            {
                entity.ToTable("SalesOrderType");

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.CardCode)
                    .HasName("PK__Supplier__3D531706D5C8710C");

                entity.ToTable("Supplier");

                entity.Property(e => e.CardCode).HasMaxLength(20);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.SuplierName).HasMaxLength(150);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.SupplierStatusNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.SupplierStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplier__Suppli__59063A47");
            });

            modelBuilder.Entity<SupplierContact>(entity =>
            {
                entity.ToTable("SupplierContact");

                entity.Property(e => e.CardCode).HasMaxLength(20);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.CardCodeNavigation)
                    .WithMany(p => p.SupplierContacts)
                    .HasForeignKey(d => d.CardCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplierC__CardC__59FA5E80");
            });

            modelBuilder.Entity<SupplierLocation>(entity =>
            {
                entity.ToTable("SupplierLocation");

                entity.Property(e => e.CardCode).HasMaxLength(20);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.StateName).HasMaxLength(30);

                entity.Property(e => e.Town).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.ZipCode).HasMaxLength(5);

                entity.HasOne(d => d.CardCodeNavigation)
                    .WithMany(p => p.SupplierLocations)
                    .HasForeignKey(d => d.CardCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplierL__CardC__5AEE82B9");
            });

            modelBuilder.Entity<SupplierStatusCat>(entity =>
            {
                entity.ToTable("SupplierStatusCat");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StatusName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
