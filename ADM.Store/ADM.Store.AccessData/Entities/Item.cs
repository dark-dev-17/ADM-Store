using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    internal partial class Item
    {
        public Item()
        {
            BookAccountDetails = new HashSet<BookAccountDetail>();
        }

        public string Id { get; set; } = null!;
        public string ItemDescription { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int IdCategory { get; set; }
        public int IdSubCategory { get; set; }
        public int IdMaterial { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Category IdCategoryNavigation { get; set; } = null!;
        public virtual ItemMaterial IdMaterialNavigation { get; set; } = null!;
        public virtual Category IdSubCategoryNavigation { get; set; } = null!;
        public virtual ICollection<BookAccountDetail> BookAccountDetails { get; set; }
    }
}
