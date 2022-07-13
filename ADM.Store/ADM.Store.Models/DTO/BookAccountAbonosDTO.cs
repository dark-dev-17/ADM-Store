using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.DTO
{
    public class BookAccountAbonosDTO
    {
        public int IdBookAccount { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal PendingPaid { get; set; }
        public DateTime LastMovimiento { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string LastMovDescription { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
