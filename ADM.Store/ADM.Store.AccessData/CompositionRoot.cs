using ADM.Store.AccessData.Interfaces;
using ADM.Store.AccessData.Interfaces.Purchasing;
using ADM.Store.AccessData.Interfaces.Sales;
using ADM.Store.AccessData.Repositories;
using ADM.Store.AccessData.Repositories.Purchasing;
using ADM.Store.AccessData.Repositories.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ADM.Store.AccessData
{
    public static class CompositionRoot
    {
        public static IServiceCollection RegisterDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            // Services for inventory
            services.AddTransient<IItemCategoryRepository, ItemCategoryRepository>();
            services.AddTransient<IItemMaterialRepository, ItemMaterialRepository>();
            services.AddTransient<IItemStatusRepository, ItemStatusRepository>();
            services.AddTransient<IItemSubCategoryRepository, ItemSubCategoryRepository>();
            services.AddTransient<IItemThemeRepository, ItemThemeRepository>();
            services.AddTransient<IItemTypeRepository, ItemTypeRepository>();
            services.AddTransient<IItemOptionRespository, ItemOptionRespository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            //services for purchasing
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierContactRepository, SupplierContactRepository>();
            services.AddTransient<ISupplierLocationRepository, SupplierLocationRepository>();
            services.AddTransient<ISupplierStatusRepository, SupplierStatusRepository>();
            services.AddTransient<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddTransient<IPurchaseOrderItemRepository, PurchaseOrderItemRepository>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISalesOrderRepository, SalesOrderRepository>();
            services.AddTransient<ISalesOrderItemRepository, SalesOrderItemRepository>();

            services.AddDbContext<ADMStoreContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:default"], o => o.EnableRetryOnFailure()));
            return services;
        }
    }
}