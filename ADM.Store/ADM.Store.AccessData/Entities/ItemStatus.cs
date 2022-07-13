using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class ItemStatus
    {
        public ItemStatus()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
