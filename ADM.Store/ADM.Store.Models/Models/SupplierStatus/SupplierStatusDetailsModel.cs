using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.SupplierStatus
{
    public class SupplierStatusDetailsModel
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
    }
    public class SupplierStatusUpdateModel
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
    }
    public class SupplierStatusCreateModel
    {
        public string StatusName { get; set; } = null!;
    }
}
