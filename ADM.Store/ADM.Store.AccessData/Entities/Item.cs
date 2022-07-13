using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class Item
    {
        public Item()
        {
            ItemOptions = new HashSet<ItemOption>();
        }

        public string ItemCode { get; set; } = null!;
        public string ItemTile { get; set; } = null!;
        public string ItemDescription { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public bool ChageTax { get; set; }
        public int Stock { get; set; }
        public int ItemStatus { get; set; }
        public int ItemType { get; set; }
        public int Material { get; set; }
        public int Category { get; set; }
        public int? SubCategory { get; set; }
        public bool ManagedByOptions { get; set; }
        public string Size { get; set; } = null!;
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ItemCategoryCat CategoryNavigation { get; set; } = null!;
        public virtual ItemStatus ItemStatusNavigation { get; set; } = null!;
        public virtual ItemTypeCat ItemTypeNavigation { get; set; } = null!;
        public virtual ItemMaterialCat MaterialNavigation { get; set; } = null!;
        public virtual ItemCategoryCat? SubCategoryNavigation { get; set; }
        public virtual ICollection<ItemOption> ItemOptions { get; set; }
    }
}
