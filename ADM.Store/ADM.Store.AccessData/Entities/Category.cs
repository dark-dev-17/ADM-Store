using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    internal partial class Category
    {
        public Category()
        {
            ItemIdCategoryNavigations = new HashSet<Item>();
            ItemIdSubCategoryNavigations = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int? ParentId { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Item> ItemIdCategoryNavigations { get; set; }
        public virtual ICollection<Item> ItemIdSubCategoryNavigations { get; set; }
    }
}
