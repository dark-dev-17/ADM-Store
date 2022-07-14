using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.ItemMaterial
{
    public class ItemMaterialUpdateModel
    {
        public int Id { get; set; }
        public string MaterialName { get; set; } = null!;
    }
}
