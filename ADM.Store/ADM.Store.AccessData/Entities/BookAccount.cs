using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class BookAccount
    {
        public BookAccount()
        {
            BookAccountDetails = new HashSet<BookAccountDetail>();
        }

        public int Id { get; set; }
        public Guid IdClient { get; set; }
        public int NoAccount { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalPaid { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<BookAccountDetail> BookAccountDetails { get; set; }
    }
}
