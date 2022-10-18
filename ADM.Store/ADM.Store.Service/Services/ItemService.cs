using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Item;
using ADM.Store.Models.Models.ItemCategory;
using ADM.Store.Models.Models.ItemMaterial;
using ADM.Store.Models.Models.ItemOption;
using ADM.Store.Models.Models.ItemSubCategory;
using ADM.Store.Models.Models.ItemType;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services
{
    internal class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemStatusRepository _statusRepository;
        private readonly IItemCategoryRepository _categoryRepository;
        private readonly IItemSubCategoryRepository _subCategoryRepository;
        private readonly IItemTypeRepository _typeItemRepository = null!;
        private readonly IItemMaterialRepository _materialRepository;
        private readonly IItemOptionRespository _optionRepository;

        private readonly ILogger<ItemService> _logger;

        private ItemTypeDetailsModel typeItem = null!;
        private ItemCategoryDetailsModel category = null!;
        private ItemSubCategoryDetailsModel subCategory = null!;
        private ItemMaterialDetailsModel material = null!;
        private ItemDetailsModel _item = null!;
        private readonly string _itemStatusInitial = "Borrador";

        public ItemService(IItemRepository itemRepository, IItemStatusRepository statusRepository, IItemCategoryRepository categoryRepository, IItemSubCategoryRepository subCategoryRepository, IItemTypeRepository typeItemRepository, IItemMaterialRepository materialRepository, IItemOptionRespository optionRepository, ILogger<ItemService> logger)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _statusRepository = statusRepository ?? throw new ArgumentNullException(nameof(statusRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
            _typeItemRepository = typeItemRepository ?? throw new ArgumentNullException(nameof(typeItemRepository));
            //_themeRepository = themeRepository ?? throw new ArgumentNullException(nameof(themeRepository));
            _materialRepository = materialRepository ?? throw new ArgumentNullException(nameof(materialRepository));
            _optionRepository = optionRepository ?? throw new ArgumentNullException(nameof(optionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCreate"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<ItemDetailsModel> CreateAsync(ItemCreateModel itemCreate)
        {
            await SetItemTypeAsync(itemCreate.ItemType).ConfigureAwait(false);
            await SetCategoryAsync(itemCreate.Category).ConfigureAwait(false);

            if (itemCreate.SubCategory != null)
            {
                await SetSubCategoryAsync((int)itemCreate.SubCategory).ConfigureAwait(false);
            }

            await SetMaterial(itemCreate.Material).ConfigureAwait(false);

            if (await _itemRepository.ExistsAsync(itemCreate.ItemCode.Trim()).ConfigureAwait(false))
            {
                throw new ExceptionService(409, "Warning", $"There is already an article with the code: {itemCreate.ItemCode.Trim()}");
            }

            var idStatusItemInitial = await _statusRepository.GetByName(_itemStatusInitial).ConfigureAwait(false);

            if (idStatusItemInitial == 0)
            {
                throw new ExceptionService(404, "Warning", $"The item status was not found");
            }

            await _itemRepository.CreateAsync(itemCreate, idStatusItemInitial).ConfigureAwait(false);

            _item = await _itemRepository.DetailsAsync(itemCreate.ItemCode.Trim()).ConfigureAwait(false);

            if (_item == null)
            {
                throw new ExceptionService(-201, "Warning", $"The item was not created");
            }

            return _item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ItemDetailsModel>> ListAsync()
        {
            return await _itemRepository.ListAsync().ConfigureAwait(false);
        }

        #region private methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMaterial"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        private async Task SetMaterial(int idMaterial)
        {
            if (idMaterial == 0)
            {
                _logger.LogError($"Zero value is not valid for idMaterial", idMaterial);
                throw new ArgumentNullException(nameof(idMaterial));
            }

            _logger.LogInformation($"idMaterial receive successfully");
            material = await _materialRepository.DetailsAsync(idMaterial, typeItem.Id).ConfigureAwait(false);

            if (material == null)
            {
                _logger.LogError($"ItemMaterial was not found", subCategory);
                throw new ExceptionService(404, "Warning", $"The material selected was not found in item type selected: {typeItem.TypeName}");
            }
            _logger.LogInformation($"ItemMaterial was found successfully", subCategory);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSubCategory"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        private async Task SetSubCategoryAsync(int idSubCategory)
        {
            if (idSubCategory == 0)
            {
                _logger.LogError($"Zero value is not valid for idSubCategory", idSubCategory);
                throw new ArgumentNullException(nameof(idSubCategory));
            }

            _logger.LogInformation($"idSubCategory receive successfully");
            subCategory = await _subCategoryRepository.DetailsAsync(category.Id, idSubCategory).ConfigureAwait(false);

            if (subCategory == null)
            {
                _logger.LogError($"ItemSubCategory was not found", subCategory);
                throw new ExceptionService(404, "Warning", $"The sub-category selected was not found in the category: {category.CategoryName}");
            }
            _logger.LogInformation($"ItemSubCategory was found successfully", subCategory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCategory"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExceptionService"></exception>
        private async Task SetCategoryAsync(int idCategory)
        {
            if (idCategory == 0)
            {
                _logger.LogError($"Zero value is not valid for idCategory", idCategory);
                throw new ArgumentOutOfRangeException(nameof(idCategory));
            }

            _logger.LogInformation($"idCategory receive successfully");
            category = await _categoryRepository.DetailsAsync(idCategory, typeItem.Id).ConfigureAwait(false);

            if (category == null)
            {
                _logger.LogError($"ItemCategory was not found", category);
                throw new ExceptionService(404, "Warning", $"The category selected was not found in the item type: {typeItem.TypeName}");
            }

            _logger.LogInformation($"ItemCategory was found successfully", category);
        }

        /// <summary>
        /// set item type in witch the new item will be added
        /// </summary>
        /// <param name="idItemType"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        private async Task SetItemTypeAsync(int idItemType)
        {
            if (idItemType == 0)
            {
                _logger.LogError($"Zero value is not valid for idItemType", idItemType);
                throw new ArgumentOutOfRangeException(nameof(idItemType));
            }

            _logger.LogInformation($"idItemType receive successfully");
            typeItem = await _typeItemRepository.Details(idItemType).ConfigureAwait(false);

            if (typeItem == null)
            {
                _logger.LogError($"ItemType was not found", typeItem);
                throw new ExceptionService(404, "Warning", "The item type selected was not found");
            }
            _logger.LogInformation($"ItemType was found successfully", typeItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemUpdate"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<bool> UpdateAsync(string itemCode, ItemUpdateModel itemUpdate)
        {
            _item = await _itemRepository.DetailsAsync(itemCode.Trim()).ConfigureAwait(false);
            if (_item == null)
            {
                _logger.LogError($"Item[{itemCode.Trim()}] was not found", _item);
                throw new ExceptionService(404, "Warning", $"Item[{itemCode.Trim()}] was not found");
            }
            _logger.LogInformation($"Item[{itemCode.Trim()}] was found successfully", _item);

            if(itemUpdate.ItemType != _item.ItemType.Id)
            {
                await SetItemTypeAsync(itemUpdate.ItemType).ConfigureAwait(false);
                if(itemUpdate.Category != _item.Category.Id)
                {
                    await SetCategoryAsync(itemUpdate.Category).ConfigureAwait(false);
                    await SetSubCategoryAsync(itemUpdate.SubCategory).ConfigureAwait(false);
                }
            }
            else
            {
                if (itemUpdate.Category != _item.Category.Id)
                {
                    await SetCategoryAsync(itemUpdate.Category).ConfigureAwait(false);
                    await SetSubCategoryAsync(itemUpdate.SubCategory).ConfigureAwait(false);
                }
            }

            if (itemUpdate.ItemStatus != _item.ItemStatus.Id)
            {
                if(await _statusRepository.Details(itemUpdate.ItemStatus) == null)
                {
                    throw new ExceptionService(404, "Warning", $"ItemStatus selected was not found");
                }
            }

            return await _itemRepository.UpdateAsync(itemUpdate).ConfigureAwait(false); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<bool> DeleteAsync(string itemCode)
        {
            if (!await _itemRepository.ExistsAsync(itemCode.Trim()).ConfigureAwait(false))
            {
                _logger.LogError($"Item[{itemCode.Trim()}] was not found", _item);
                throw new ExceptionService(404, "Warning", $"Item[{itemCode.Trim()}] was not found");
            }

            return await _itemRepository.DeleteAsync(itemCode.Trim()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<ItemDetailsModel> DetailsAsync(string itemCode)
        {
            _item = await _itemRepository.DetailsAsync(itemCode.Trim()).ConfigureAwait(false);
            if (_item == null)
            {
                _logger.LogError($"Item[{itemCode.Trim()}] was not found", _item);
                throw new ExceptionService(404, "Warning", $"Item[{itemCode.Trim()}] was not found");
            }
            _logger.LogInformation($"Item[{itemCode.Trim()}] was found successfully", _item);

            return _item;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="optionCreate"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<bool> AddOptionAsync(string itemCode, ItemOptionCreateModel optionCreate)
        {
            var idStatus = await _statusRepository.GetByName(_itemStatusInitial).ConfigureAwait(false);

            if (await _optionRepository.ExistsAsync(itemCode.Trim(), optionCreate.Variation.Trim()).ConfigureAwait(false))
            {
                throw new ExceptionService(409, "Warning", $"There is exists a variation code in the item {itemCode.Trim()}");
            }

            return await _optionRepository.CreateAsync(optionCreate, idStatus).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="variation"></param>
        /// <param name="itemUpdate"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<bool> UpdateOptionAsync(string itemCode, string variation, ItemOptionUpdateModel itemUpdate)
        {
            if (!await _optionRepository.ExistsAsync(itemCode.Trim(), variation.Trim()).ConfigureAwait(false))
            {
                throw new ExceptionService(404, "Warning", $"The option selected was not found in the item: [{itemCode.Trim()}]");
            }


            return await _optionRepository.UpdateAsync(itemUpdate).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="variation"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<bool> DeleteOptionAsync(string itemCode, string variation)
        {
            if (!await _optionRepository.ExistsAsync(itemCode.Trim(), variation.Trim()).ConfigureAwait(false))
            {
                throw new ExceptionService(404, "Warning", $"The option selected was not found in the item: [{itemCode.Trim()}]");
            }

            await _optionRepository.DeleteAsync(itemCode.Trim(), variation.Trim()).ConfigureAwait(false);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="variation"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<ItemOptionDetailsModel> DetailsOptionAsync(string itemCode, string variation)
        {
            var optionFounded = await _optionRepository.DetailsAsync(itemCode.Trim(), variation.Trim()).ConfigureAwait(false);

            if (optionFounded == null)
            {
                throw new ExceptionService(404, "Warning", $"The option selected was not found in the item: [{itemCode.Trim()}]");
            }

            return optionFounded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public async Task<List<ItemOptionDetailsModel>> ListOptionAsync(string itemCode)
        {
            var listOptions = await _optionRepository.ListAsync(itemCode.Trim()).ConfigureAwait(false);

            return listOptions;
        }

        public async Task<string> ValidateItemCodeVariation(string itemCode)
        {
            if (string.IsNullOrWhiteSpace(itemCode))
            {
                throw new ExceptionService(400, $"Please select a valid item");
            }

            string baseCode = "";

            if (itemCode.Contains("-"))
            {
                baseCode = itemCode.Split("-")[0];
            }
            else
            {
                baseCode = itemCode.Trim();
            }

            var details = await _itemRepository.DetailsAsync(baseCode.Trim()).ConfigureAwait(false);

            if (details == null)
            {
                throw new ExceptionService(404, $"The item [{itemCode.Trim()}] selected was not found");
            }

            if (details.ManagedByOptions && !itemCode.Contains("-") || details.ManagedByOptions && itemCode.Contains("-") && string.IsNullOrWhiteSpace(itemCode.Split("-")[1]))
            {
                throw new ExceptionService(404, $"The item [{itemCode.Trim()}] is a root item, please select a variation");
            }

            if(details.ManagedByOptions && itemCode.Contains("-") && !string.IsNullOrWhiteSpace(itemCode.Split("-")[1]))
            {
                var variation = await _optionRepository.DetailsAsync(baseCode, itemCode.Split("-")[1]).ConfigureAwait(false);
                if (variation == null)
                {
                    throw new ExceptionService(404, $"The item [{itemCode.Trim()}] has not the variation [{itemCode.Split("-")[1]}]");
                }

                return $"{details.ItemTile}, talla: {variation.Size}";


            }

            return details.ItemTile;

        }

        #endregion
    }
}
