namespace ADM.Store.Models.Models.ItemSubCategory
{
    public class ItemSubCategoryCreateModel
    {
        public int ItemType { get; set; }
        public string CategoryName { get; set; } = null!;
        public int? CategoryParent { get; set; }
    }
}
