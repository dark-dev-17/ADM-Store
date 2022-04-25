using ADM.Store.Models.DTO;
using ADM.Store.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Service.Interfaces
{
    public interface IBookAccountService
    {
        public Task<Guid> CreateClient(ClientCreateModel client);
        public Task<int> CreateBookAccount(BookAccountCreateModel newBookAccount);
        public Task<BookAccountsClientDTO> GetBookAccountsClient(Guid idClient);
        public Task<BookAccountDTO> GetBookAccountDetails(Guid idClient, int idBookAccount);
        public Task<bool> DeleteBookAccountByIdClient(Guid idClient, int idBookAccount);
        public Task<bool> AddSale(SaleCreateModel newSale);
        public Task<bool> DeleteSale(int idBookAccount, int idBookAccountDetails);
        public Task<bool> AddAbono(AbonoCreateModel newAbono);
        public Task<bool> DeleteAbono(int idBookAccount, int idBookAccountDetails);
    }
}
