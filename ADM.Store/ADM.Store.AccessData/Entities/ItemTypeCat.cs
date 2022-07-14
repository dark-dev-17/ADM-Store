using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class ItemTypeCat
    {
        public ItemTypeCat()
        {
            ItemCategoryCats = new HashSet<ItemCategoryCat>();
            ItemMaterialCats = new HashSet<ItemMaterialCat>();
            ItemTagsCats = new HashSet<ItemTagsCat>();
            ItemThemeCats = new HashSet<ItemThemeCat>();
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<ItemCategoryCat> ItemCategoryCats { get; set; }
        public virtual ICollection<ItemMaterialCat> ItemMaterialCats { get; set; }
        public virtual ICollection<ItemTagsCat> ItemTagsCats { get; set; }
        public virtual ICollection<ItemThemeCat> ItemThemeCats { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
