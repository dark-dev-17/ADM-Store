using ADM.Store.Models.Models.PurchaseOrder;
using ADM.Store.Service.Interfaces.Inventory;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Dictionaries;
using ADM.Store.AccessData.Interfaces.Purchasing;

[assembly: InternalsVisibleTo("ADM.Store.Api")]

namespace ADM.Store.Service.Services.Inventory
{
    internal class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly ILogger<SupplierContactService> _logger;
        private readonly IPurchaseOrderRepository _orderRepository;
        private readonly IPurchaseOrderItemRepository _orderItemRepository;

        public PurchaseOrderService(IPurchaseOrderRepository orderRepository,IPurchaseOrderItemRepository orderItemRepository, ILogger<SupplierContactService> logger)
        {
            _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> CreateAsync(PurchaseOrderCreateModel orderCreateModel)
        {
            if (orderCreateModel == null)
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, ConstantsService.MODEL_ERROR_DATA_NULL);
            }

            var docNumCreated = await _orderRepository.CreateAsync(orderCreateModel.CardCode, orderCreateModel.SupplierLocation, orderCreateModel.SupplierContact, orderCreateModel.DocStatus).ConfigureAwait(false);

            if (docNumCreated == 0)
            {
                throw new ExceptionService(-201, ConstantsService.PURCHASE_ORDER_NOT_FOUND);
            }

            if(orderCreateModel.newItems.Count > 0)
            {
                await _orderItemRepository.CreateAsync(docNumCreated, orderCreateModel.newItems).ConfigureAwait(false);
            }

            await _orderRepository.UpdateDocTotal(docNumCreated).ConfigureAwait(false);

            return docNumCreated;
        }

        public async Task<PurchaseOrderDetailsModel> DetailsAsync(int docNum)
        {
            if (docNum == 0)
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, ConstantsService.MODEL_ERROR_DATA_NULL);
            }

            var orderDetails = await _orderRepository.DetailsAsync(docNum).ConfigureAwait(false);

            if(orderDetails == null)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, ConstantsService.PURCHASE_ORDER_NOT_FOUND);
            }

            return orderDetails;
        }

        public async Task<List<PurchaseOrderBasicDetailsModel>> ListAsync()
        {
            return await _orderRepository.ListAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(int docNum, PurchaseOrderUpdateModel orderUpdateModel)
        {
            if (orderUpdateModel == null)
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, ConstantsService.MODEL_ERROR_DATA_NULL);
            }

            if(!await _orderRepository.ExistsAsync(docNum))
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, ConstantsService.PURCHASE_ORDER_NOT_FOUND);
            }

            await _orderRepository.UpdateAsync(docNum, orderUpdateModel.CardCode, orderUpdateModel.SupplierLocation, orderUpdateModel.SupplierContact, orderUpdateModel.DocStatus).ConfigureAwait(false);

            orderUpdateModel.deleteItems.ForEach(async item =>
            {
                await _orderItemRepository.DeleteAsync(item).ConfigureAwait(false);
            });

            orderUpdateModel.newItems.ForEach(async item =>
            {
                await _orderItemRepository.CreateAsync(docNum, item).ConfigureAwait(false);
            });

            orderUpdateModel.updateItems.ForEach(async item =>
            {
                await _orderItemRepository.UpdateAsync(item).ConfigureAwait(false);
            });


            await _orderRepository.UpdateDocTotal(docNum).ConfigureAwait(false);

        }
    }
}
