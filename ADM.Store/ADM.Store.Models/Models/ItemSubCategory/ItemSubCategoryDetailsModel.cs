using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.ItemSubCategory
{
    public class ItemSubCategoryDetailsModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public int? CategoryParent { get; set; }
    }
}
