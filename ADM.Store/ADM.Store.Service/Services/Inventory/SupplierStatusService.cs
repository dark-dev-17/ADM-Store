using System.Runtime.CompilerServices;
using ADM.Store.Service.Interfaces.Inventory;
using ADM.Store.Models.Models.SupplierStatus;
using Microsoft.Extensions.Logging;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Service.Exceptions;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services.Inventory
{
    //throw new ExceptionService(StatusCodeService.Status404NotFound, "");
    internal class SupplierStatusService : ISupplierStatusService
    {
        private readonly ISupplierStatusRepository _statusRepository;
        private readonly ILogger<SupplierStatusService> _logger;

        public SupplierStatusService(ISupplierStatusRepository statusRepository, ILogger<SupplierStatusService> logger)
        {
            _statusRepository = statusRepository ?? throw new ArgumentNullException(nameof(statusRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusName"></param>
        /// <returns></returns>
        public async Task<int> CreateAsync(string statusName)
        {
            var status = await _statusRepository.ExistsAsync(statusName).ConfigureAwait(false);

            if (status == 0)
            {
                status = await _statusRepository.CreateAsync(statusName).ConfigureAwait(false);
            }

            return status;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<SupplierStatusDetailsModel> DetailsAsync(int statusId)
        {
            var status =  await _statusRepository.DetailsAsync(statusId).ConfigureAwait(false);

            if (status == null)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, "the status selected was not found");
            }

            return status;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<SupplierStatusDetailsModel>> ListAsync()
        {
            var statusList = await _statusRepository.ListAsync().ConfigureAwait(false);

            return statusList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusId"></param>
        /// <param name="statusName"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task UpdateAsync(int statusId, string statusName)
        {
            var status = await _statusRepository.ExistsAsync(statusId).ConfigureAwait(false);

            if (status == 0)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, "the status selected was not found");
            }

            await _statusRepository.UpdateAsync(statusId, statusName).ConfigureAwait(false);
        }
    }
}
