using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class SupplierStatusCat
    {
        public SupplierStatusCat()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
