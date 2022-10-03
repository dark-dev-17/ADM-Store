using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.PurchaseOrder
{
    public class PurchaseOrderItemDetailsModel
    {
        public int DocNum { get; set; }
        public string ItemCode { get; set; } = null!;
        public string? Variation { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int LineNum { get; set; }
        public string? Reference1 { get; set; }
        public string? Reference2 { get; set; }
        public string? Comments { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class PurchaseOrderItemCreateModel
    {
        public int DocNum { get; set; }
        public string ItemCode { get; set; } = null!;
        public string? Variation { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int LineNum { get; set; }
        public string? Reference1 { get; set; }
        public string? Reference2 { get; set; }
        public string? Comments { get; set; }
    }
    public class PurchaseOrderItemUpdateModel
    {
        public int DocNum { get; set; }
        public string ItemCode { get; set; } = null!;
        public string? Variation { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int LineNum { get; set; }
        public string? Reference1 { get; set; }
        public string? Reference2 { get; set; }
        public string? Comments { get; set; }
    }

    public class PurchaseOrderItemDeleteModel
    {
        public int DocNum { get; set; }
        public string ItemCode { get; set; } = null!;
        public string? Variation { get; set; }
    }
}
