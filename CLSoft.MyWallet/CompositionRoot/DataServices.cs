using CLSoft.MyWallet.Data.EntityFramework.Configuration;
using CLSoft.MyWallet.Data.EntityFramework.Repositories;
using CLSoft.MyWallet.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            

            services.AddDbContext<MyWalletDbContext>(o => o.UseSqlite("DataSource=:memory:"));

            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, EntityFrameworkAuthRepository>();
            services.AddScoped<IWalletsRepository, EntityFrameworkWalletsRepository>();
            services.AddScoped<ITransactionsRepository, EntityFrameworkTransactionsRepository>();

            return services;
        }
    }
}
