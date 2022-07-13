using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Compra;
using ADM.Store.Models.Models.Proveedor;
using ADM.Store.Service.Enums;
using ADM.Store.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services
{
    internal class CompraTipoService : ICompraTipoService
    {
        private readonly ICompraTipoRepository _compraTipoRepository;
        private readonly ILogger<CompraTipoService> _logger;
        private Guid _idProveedor;

        public CompraTipoService(ICompraTipoRepository compraTipoRepository, ILogger<CompraTipoService> logger)
        {
            _compraTipoRepository = compraTipoRepository;
            _logger = logger;
        }

        public async Task<List<CompraTipoDetailsModel>> List()
        {
            var listTipos = await _compraTipoRepository.ListAsync().ConfigureAwait(false);

            return listTipos;
        }
    }
}
