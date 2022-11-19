using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.SalesOrder
{
    public class SalesOrderCreateModel
    {
        public int Customer { get; set; }
        public DateTime DocDate { get; set; }
        public int DocType { get; set; }
        public decimal DocTotal { get; set; }
        public string DocStatus { get; set; } = null!;
    }

    public class SalesOrderDetailsModel
    {
        public int DocNum { get; set; }
        public Customer.CustomerDetailsModel Customer { get; set; } = null!;
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
    }

    public class SalesOrderUpdateModel
    {
        public int DocNum { get; set; }
        public int Customer { get; set; }
        public DateTime DocDate { get; set; }
        public int DocType { get; set; }
        public decimal DocTotal { get; set; }
        public string DocStatus { get; set; } = null!;
        public bool Canceled { get; set; }
        public DateTime CandeledDate { get; set; }
        public string CanceledBy { get; set; } = null!;
    }
}
