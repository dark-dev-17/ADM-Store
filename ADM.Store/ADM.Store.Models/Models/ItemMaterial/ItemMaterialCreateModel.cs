using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.ItemMaterial
{
    public class ItemMaterialCreateModel
    {
        public string MaterialName { get; set; } = null!;
        public int ItemType { get; set; }
    }
}
