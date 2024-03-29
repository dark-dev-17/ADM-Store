﻿using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class BussinesAccountHistory
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
}
