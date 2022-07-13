using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Service.Enums
{
    internal enum DeleteResultTypes
    {
        Deleted,
        NotDeleted,
        InValidModel,
        RelationNotFound,
        NotFound
    }
}
