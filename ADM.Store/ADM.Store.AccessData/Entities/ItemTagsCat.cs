using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class ItemTagsCat
    {
        public int Id { get; set; }
        public string TagName { get; set; } = null!;
        public int ItemType { get; set; }

        public virtual ItemTypeCat ItemTypeNavigation { get; set; } = null!;
    }
}
