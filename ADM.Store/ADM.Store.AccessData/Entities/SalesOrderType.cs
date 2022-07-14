using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class SalesOrderType
    {
        public SalesOrderType()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
