﻿using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ADM.Store.Service
{
    public static class CompositionRoot
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Services
            //services.AddTransient<IDocumentService, DocumentService>();
            return services;
        }
    }
}