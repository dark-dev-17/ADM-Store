using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class SupplierContact
    {
        public SupplierContact()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int Id { get; set; }
        public string CardCode { get; set; } = null!;
        public string SupplierName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool Active { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Supplier CardCodeNavigation { get; set; } = null!;
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
