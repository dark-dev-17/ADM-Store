using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            OutgoingPayments = new HashSet<OutgoingPayment>();
        }

        public int DocNum { get; set; }
        public string Supplier { get; set; } = null!;
        public int SupplierLocation { get; set; }
        public int SupplierContact { get; set; }
        public DateTime DocDate { get; set; }
        public decimal DocTotal { get; set; }
        public string DocStatus { get; set; } = null!;
        public bool Canceled { get; set; }
        public DateTime CandeledDate { get; set; }
        public string CanceledBy { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual SupplierContact SupplierContactNavigation { get; set; } = null!;
        public virtual SupplierLocation SupplierLocationNavigation { get; set; } = null!;
        public virtual Supplier SupplierNavigation { get; set; } = null!;
        public virtual PurchaseOrderItem PurchaseOrderItem { get; set; } = null!;
        public virtual ICollection<OutgoingPayment> OutgoingPayments { get; set; }
    }
}
