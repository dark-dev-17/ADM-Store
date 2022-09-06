using ADM.Store.Models.Models.SupplierStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.Supplier
{
    public class SupplierDetailsModel
    {
        public string CardCode { get; set; } = null!;
        public string SuplierName { get; set; } = null!;
        public bool Active { get; set; }
        public string CreatedBy { get; set; } = null!;
        public SupplierStatusDetailsModel Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class SupplierCreateModel
    {
        public string CardCode { get; set; } = null!;
        public string SuplierName { get; set; } = null!;
        public int SupplierStatus { get; set; }
        public bool Active { get; set; }
    }
    public class SupplierUpdateModel
    {
        public string CardCode { get; set; } = null!;
        public string SuplierName { get; set; } = null!;
        public int SupplierStatus { get; set; }
        public bool Active { get; set; }
    }
}
