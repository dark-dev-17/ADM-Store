using ADM.Store.Service.Interfaces;
using ADM.Store.Service.Interfaces.Inventory;
using ADM.Store.Service.Interfaces.Sales;
using ADM.Store.Service.Services;
using ADM.Store.Service.Services.Inventory;
using ADM.Store.Service.Services.Sales;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ADM.Store.Service
{
    public static class CompositionRoot
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Services
            services.AddTransient<IItemService,ItemService>();
            services.AddTransient<IItemTypeService, ItemTypeService>();
            services.AddTransient<IItemCategoryService, ItemCategoryService>();
            services.AddTransient<IItemMaterialService, ItemMaterialService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISupplierContactService, SupplierContactService>();
            services.AddTransient<ISupplierLocationService, SupplierLocationService>();
            services.AddTransient<ISupplierStatusService, SupplierStatusService>();
            services.AddTransient<IPurchaseOrderService, PurchaseOrderService>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ISalesOrderService, SalesOrderService>();
            services.AddTransient<IBussinesAccountService, BussinesAccountService>();

            return services;
        }
    }
}