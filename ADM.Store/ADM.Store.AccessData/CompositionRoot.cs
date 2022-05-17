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
            services.AddTransient<ICompraRepository, CompraRepository>();

            services.AddDbContext<ADMStoreContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:default"], o => o.EnableRetryOnFailure()));
            return services;
        }
    }
}