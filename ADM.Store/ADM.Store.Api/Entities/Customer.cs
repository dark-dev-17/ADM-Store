using System;
using System.Collections.Generic;

namespace ADM.Store.Api.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            IncommingPayments = new HashSet<IncommingPayment>();
            SalesOrders = new HashSet<SalesOrder>();
        }

        public int Id { get; set; }
        public string FirtName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Group1 { get; set; }
        public int Group2 { get; set; }
        public int Group3 { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<IncommingPayment> IncommingPayments { get; set; }
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
