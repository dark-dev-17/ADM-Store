using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    internal partial class Client
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
