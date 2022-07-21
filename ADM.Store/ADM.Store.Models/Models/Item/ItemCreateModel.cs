namespace ADM.Store.Models.Models.Item
{
    public class ItemCreateModel
    {
        public string ItemCode { get; set; } = null!;
        public string ItemTile { get; set; } = null!;
        public string ItemDescription { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public bool ChageTax { get; set; }
        public int Stock { get; set; }
        public int ItemType { get; set; }
        public int Material { get; set; }
        public int Category { get; set; }
        public int? SubCategory { get; set; }
        public bool ManagedByOptions { get; set; }
        public string Size { get; set; } = null!;
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
    }
}
