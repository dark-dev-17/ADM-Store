namespace ADM.Store.Models.Models.SupplierContact
{
    public class SupplierContactDetailsModel
    {
        public int Id { get; set; }
        public string CardCode { get; set; } = null!;
        public string SupplierName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool Active { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class SupplierContactCreateModel
    {
        public string CardCode { get; set; } = null!;
        public string SupplierName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool Active { get; set; }
    }
    public class SupplierContactUpdateModel
    {
        public int Id { get; set; }
        public string CardCode { get; set; } = null!;
        public string SupplierName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool Active { get; set; }
    }
}
