using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    internal partial class Gproveedor
    {
        public Gproveedor()
        {
            Gcompras = new HashSet<Gcompra>();
        }

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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Gcompra> Gcompras { get; set; }
    }
}
