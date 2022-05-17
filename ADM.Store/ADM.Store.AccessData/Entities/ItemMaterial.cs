using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    internal partial class ItemMaterial
    {
        public ItemMaterial()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
