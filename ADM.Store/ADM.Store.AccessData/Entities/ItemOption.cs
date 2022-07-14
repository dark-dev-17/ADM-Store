using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class ItemOption
    {
        public string ItemCode { get; set; } = null!;
        public string Variation { get; set; } = null!;
        public string ItemTile { get; set; } = null!;
        public string ItemDescription { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public string Size { get; set; } = null!;
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Item ItemCodeNavigation { get; set; } = null!;
    }
}
