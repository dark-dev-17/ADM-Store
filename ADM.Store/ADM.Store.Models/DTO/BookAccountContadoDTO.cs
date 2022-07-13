using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.DTO
{
    public class BookAccountContadoDTO
    {
        public int IdBookAccount { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal PendingPaid { get { return Total - TotalPaid; } }
        public DateTime? LastMovimiento { get; set; }
        public string? LastMovDescription { get; set; }

    }
}
