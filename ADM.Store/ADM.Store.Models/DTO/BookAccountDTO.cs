using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.DTO
{
    /// <summary>
    /// Details for BookAccount
    /// </summary>
    public class BookAccountDTO
    {
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal PendingPaid { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string CreatedBy { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DateTime UpdatedAt { get; set; }
    }
}
