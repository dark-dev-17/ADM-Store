using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class BookAccountDetail
    {
        public int Id { get; set; }
        public int IdBookAccount { get; set; }
        public string? IdItem { get; set; }
        public DateTime DateProcess { get; set; }
        public int TypeDetails { get; set; }
        public decimal Total { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual BookAccount IdBookAccountNavigation { get; set; } = null!;
        public virtual Item? IdItemNavigation { get; set; }
    }
}
