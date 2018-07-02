using AutoMapper;
using CLSoft.MyWallet.Application.Auth;
using CLSoft.MyWallet.Application.Transactions;
using CLSoft.MyWallet.Application.Wallets;
using CLSoft.MyWallet.Components.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
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

            services.AddAutoMapper();

            return services;
        }

        private static IServiceCollection AddHttpServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper>(factory =>
            {
                var actionContext = factory
                    .GetService<IActionContextAccessor>().ActionContext;

                return new UrlHelper(actionContext);
            });

            return services;
        }

        private static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.ReturnUrlParameter = "returnUrl";
                    options.ExpireTimeSpan = new TimeSpan(30, 0, 0, 0);
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnValidatePrincipal = async (context) =>
                        {
                            var identityValidator = context.HttpContext.RequestServices
                                .GetRequiredService<CLSoft.MyWallet.Business.Identity.IIdentityValidator>();

                            try
                            {
                                await identityValidator.ValidatePrincipalAsync(context.Principal);
                            }
                            catch (CLSoft.MyWallet.Business.Identity.Exceptions.InvalidIdentityException)
                            {
                                context.RejectPrincipal();

                                await context.HttpContext.SignOutAsync(
                                    CookieAuthenticationDefaults.AuthenticationScheme);
                            }
                        }
                    };
                    //options.EventsType = typeof(CustomCookieAuthenticationEvents);
                });

            services.AddScoped<CustomCookieAuthenticationEvents>();

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