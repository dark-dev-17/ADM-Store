using ADM.Store.AccessData.Interfaces;
using ADM.Store.AccessData.Repositories;
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
            // Services
            services.AddTransient<IItemCategoryRepository, ItemCategoryRepository>();
            services.AddTransient<IItemMaterialRepository, ItemMaterialRepository>();
            services.AddTransient<IItemStatusRepository, ItemStatusRepository>();
            services.AddTransient<IItemSubCategoryRepository, ItemSubCategoryRepository>();
            services.AddTransient<IItemThemeRepository, ItemThemeRepository>();
            services.AddTransient<IItemTypeRepository, ItemTypeRepository>();
            services.AddTransient<IItemOptionRespository, ItemOptionRespository>();
            services.AddTransient<IItemRepository, ItemRepository>();

            services.AddDbContext<ADMStoreContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:default"], o => o.EnableRetryOnFailure()));
            return services;
        }
    }
}