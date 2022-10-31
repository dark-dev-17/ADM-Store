using ADM.Store.Models.Models.Supplier;
using ADM.Store.Models.Models.SupplierContact;
using ADM.Store.Models.Models.SupplierLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.PurchaseOrder
{
    public class PurchaseOrderDetailsModel
    {
        public int DocNum { get; set; }
        public string CardCode { get; set; } = null!;
        public SupplierDetailsModel Supplier { get; set; } = null!;
        public SupplierLocationDetailsModel Location { get; set; } = null!;
        public SupplierContactDetailsModel Contact { get; set; } = null!;
        public List<PurchaseOrderItemDetailsModel> Items { get; set; } = new List<PurchaseOrderItemDetailsModel>();
        public DateTime DocDate { get; set; }
        public string DocStatus { get; set; } = null!;
        public bool Canceled { get; set; }
        public DateTime CandeledDate { get; set; }
        public decimal DocTotal { get; set; }
        public decimal DocTotalSales
        {
            get
            {
                return Items.Sum(item => item.PriceSale);
            }
        }
        public decimal DocTotalRevenue
        {
            get
            {
                return Items.Sum(item => item.TotalRevenue);
            }
        }
        public string CanceledBy { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class PurchaseOrderBasicDetailsModel
    {
        public int DocNum { get; set; }
        public string CardCode { get; set; } = null!;
        public SupplierDetailsModel Supplier { get; set; } = null!;
        public DateTime DocDate { get; set; }
        public string DocStatus { get; set; } = null!;
        public decimal DocTotal { get; set; }
        public bool Canceled { get; set; }
        public DateTime CandeledDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
    }

    public class PurchaseOrderCreateModel
    {
        public string CardCode { get; set; } = null!;
        public int SupplierLocation { get; set; }
        public int SupplierContact { get; set; }
        public DateTime DocDate { get; set; }
        public string DocStatus { get; set; } = null!;
        public List<PurchaseOrderItemCreateModel> newItems { get; set; } = new List<PurchaseOrderItemCreateModel>();
    }

    public class PurchaseOrderUpdateModel
    {
        public int DocNum { get; set; }
        public string CardCode { get; set; } = null!;
        public int SupplierLocation { get; set; }
        public int SupplierContact { get; set; }
        public DateTime DocDate { get; set; }
        public string DocStatus { get; set; } = null!;
        public List<PurchaseOrderItemCreateModel> newItems { get; set; } = new List<PurchaseOrderItemCreateModel>();
        public List<PurchaseOrderItemUpdateModel> updateItems { get; set; } = new List<PurchaseOrderItemUpdateModel>();
        public List<PurchaseOrderItemDeleteModel> deleteItems { get; set; } = new List<PurchaseOrderItemDeleteModel>();
    }
}
