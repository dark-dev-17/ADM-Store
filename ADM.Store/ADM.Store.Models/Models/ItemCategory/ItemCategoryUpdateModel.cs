namespace ADM.Store.Models.Models.ItemCategory
{
    public class ItemCategoryUpdateModel
    {
        public int Id { get; set; }
        public int IdItemType { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
