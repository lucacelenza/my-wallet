using CLSoft.MyWallet.Data.EntityFramework.Configuration;
using CLSoft.MyWallet.Data.EntityFramework.Repositories;
using CLSoft.MyWallet.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<MyWalletDbContext>(o =>
                {
                    o.UseSqlServer(
                        configuration.GetConnectionString("defaultConnectionString"),
                        b => b.MigrationsAssembly("CLSoft.MyWallet"));
                });

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
