using ADM.Store.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Interfaces
{
    public interface IBookAccountRepository
    {
        public Task<Guid> CreateClient(string name, string phoneNumber);
        public Task<int> AddAsync(Guid idClient, int typeAccount);
        public Task<bool> RefreshTotalAsync(int idBookAccount);
        public Task<bool> ExistsBookAccountAsync(Guid idClient, int idBookAccount);
        public Task<BookAccountDTO?> DetailsBookAccountAsync(int idBookAccount);
        public Task<bool> DeleteBookAccountAsync(Guid idClient, int idBookAccount);  
        public Task<BookAccountsClientDTO> GetBookAccountsByIdClientAsync(Guid idClient);
        public Task<bool> AddSale(int idBookAccount, DateTime DateSale, string IdItem, decimal Total);
        public Task<bool> DeleteSale(int idBookAccount, int idBookAccountDetails);
        public Task<bool> AddAbono(int idBookAccount, DateTime DateAbono, decimal Total);
        public Task<bool> DeleteAbono(int idBookAccount, int idBookAccountDetails);
    }
}
  