namespace ADM.Store.Models.Models.SupplierLocation
{
    public class SupplierLocationDetailsModel
    {
        public int Id { get; set; }
        public string CardCode { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public string LocationAddress { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public string Town { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? ReferencesCo { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class SupplierLocationUpdateModel
    {
        public int Id { get; set; }
        public string CardCode { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public string LocationAddress { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public string Town { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? ReferencesCo { get; set; }
        public bool Active { get; set; }
    }
    public class SupplierLocationCreateModel
    {
        public string CardCode { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public string LocationAddress { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public string Town { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? ReferencesCo { get; set; }
        public bool Active { get; set; }
    }
}
