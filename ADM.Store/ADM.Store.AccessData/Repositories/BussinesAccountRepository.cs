using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.BussinesAccount;

using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class BussinesAccountRepository : IBussinesAccountRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public BussinesAccountRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task AddHistoryLine(int idBussinesAccount, decimal total, BussinesAccountHistoryType historyType, BussinesAccountDocRefType docRefType, int docRefNum, string comments)
        {
            var newHistoryLine = new BussinesAccountHistory
            {
                BussinesAccount = idBussinesAccount,
                Comments = comments,
                DocRefNum = docRefNum,
                DocRefType = MapBussinesAccountDocRefType(docRefType),
                Total = total,
                HistoryType = MapBussinesAccountHistoryType(historyType),
                // TODO service-user
                CreatedBy = "USER-SYS",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _aDMStore.BussinesAccountHistories.AddAsync(newHistoryLine).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }
        
        private string MapBussinesAccountHistoryType(BussinesAccountHistoryType historyType)
        {
            switch (historyType)
            {
                case BussinesAccountHistoryType.entrada:
                    return "I";
                case BussinesAccountHistoryType.salida:
                    return "O";
                default:
                    return "";
            }
        }
        
        private string MapBussinesAccountDocRefType(BussinesAccountDocRefType docRefType)
        {
            switch (docRefType)
            {
                case BussinesAccountDocRefType.incommingPayment:
                    return "I";
                case BussinesAccountDocRefType.outCommingPayment:
                    return "O";
                default:
                    return "";
            }
        }

        public async Task<int> CreateAsync(string name, string comments)
        {
            var newBussinesAccount = new BussinesAccount
            {
                AccountName = name,
                Comments = comments,
                Balance = 0,
                // TODO service-user
                CreatedBy = "USER-SYS",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _aDMStore.BussinesAccounts.AddAsync(newBussinesAccount).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newBussinesAccount.Id;
        }

        public async Task<List<BussinesAccountDetailsModel>> ListAsync()
        {
            var qr_bussinesAccount = from account in _aDMStore.BussinesAccounts
                                     select new BussinesAccountDetailsModel
                                     {
                                         Id = account.Id,
                                         AccountName = account.AccountName,
                                         Balance = account.Balance,
                                         Comments = account.Comments,
                                         CreatedBy = account.CreatedBy,
                                         CreatedAt = account.CreatedAt,
                                         UpdatedAt = account.UpdatedAt,
                                     };

            return await qr_bussinesAccount.ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateAsync(int idBussinesAccount, string name, string comments)
        {
            var bussinesAccountRegistered = await _aDMStore.BussinesAccounts.FirstOrDefaultAsync(account => account.Id == idBussinesAccount).ConfigureAwait(false);

            if(bussinesAccountRegistered == null)
            {
                throw new NullReferenceException(nameof(bussinesAccountRegistered));
            }

            bussinesAccountRegistered.AccountName = name;
            bussinesAccountRegistered.Comments = comments;
            bussinesAccountRegistered.UpdatedAt = DateTime.Now;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return bussinesAccountRegistered.Id;
        }

        public async Task<List<BussinesAccountHistoryDetailsModel>> GetHistory(int idBussinesAccoun)
        {
            var qr_history = from history in _aDMStore.BussinesAccountHistories
                             where history.BussinesAccount == idBussinesAccoun
                             select new BussinesAccountHistoryDetailsModel
                             {
                                 Id = history.Id,
                                 BussinesAccount = history.BussinesAccount,
                                 Total = history.Total,
                                 HistoryType = history.HistoryType,
                                 DocRefType = history.DocRefType,
                                 DocRefNum = history.DocRefNum,
                                 Comments = history.Comments,
                                 CreatedBy = history.CreatedBy,
                                 CreatedAt = history.CreatedAt,
                                 UpdatedAt = history.UpdatedAt,
                             };

            return await qr_history.ToListAsync().ConfigureAwait(false);
        }
    }
}
