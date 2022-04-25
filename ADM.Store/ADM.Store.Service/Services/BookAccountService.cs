using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.DTO;
using ADM.Store.Models.Models;
using ADM.Store.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Service.Services
{
    public class BookAccountService : IBookAccountService
    {
        private readonly ILogger<BookAccountService> _logger;
        private readonly IBookAccountRepository _bookAccountRepository;

        public BookAccountService(ILogger<BookAccountService> logger, IBookAccountRepository bookAccountRepository)
        {
            _logger = logger;
            _bookAccountRepository = bookAccountRepository;
        }

        public async Task<bool> AddAbono(AbonoCreateModel newAbono)
        {
            var result = await _bookAccountRepository.AddAbono(newAbono.idBookAccount, newAbono.DateAbono, newAbono.Total).ConfigureAwait(false);
            await _bookAccountRepository.RefreshTotalAsync(newAbono.idBookAccount).ConfigureAwait(false);
            return result;
        }

        public async Task<bool> AddSale(SaleCreateModel newSale)
        {
            var result = await _bookAccountRepository.AddSale(newSale.idBookAccount, newSale.DateSale, newSale.IdItem, newSale.Total).ConfigureAwait(false);
            await _bookAccountRepository.RefreshTotalAsync(newSale.idBookAccount).ConfigureAwait(false);
            return result;
        }

        public async Task<int> CreateBookAccount(BookAccountCreateModel newBookAccount)
        {
            var idBookAccountCreated = await _bookAccountRepository.AddAsync(newBookAccount.idClient, newBookAccount.typeAccount).ConfigureAwait(false);
            return idBookAccountCreated;
        }

        public async Task<Guid> CreateClient(ClientCreateModel client)
        {
            var result = await _bookAccountRepository.CreateClient(client.Name, client.PhoneNumber).ConfigureAwait(false);

            return result;
        }

        public async Task<bool> DeleteAbono(int idBookAccount, int idBookAccountDetails)
        {
            var result = await _bookAccountRepository.DeleteAbono(idBookAccount, idBookAccountDetails).ConfigureAwait(false);
            await _bookAccountRepository.RefreshTotalAsync(idBookAccount).ConfigureAwait(false);
            return result;
        }

        public async Task<bool> DeleteBookAccountByIdClient(Guid idClient, int idBookAccount)
        {
            var result = await _bookAccountRepository.DeleteBookAccountAsync(idClient, idBookAccount).ConfigureAwait(false);

            return result;
        }

        public async Task<bool> DeleteSale(int idBookAccount, int idBookAccountDetails)
        {
            var result = await _bookAccountRepository.DeleteSale(idBookAccount,idBookAccountDetails).ConfigureAwait(false);
            await _bookAccountRepository.RefreshTotalAsync(idBookAccount).ConfigureAwait(false);
            return result;
        }

        public async Task<BookAccountDTO> GetBookAccountDetails(Guid idClient, int idBookAccount)
        {
            var result = await _bookAccountRepository.DetailsBookAccountAsync(idBookAccount).ConfigureAwait(false);

            return result;
        }

        public async Task<BookAccountsClientDTO> GetBookAccountsClient(Guid idClient)
        {
            var result = await _bookAccountRepository.GetBookAccountsByIdClientAsync(idClient).ConfigureAwait(false);

            return result;
        }
    }
}
