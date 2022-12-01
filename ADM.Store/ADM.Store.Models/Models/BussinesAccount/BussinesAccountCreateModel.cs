using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.BussinesAccount
{
    public class BussinesAccountCreateModel
    {
        public string AccountName { get; set; } = null!;
        public string Comments { get; set; } = null!;
    }
    public class BussinesAccountDetailsModel
    {
        public int Id { get; set; }
        public string AccountName { get; set; } = null!;
        public decimal Balance { get; set; }
        public string Comments { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class BussinesAccountUpdateModel
    {
        public int Id { get; set; }
        public string AccountName { get; set; } = null!;
        public string Comments { get; set; } = null!;
    }
    public class BussinesAccountHistoryDetailsModel
    {
        public int Id { get; set; }
        public int BussinesAccount { get; set; }
        public decimal Total { get; set; }
        public string HistoryType { get; set; } = null!;
        public string? DocRefType { get; set; }
        public int DocRefNum { get; set; }
        public string? Comments { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    //public class BussinesAccountHistoryDetailsModel
    //{
    //    public int Id { get; set; }
    //    public int BussinesAccount { get; set; }
    //    public decimal Total { get; set; }
    //    public string HistoryType { get; set; } = null!;
    //    public string? DocRefType { get; set; }
    //    public int DocRefNum { get; set; }
    //    public string? Comments { get; set; }
    //    public string CreatedBy { get; set; } = null!;
    //    public DateTime CreatedAt { get; set; }
    //    public DateTime UpdatedAt { get; set; }
    //}
}
