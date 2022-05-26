using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Enums
{
    internal enum ProcessActionResultTypes
    {
        Created,
        NotCreated,
        InValidModel,
        RelationNotFound,
        NotFound,
        DataIncongruity,
        Updated,
        NotUpdated,
        Deleted,
        NotDelated
    }
}
