namespace ADM.Store.Models.Models.ItemSubCategory
{
    public class ItemSubCategoryUpdateModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public int CategoryParent { get; set; }
    }
}
