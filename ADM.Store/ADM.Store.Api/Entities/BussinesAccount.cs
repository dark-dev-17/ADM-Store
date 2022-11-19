using System;
using System.Collections.Generic;

namespace ADM.Store.Api.Entities
{
    public partial class BussinesAccount
    {
        public BussinesAccount()
        {
            IncommingPayments = new HashSet<IncommingPayment>();
            OutgoingPayments = new HashSet<OutgoingPayment>();
        }

        public int Id { get; set; }
        public string AccountName { get; set; } = null!;
        public decimal Balance { get; set; }
        public string? Comments { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<IncommingPayment> IncommingPayments { get; set; }
        public virtual ICollection<OutgoingPayment> OutgoingPayments { get; set; }
    }
}
