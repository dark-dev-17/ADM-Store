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
        public Task<int> Add(Guid idClient);
        public Task<bool> RefreshTotal(int idBookAccount);
        public Task<bool> ExistsBookAccount(Guid idClient, int idBookAccount);
        public Task<ClientDTO> DetailsBookAccount(int idBookAccount);
        public Task<bool> Delete();
        public Task<ClientDTO> GetBookAccountsByIdClient(Guid idClient);
    }
}
  