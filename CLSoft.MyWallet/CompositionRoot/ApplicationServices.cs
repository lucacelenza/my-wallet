﻿using AutoMapper;
using CLSoft.MyWallet.Application.Auth;
using CLSoft.MyWallet.Application.Home;
using CLSoft.MyWallet.Application.Transactions;
using CLSoft.MyWallet.Application.Wallets;
using CLSoft.MyWallet.Business.Url;
using CLSoft.MyWallet.Components.Identity;
using CLSoft.MyWallet.Components.Url;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHttpServices();
            services.AddCustomAuthentication();
            services.AddControllerServices();

            services.AddSingleton(new Random());

            services.AddAutoMapper();

            return services;
        }

        private static IServiceCollection AddHttpServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlResolver, UrlResolver>();

            return services;
        }

        private static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.ReturnUrlParameter = "returnUrl";
                    options.ExpireTimeSpan = new TimeSpan(30, 0, 0, 0);
                    options.EventsType = typeof(CustomCookieAuthenticationEvents);
                });

            services.AddScoped<CustomCookieAuthenticationEvents>();

            return services;
        }

        private static IServiceCollection AddControllerServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthControllerService, AuthControllerService>();
            services.AddScoped<IWalletsControllerService, WalletsControllerService>();
            services.AddScoped<ITransactionsControllerService, TransactionControllerService>();
            services.AddScoped<IHomeControllerService, HomeControllerService>();

            return services;
        }
    }
}