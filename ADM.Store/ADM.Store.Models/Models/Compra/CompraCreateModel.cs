﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.AccessData")]
[assembly: InternalsVisibleTo("ADM.Store.Service")]
[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Models.Models.Compra
{
    internal class CompraCreateModel
    {
        public Guid IdProveedor { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}