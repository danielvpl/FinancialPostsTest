using Application.Interfaces;
using Application.Services;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class DependencyInjection
    {
        public static void AddConfigurations(IServiceCollection services)
        {

            //Repositories
            services.AddTransient<IFinancialRepository, FinancialRepository>();
            //Services
            services.AddTransient<IFinancialService, FinancialService>();
            services.AddTransient<IFinancialApp, FinancialApp>();
        }
    }
}
