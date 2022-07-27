using ADM.Store.AccessData.Repositories;
using ADM.Store.Models.Models.ItemCategory;
using ADM.Store.Models.Models.ItemType;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Service.Services
{
    internal class ItemCategoryService : IItemCategoryService
    {
        private readonly ItemCategoryRepository _categoryRepository;
        private readonly ItemTypeRepository _itemTypeRepository;
        private readonly ILogger<ItemCategoryService> _logger;

        private ItemTypeDetailsModel _itemType = null!;
        public ItemCategoryService(ItemCategoryRepository categoryRepository, ItemTypeRepository itemTypeRepository, ILogger<ItemCategoryService> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _itemTypeRepository = itemTypeRepository ?? throw new ArgumentNullException(nameof(itemTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCategoryCreate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        public async Task<ItemCategoryDetailsModel> CreateAsync(ItemCategoryCreateModel itemCategoryCreate)
        {
            if(itemCategoryCreate == null)
            {
                throw new ArgumentNullException(nameof(ItemCategoryCreateModel));
            }

            await SetItemType(itemCategoryCreate.ItemType).ConfigureAwait(false);
            int idExistsCategory = await _categoryRepository.ExistsInItemTypeAsync(itemCategoryCreate.CategoryName.Trim(), itemCategoryCreate.ItemType).ConfigureAwait(false);

            if (idExistsCategory != 0)
            {
                throw new ExceptionService(StatusCodeService.Status409Conflict, $"There is already exists a category with the name '{itemCategoryCreate.CategoryName.Trim()}'");
            }

            int idCategoryCreated = await _categoryRepository.CreateAsync(itemCategoryCreate.ItemType, itemCategoryCreate.CategoryName.Trim()).ConfigureAwait(false);

            #pragma warning disable CS8603 // Possible null reference return.
            return await _categoryRepository.DetailsAsync(itemCategoryCreate.ItemType, idCategoryCreated).ConfigureAwait(false);
            #pragma warning restore CS8603 // Possible null reference return.
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idItemType"></param>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteAsync(int idItemType, int idCategory)
        {
            if (idItemType == 0)
            {
                throw new ArgumentNullException(nameof(idItemType));
            }
            if (idCategory == 0)
            {
                throw new ArgumentNullException(nameof(idCategory));
            }

            int idExistsCategory = await _categoryRepository.ExistsInItemTypeAsync(idCategory, idItemType).ConfigureAwait(false);

            if (idExistsCategory == 0)
            {
                throw new ExceptionService(StatusCodeService.Status409Conflict, $"Category not found");
            }

            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idItemType"></param>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<ItemCategoryDetailsModel> DetailsAsync(int idItemType, int idCategory)
        {
            var categoryDetails = await _categoryRepository.DetailsAsync(idItemType, idCategory).ConfigureAwait(false);

            if(categoryDetails == null)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, "Category not found");
            }

            return categoryDetails;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idItemType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<ItemCategoryDetailsModel>> ListByTypeItemAsync(int idItemType)
        {
            if (idItemType == 0)
            {
                throw new ArgumentNullException(nameof(idItemType));
            }

            await SetItemType(idItemType).ConfigureAwait(false);

            return await _categoryRepository.ListAsync(idItemType).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCategoryUpdate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        public async Task<bool> UpdateAsync(ItemCategoryUpdateModel itemCategoryUpdate)
        {
            if (itemCategoryUpdate == null)
            {
                throw new ArgumentNullException(nameof(itemCategoryUpdate));
            }

            var category = await _categoryRepository.DetailsAsync(itemCategoryUpdate.Id, itemCategoryUpdate.IdItemType).ConfigureAwait(false);

            if (category == null)
            {
                throw new ExceptionService(StatusCodeService.Status409Conflict, $"Category not found");
            }

            return await _categoryRepository.UpdateAsync(itemCategoryUpdate.Id, itemCategoryUpdate.CategoryName.Trim()).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idItemType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ExceptionService"></exception>
        private async Task SetItemType(int idItemType)
        {
            if(idItemType == 0)
            {
                throw new ArgumentException($"please select a valid item type", nameof(ItemCategoryCreateModel));
            }

            _itemType = await _itemTypeRepository.Details(idItemType).ConfigureAwait(false);

            if(_itemType == null)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, "the item type selected was not found");
            }
        }
    }
}
