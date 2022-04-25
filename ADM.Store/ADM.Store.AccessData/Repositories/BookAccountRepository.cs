using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        public async Task<Guid> CreateClient(string name, string phoneNumber)
        {
            var newCLient = new Client
            {
                ClientName = name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatedBy = "00000",
                PhoneNumber = phoneNumber,
                Id = Guid.NewGuid(),
            };

            await _aDMStoreContext.Clients.AddAsync(newCLient).ConfigureAwait(false);
            await _aDMStoreContext.SaveChangesAsync().ConfigureAwait(false);
            return newCLient.Id;
        }

        public async Task<bool> AddAbono(int idBookAccount, DateTime DateAbono, decimal Total)
        {
            var newAbono = new BookAccountDetail
            {
                DateProcess = DateAbono,
                CreatedBy = "000000",
                IdBookAccount = idBookAccount,
                IdItem = string.Empty,
                Total = Total,
                TypeDetails = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                
            };

            await _aDMStoreContext.BookAccountDetails.AddAsync(newAbono).ConfigureAwait(false);
            await _aDMStoreContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<int> AddAsync(Guid idClient, int typeAccount)
        {
            if (idClient == Guid.Empty)
            {
                _logger.LogError($"idClient cannot be an empty guid", idClient);
            }

            _logger.LogDebug($"idClient received successfully");

            var newBookAccount = new BookAccount
            {
                IdClient = idClient,
                Total = 0,
                TotalPaid = 0,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                // TODO change for userInfo
                CreatedBy = "00000",
                TypeAccount = typeAccount
            };

            await _aDMStoreContext.BookAccounts.AddAsync(newBookAccount).ConfigureAwait(false);
            await _aDMStoreContext.SaveChangesAsync().ConfigureAwait(false);
            return newBookAccount.Id;
        }

        public async Task<bool> AddSale(int idBookAccount, DateTime DateSale, string IdItem, decimal Total)
        {
            var newAbono = new BookAccountDetail
            {
                DateProcess = DateSale,
                CreatedBy = "000000",
                IdBookAccount = idBookAccount,
                IdItem = IdItem,
                Total = Total,
                TypeDetails = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };

            await _aDMStoreContext.BookAccountDetails.AddAsync(newAbono).ConfigureAwait(false);
            await _aDMStoreContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteAbono(int idBookAccount, int idBookAccountDetails)
        {
            var bookAccountDetails = await _aDMStoreContext.BookAccountDetails.FirstOrDefaultAsync(row => row.IdBookAccount == idBookAccount && row.Id == idBookAccountDetails).ConfigureAwait(false);

            if(bookAccountDetails == null)
            {
                return false;
            }

            _aDMStoreContext.BookAccountDetails.Remove(bookAccountDetails);
            await _aDMStoreContext.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> DeleteBookAccountAsync(Guid idClient, int idBookAccount)
        {
            if (idClient == Guid.Empty)
            {
                _logger.LogError($"idClient cannot be an empty guid", idClient);
                throw new ArgumentException($"idClient cannot be an empty guid", nameof(idClient));
            }
            _logger.LogDebug($"idClient received successfully");
            if (idBookAccount == 0)
            {
                _logger.LogError($"idBookAccount cannot be zero", idBookAccount);
                throw new ArgumentException($"idBookAccount cannot be zero", nameof(idBookAccount));
            }
            _logger.LogDebug($"idBookAccount received successfully");

            var bookAccount = await _aDMStoreContext.BookAccounts.FirstOrDefaultAsync(account => account.Id == idBookAccount && account.IdClient == idClient).ConfigureAwait(false);

            if (bookAccount == null)
            {
                throw new ArgumentException("the book account was not fount");
            }

            _aDMStoreContext.Remove(bookAccount);
            return true;
        }

        public async Task<bool> DeleteSale(int idBookAccount, int idBookAccountDetails)
        {
            var bookAccountDetails = await _aDMStoreContext.BookAccountDetails.FirstOrDefaultAsync(row => row.IdBookAccount == idBookAccount && row.Id == idBookAccountDetails).ConfigureAwait(false);

            if (bookAccountDetails == null)
            {
                return false;
            }

            _aDMStoreContext.BookAccountDetails.Remove(bookAccountDetails);
            await _aDMStoreContext.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<BookAccountDTO?> DetailsBookAccountAsync(int idBookAccount)
        {
            if (idBookAccount == 0)
            {
                _logger.LogError($"idBookAccount cannot be zero", idBookAccount);
                throw new ArgumentException($"idBookAccount cannot be zero", nameof(idBookAccount));
            }
            _logger.LogDebug($"idBookAccount received successfully");

            var bookAccountDetails = (from bookAccount in _aDMStoreContext.BookAccounts
                                      where bookAccount.Id == idBookAccount
                                      select new BookAccountDTO
                                      {
                                          CreatedBy = bookAccount.CreatedBy,
                                          TotalPaid = bookAccount.TotalPaid,
                                          Total = bookAccount.Total,
                                          UpdatedAt = bookAccount.UpdatedAt,
                                      }
            );

            return await bookAccountDetails.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> ExistsBookAccountAsync(Guid idClient, int idBookAccount)
        {
            if (idClient == Guid.Empty)
            {
                _logger.LogError($"idClient cannot be an empty guid", idClient);
                throw new ArgumentException($"idClient cannot be an empty guid", nameof(idClient));
            }
            _logger.LogDebug($"idClient received successfully");
            if (idBookAccount == 0)
            {
                _logger.LogError($"idBookAccount cannot be zero", idBookAccount);
                throw new ArgumentException($"idBookAccount cannot be zero", nameof(idBookAccount));
            }
            _logger.LogDebug($"idBookAccount received successfully");
            return await _aDMStoreContext.BookAccounts.AnyAsync(account => account.Id == idBookAccount && account.IdClient == idClient).ConfigureAwait(false);
        }

        public async Task<BookAccountsClientDTO> GetBookAccountsByIdClientAsync(Guid idClient)
        {
            if (idClient == Guid.Empty)
            {
                _logger.LogError($"idClient cannot be an empty guid", idClient);
                throw new ArgumentException($"idClient cannot be an empty guid", nameof(idClient));
            }
            _logger.LogDebug($"idClient received successfully");

            var clientInfo = from client in _aDMStoreContext.Clients
                             where client.Id == idClient
                             select new ClientDTO
                             {
                                 IdClient = client.Id,
                                 ClientName = client.ClientName,
                                 PhoneNumber = client.PhoneNumber,
                                 UpdatedAt = client.UpdatedAt,
                             };

            var bookAccountsList = (from bookAccount in _aDMStoreContext.BookAccounts
                                    where bookAccount.IdClient == idClient
                                    select new BookAccountDTO
                                    {
                                        CreatedBy = bookAccount.CreatedBy,
                                        TotalPaid = bookAccount.TotalPaid,
                                        Total = bookAccount.Total,
                                        UpdatedAt = bookAccount.UpdatedAt,
                                        PendingPaid = bookAccount.Total - bookAccount.TotalPaid
                                    }
            );

            return new BookAccountsClientDTO
            {
                Cuentas = await bookAccountsList.ToListAsync().ConfigureAwait(false),
                Client = await clientInfo.FirstOrDefaultAsync().ConfigureAwait(false),
            };
        }

        public async Task<bool> RefreshTotalAsync(int idBookAccount)
        {
            if (idBookAccount == 0)
            {
                _logger.LogError($"idBookAccount cannot be zero", idBookAccount);
                throw new ArgumentException($"idBookAccount cannot be zero", nameof(idBookAccount));
            }
            _logger.LogDebug($"idBookAccount received successfully");

            var bookAccount = await _aDMStoreContext.BookAccounts.FirstOrDefaultAsync(account => account.Id == idBookAccount).ConfigureAwait(false);

            if(bookAccount == null)
            {
                return false;
            }
            
            if(bookAccount.TypeAccount == 1)
            {
                // sistema de apartado
                bookAccount.Total = await _aDMStoreContext.BookAccountDetails.Where(row => row.IdBookAccount == idBookAccount && row.TypeDetails == 1).Select(row => row.Total).SumAsync().ConfigureAwait(false);
                bookAccount.TotalPaid = await _aDMStoreContext.BookAccountDetails.Where(row => row.IdBookAccount == idBookAccount && row.TypeDetails == 2).Select(row => row.Total).SumAsync().ConfigureAwait(false);
            }
            else if (bookAccount.TypeAccount == 2)
            {
                // ventas directas
                bookAccount.Total = await _aDMStoreContext.BookAccountDetails.Where(row => row.IdBookAccount == idBookAccount && row.TypeDetails == 1).Select(row => row.Total).SumAsync().ConfigureAwait(false);
                bookAccount.TotalPaid = bookAccount.Total;
            }
            else if(bookAccount.TypeAccount == 3)
            {
                // ventas en abonos
                bookAccount.Total = await _aDMStoreContext.BookAccountDetails.Where(row => row.IdBookAccount == idBookAccount && row.TypeDetails == 1).Select(row => row.Total).SumAsync().ConfigureAwait(false);
                bookAccount.TotalPaid = await _aDMStoreContext.BookAccountDetails.Where(row => row.IdBookAccount == idBookAccount && row.TypeDetails == 2).Select(row => row.Total).SumAsync().ConfigureAwait(false);
            }
            return false;

        }
    }
}
