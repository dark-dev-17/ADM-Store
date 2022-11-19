using System;
using System.Collections.Generic;

namespace ADM.Store.Api.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            SupplierContacts = new HashSet<SupplierContact>();
            SupplierLocations = new HashSet<SupplierLocation>();
        }

        public string CardCode { get; set; } = null!;
        public string SuplierName { get; set; } = null!;
        public int SupplierStatus { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual SupplierStatusCat SupplierStatusNavigation { get; set; } = null!;
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<SupplierContact> SupplierContacts { get; set; }
        public virtual ICollection<SupplierLocation> SupplierLocations { get; set; }
    }
}
