using AutoMapper;
using CLSoft.MyWallet.Application.Auth;
using CLSoft.MyWallet.Application.Transactions;
using CLSoft.MyWallet.Application.Wallets;
using CLSoft.MyWallet.Business.Email;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, ConsoleEmailSender>();

            services.AddHttpServices();
            services.AddCustomAuthentication();
            services.AddControllerServices();

            services.AddAutoMapper();

            return services;
        }

        private static IServiceCollection AddHttpServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        private static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication("MyWalletCookieScheme")
                .AddCookie();

            return services;
        }

        private static IServiceCollection AddControllerServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthControllerService, AuthControllerService>();
            services.AddScoped<IWalletsControllerService, WalletsControllerService>();
            services.AddScoped<ITransactionsControllerService, TransactionControllerService>();

            return services;
        }
    }
}
