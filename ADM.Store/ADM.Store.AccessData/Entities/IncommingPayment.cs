using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class IncommingPayment
    {
        public int Id { get; set; }
        public int Customer { get; set; }
        public int? DocNum { get; set; }
        public decimal Total { get; set; }
        public DateTime PaymentDate { get; set; }
        public int BussinesAccount { get; set; }
        public string? Comments { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual BussinesAccount BussinesAccountNavigation { get; set; } = null!;
        public virtual Customer CustomerNavigation { get; set; } = null!;
        public virtual SalesOrder? DocNumNavigation { get; set; }
    }
}
