using ADM.Store.AccessData.Interfaces;
using ADM.Store.AccessData.Repositories;
using ADM.Store.Models.Models.ItemCategory;
using ADM.Store.Models.Models.ItemSubCategory;
using ADM.Store.Models.Models.ItemType;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services
{
    internal class ItemCategoryService : IItemCategoryService
    {
        private readonly IItemSubCategoryRepository _subCategoryRepository;
        private readonly IItemCategoryRepository _categoryRepository;
        private readonly IItemTypeRepository _itemTypeRepository;
        private readonly ILogger<ItemCategoryService> _logger;

        private ItemTypeDetailsModel _itemType = null!;
        public ItemCategoryService(IItemCategoryRepository categoryRepository, IItemSubCategoryRepository subCategoryRepository, IItemTypeRepository itemTypeRepository, ILogger<ItemCategoryService> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _itemTypeRepository = itemTypeRepository ?? throw new ArgumentNullException(nameof(itemTypeRepository));
            _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idItemType"></param>
        /// <param name="itemSubCategoryCreate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        public async Task<int> AddSubCategoryAsync(int idItemType, ItemSubCategoryCreateModel itemSubCategoryCreate)
        {
            await SetItemType(idItemType).ConfigureAwait(false);


            if (itemSubCategoryCreate == null)
            {
                throw new ArgumentNullException(nameof(itemSubCategoryCreate));
            }
            int idSubcategoryFounded = await _subCategoryRepository.ExistsInCategoryeAsync((int)itemSubCategoryCreate.CategoryParent, itemSubCategoryCreate.CategoryName.Trim()).ConfigureAwait(false);

            if(idSubcategoryFounded != 0)
            {
                throw new ExceptionService(StatusCodeService.Status409Conflict, $"There is already exists a sub-category with the name '{itemSubCategoryCreate.CategoryName.Trim()}'");
            }

            return await _subCategoryRepository.CreateAsync(idItemType, (int)itemSubCategoryCreate.CategoryParent, itemSubCategoryCreate.CategoryName.Trim()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCategoryCreate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        public async Task<int> CreateAsync(int idItemType, ItemCategoryCreateModel itemCategoryCreate)
        {
            if(itemCategoryCreate == null)
            {
                throw new ArgumentNullException(nameof(itemCategoryCreate));
            }

            await SetItemType(itemCategoryCreate.ItemType).ConfigureAwait(false);
            int idExistsCategory = await _categoryRepository.ExistsInItemTypeAsync(itemCategoryCreate.CategoryName.Trim(), itemCategoryCreate.ItemType).ConfigureAwait(false);

            if (idExistsCategory != 0)
            {
                throw new ExceptionService(StatusCodeService.Status409Conflict, $"There is already exists a category with the name '{itemCategoryCreate.CategoryName.Trim()}'");
            }

            return await _categoryRepository.CreateAsync(itemCategoryCreate.ItemType, itemCategoryCreate.CategoryName.Trim()).ConfigureAwait(false);

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
        /// <param name="idCategory"></param>
        /// <param name="idSubCategory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        public async Task<ItemSubCategoryDetailsModel> DetailsSubCategoryAsync(int idItemType, int idCategory, int idSubCategory)
        {
            if (idItemType == 0)
            {
                throw new ArgumentNullException(nameof(idItemType));
            }
            if (idCategory == 0)
            {
                throw new ArgumentNullException(nameof(idCategory));
            }
            if (idSubCategory == 0)
            {
                throw new ArgumentNullException(nameof(idSubCategory));
            }

            var subcategory = await _subCategoryRepository.DetailsAsync(idCategory, idSubCategory).ConfigureAwait(false);

            if (subcategory == null)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, "Sub-Category not found");
            }

            return subcategory;
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
        /// <param name="idItemType"></param>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<ItemSubCategoryDetailsModel>> ListSubCategoryAsync(int idItemType, int idCategory)
        {
            if (idItemType == 0)
            {
                throw new ArgumentNullException(nameof(idItemType));
            }
            if (idCategory == 0)
            {
                throw new ArgumentNullException(nameof(idCategory));
            }

            await SetItemType(idItemType).ConfigureAwait(false);

            return await _subCategoryRepository.ListAsync(idCategory).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCategoryUpdate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        public async Task<bool> UpdateAsync(int idItemType, int idItemCategory, ItemCategoryUpdateModel itemCategoryUpdate)
        {
            if (itemCategoryUpdate == null)
            {
                throw new ArgumentNullException(nameof(itemCategoryUpdate));
            }

            if(itemCategoryUpdate.Id != idItemCategory)
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, $"Data wrong");
            }
            if (itemCategoryUpdate.IdItemType != idItemType)
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, $"Data wrong");
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
        /// <param name="itemSubCategoryUpdate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateSubCategoryAsync(int idItemType, ItemSubCategoryUpdateModel itemSubCategoryUpdate)
        {
            if (idItemType == 0)
            {
                throw new ArgumentNullException(nameof(idItemType));
            }

            await SetItemType(idItemType).ConfigureAwait(false);

            int idSubcategoryFound = await _subCategoryRepository.ExistsInCategoryeAsync((int)itemSubCategoryUpdate.Id, itemSubCategoryUpdate.CategoryParent).ConfigureAwait(false);

            if (idSubcategoryFound == 0)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, "Sub-Category not found");
            }

            return true;
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
