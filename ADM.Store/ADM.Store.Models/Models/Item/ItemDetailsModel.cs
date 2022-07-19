using ADM.Store.Models.Models.ItemCategory;
using ADM.Store.Models.Models.ItemMaterial;
using ADM.Store.Models.Models.ItemStatus;
using ADM.Store.Models.Models.ItemSubCategory;
using ADM.Store.Models.Models.ItemType;

namespace ADM.Store.Models.Models.Item
{
    public class ItemDetailsModel
    {
        public string ItemCode { get; set; } = null!;
        public string ItemTile { get; set; } = null!;
        public string ItemDescription { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public bool ChageTax { get; set; }
        public int Stock { get; set; }
        public ItemStatusDetailsModel ItemStatus { get; set; } = null!;
        public ItemTypeDetailsModel ItemType { get; set; } = null!;
        public ItemMaterialDetailsModel Material { get; set; } = null!;
        public ItemCategoryDetailsModel Category { get; set; } = null!;
        public ItemSubCategoryDetailsModel? SubCategory { get; set; }
        public bool ManagedByOptions { get; set; }
        public string Size { get; set; } = null!;
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
