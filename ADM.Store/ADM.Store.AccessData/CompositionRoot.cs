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
            //services.AddTransient<ICompraRepository, CompraRepository>();
            //services.AddTransient<ICompraTipoRepository, CompraTipoRepository>();
            //services.AddTransient<ICompraEstatusRepository, CompraEstatusRepository>();
            //services.AddTransient<ICompraLineaEstatusRepository, CompraLineaEstatusRepository>();
            //services.AddTransient<IProveedorRepository, ProveedorRepository>();
            //services.AddTransient<ICuentaRepository, CuentaRepository>();

            //services.AddDbContext<ADMStoreContext>(options =>
            //    options.UseSqlServer(configuration["ConnectionStrings:default"], o => o.EnableRetryOnFailure()));
            return services;
        }
    }
}