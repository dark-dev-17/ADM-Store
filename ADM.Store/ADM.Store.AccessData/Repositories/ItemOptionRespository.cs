using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.ItemOption;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Repositories
{
    internal class ItemOptionRespository : IItemOptionRespository
    {
        private readonly ADMStoreContext _aDMStore;

        public ItemOptionRespository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<bool> CreateAsync(ItemOptionCreateModel itemOption)
        {
            var newOption = new ItemOption
            {
                ItemCode = itemOption.ItemCode,
                Variation = itemOption.Variation,
                ItemTile = itemOption.ItemTile,
                ItemDescription = itemOption.ItemDescription,
                UnitPrice = itemOption.UnitPrice,
                Stock = itemOption.Stock,
                Size = itemOption.Size,
                ColorName = itemOption.ColorName,
                ColorCode = itemOption.ColorCode,
                // TODO service-user
                CreatedBy = "USER-SYS",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await _aDMStore.ItemOptions.AddAsync(newOption).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> DeleteAsync(string itemCode, string variation)
        {
            var optionToDelete = await _aDMStore.ItemOptions.FirstOrDefaultAsync(option => option.ItemCode == itemCode && option.Variation == variation).ConfigureAwait(false);

            if (optionToDelete == null)
            {
                return false;
            }

            _aDMStore.ItemOptions.Remove(optionToDelete);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<ItemOptionDetailsModel?> DetailsAsync(string itemCode, string variation)
        {
            #region query
            var listVariations = from options in _aDMStore.ItemOptions
                                 where options.ItemCode == itemCode && options.Variation == variation
                                 select new ItemOptionDetailsModel
                                 {
                                     ItemCode = options.ItemCode,
                                     Variation = options.Variation,
                                     ItemTile = options.ItemTile,
                                     ItemDescription = options.ItemDescription,
                                     UnitPrice = options.UnitPrice,
                                     Stock = options.Stock,
                                     Size = options.Size,
                                     ColorName = options.ColorName,
                                     ColorCode = options.ColorCode,
                                     UpdatedAt = options.UpdatedAt,
                                 };
            #endregion

            return await listVariations.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(string itemCode, string variation)
        {
            return await _aDMStore.ItemOptions.AnyAsync(option => option.ItemCode == itemCode && option.Variation == variation).ConfigureAwait(false);
        }

        public async Task<List<ItemOptionDetailsModel>> ListAsync(string itemCode)
        {
            #region query
            var listVariations = from options in _aDMStore.ItemOptions
                                 where options.ItemCode == itemCode
                                 select new ItemOptionDetailsModel
                                 {
                                     ItemCode = options.ItemCode,
                                     Variation = options.Variation,
                                     ItemTile = options.ItemTile,
                                     ItemDescription = options.ItemDescription,
                                     UnitPrice = options.UnitPrice,
                                     Stock = options.Stock,
                                     Size = options.Size,
                                     ColorName = options.ColorName,
                                     ColorCode = options.ColorCode,
                                     UpdatedAt = options.UpdatedAt,
                                 };
            #endregion

            return await listVariations.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(ItemOptionUpdateModel itemOption)
        {
            var optionToUpdate = await _aDMStore.ItemOptions.FirstOrDefaultAsync(option => option.ItemCode == itemOption.ItemCode && option.Variation == itemOption.Variation).ConfigureAwait(false);

            if(optionToUpdate == null)
            {
                return false;
            }

            optionToUpdate.Variation = itemOption.Variation;
            optionToUpdate.ItemTile = itemOption.ItemTile;
            optionToUpdate.ItemDescription = itemOption.ItemDescription;
            optionToUpdate.UnitPrice = itemOption.UnitPrice;
            optionToUpdate.Stock = itemOption.Stock;
            optionToUpdate.Size = itemOption.Size;
            optionToUpdate.ColorName = itemOption.ColorName;
            optionToUpdate.ColorCode = itemOption.ColorCode;
            optionToUpdate.UpdatedAt = DateTime.Now;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
