using ADM.Store.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Interfaces
{
    internal interface IBookAccountRepository
    {
        public Task<int> AddAsync(Guid idClient);
        public Task<bool> RefreshTotalAsync(int idBookAccount);
        public Task<bool> ExistsBookAccountAsync(Guid idClient, int idBookAccount);
        public Task<ClientDTO> DetailsBookAccountAsync(int idBookAccount);
        public Task<bool> DeleteBookAccountAsync(Guid idClient, int idBookAccount);  
        public Task<ClientDTO> GetBookAccountsByIdClientAsync(Guid idClient);
    }
}
  