using System;
using System.Collections.Generic;

namespace ADM.Store.Api.Entities
{
    public partial class ItemCategoryCat
    {
        public ItemCategoryCat()
        {
            ItemCategoryNavigations = new HashSet<Item>();
            ItemSubCategoryNavigations = new HashSet<Item>();
        }

        public int Id { get; set; }
        public int ItemType { get; set; }
        public string CategoryName { get; set; } = null!;
        public int? CategoryParent { get; set; }

        public virtual ItemTypeCat ItemTypeNavigation { get; set; } = null!;
        public virtual ICollection<Item> ItemCategoryNavigations { get; set; }
        public virtual ICollection<Item> ItemSubCategoryNavigations { get; set; }
    }
}
