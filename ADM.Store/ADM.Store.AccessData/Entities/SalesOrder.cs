using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class SalesOrder
    {
        public SalesOrder()
        {
            IncommingPayments = new HashSet<IncommingPayment>();
            SalesOrderItems = new HashSet<SalesOrderItem>();
        }

        public int DocNum { get; set; }
        public int Customer { get; set; }
        public DateTime DocDate { get; set; }
        public int DocType { get; set; }
        public decimal DocTotal { get; set; }
        public string DocStatus { get; set; } = null!;
        public bool Canceled { get; set; }
        public DateTime CandeledDate { get; set; }
        public string CanceledBy { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Customer CustomerNavigation { get; set; } = null!;
        public virtual SalesOrderType DocTypeNavigation { get; set; } = null!;
        public virtual ICollection<IncommingPayment> IncommingPayments { get; set; }
        public virtual ICollection<SalesOrderItem> SalesOrderItems { get; set; }
    }
}
