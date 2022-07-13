using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models
{
    public class AbonoCreateModel
    {
        public int idBookAccount { get; set; }
        public DateTime DateAbono { get; set; }
        public decimal Total { get; set; }
    }

    public class SaleCreateModel
    {
        public int idBookAccount { get; set; }
        public DateTime DateSale { get; set; }
        public decimal Total { get; set; }
        public string IdItem { get; set; }
    }
}
