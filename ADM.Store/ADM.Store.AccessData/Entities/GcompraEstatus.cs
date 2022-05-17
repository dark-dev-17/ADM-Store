using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    internal partial class GcompraEstatus
    {
        public GcompraEstatus()
        {
            Gcompras = new HashSet<Gcompra>();
        }

        public Guid Id { get; set; }
        public string Estatus { get; set; } = null!;

        public virtual ICollection<Gcompra> Gcompras { get; set; }
    }
}
