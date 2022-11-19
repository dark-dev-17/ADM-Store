using System;
using System.Collections.Generic;

namespace ADM.Store.Api.Entities
{
    public partial class ItemMaterialCat
    {
        public ItemMaterialCat()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string MaterialName { get; set; } = null!;
        public int ItemType { get; set; }

        public virtual ItemTypeCat ItemTypeNavigation { get; set; } = null!;
        public virtual ICollection<Item> Items { get; set; }
    }
}
