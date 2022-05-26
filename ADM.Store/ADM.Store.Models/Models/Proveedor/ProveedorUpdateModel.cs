using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.Proveedor
{
    public class ProveedorUpdateModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Calle { get; set; } = null!;
        public string Municipio { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string? NoInt { get; set; }
        public string? NoExt { get; set; }
        public string Cp { get; set; } = null!;
        public string? FacePage { get; set; }
        public string? WebPage { get; set; }
    }
}
