using ADM.Store.Service.Interfaces;
using ADM.Store.Service.Services;
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
            //services.AddTransient<IDocumentService, DocumentService>();
            return services;
        }
    }
}