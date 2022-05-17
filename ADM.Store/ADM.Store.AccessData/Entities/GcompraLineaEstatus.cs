using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    internal partial class GcompraLineaEstatus
    {
        public GcompraLineaEstatus()
        {
            GcompraLineas = new HashSet<GcompraLinea>();
        }

        public Guid Id { get; set; }
        public string Estatus { get; set; } = null!;

        public virtual ICollection<GcompraLinea> GcompraLineas { get; set; }
    }
}
