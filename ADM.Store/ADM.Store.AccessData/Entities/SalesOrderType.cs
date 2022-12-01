using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class SalesOrderType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
    }
}
