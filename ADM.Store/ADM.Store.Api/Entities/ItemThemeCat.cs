using System;
using System.Collections.Generic;

namespace ADM.Store.Api.Entities
{
    public partial class ItemThemeCat
    {
        public int Id { get; set; }
        public string ThemeName { get; set; } = null!;
        public bool Active { get; set; }
        public int ItemType { get; set; }

        public virtual ItemTypeCat ItemTypeNavigation { get; set; } = null!;
    }
}
