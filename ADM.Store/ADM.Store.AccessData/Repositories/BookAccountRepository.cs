using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Repositories
{
    internal class BookAccountRepository : IBookAccountRepository
    {
        private readonly ILogger<BookAccountRepository> _logger;
        private readonly ADMStoreContext _aDMStoreContext;

        public BookAccountRepository(ILogger<BookAccountRepository> logger, ADMStoreContext aDMStoreContext)
        {
            _logger = logger;
            _aDMStoreContext = aDMStoreContext;
        }

        public async Task<int> AddAsync(Guid idClient)
        {
            if (idClient == Guid.Empty)
            {
                _logger.LogError($"idClient cannot be an empty guid", idClient);
            }

            _logger.LogDebug($"idClient received successfully");
            
            var newBookAccount = new BookAccount
            {
                IdClient = idClient,
                NoAccount = 0,
                Total = 0,
                TotalPaid = 0,
                UpdatedAt =DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                // TODO change for userInfo
                CreatedBy = "00000"
            };

            await _aDMStoreContext.BookAccounts.AddAsync(newBookAccount).ConfigureAwait(false);
            await _aDMStoreContext.SaveChangesAsync().ConfigureAwait(false);
            return newBookAccount.Id;
        }

        public Task<bool> DeleteBookAccountAsync(Guid idClient, int idBookAccount)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDTO> DetailsBookAccountAsync(int idBookAccount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsBookAccountAsync(Guid idClient, int idBookAccount)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDTO> GetBookAccountsByIdClientAsync(Guid idClient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefreshTotalAsync(int idBookAccount)
        {
            throw new NotImplementedException();
        }
    }
}
