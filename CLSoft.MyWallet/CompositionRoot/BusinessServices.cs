using CLSoft.MyWallet.Business.Email;
using CLSoft.MyWallet.Business.Encryption;
using CLSoft.MyWallet.Business.Identity;
using CLSoft.MyWallet.Business.Password;
using CLSoft.MyWallet.Business.Serialization;
using CLSoft.MyWallet.Components.Email;
using CLSoft.MyWallet.Components.Encryption;
using CLSoft.MyWallet.Components.Identity;
using CLSoft.MyWallet.Components.Serialization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusinessServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddEncryption();
            services.AddSerialization();
            services.AddIdentityManager();
            services.AddEmailSender();
            services.AddPasswordManager();

            return services;
        }

        private static IServiceCollection AddEncryption(this IServiceCollection services)
        {
            services.AddSingleton<IEncryption, BCryptEncryption>();
            return services;
        }

        private static IServiceCollection AddSerialization(this IServiceCollection services)
        {
            services.AddSingleton<ISerializer, JsonNetSerializer>();
            return services;
        }

        private static IServiceCollection AddIdentityManager(this IServiceCollection services)
        {
            services.AddSingleton<IIdentityManager, HttpContextIdentityManager>();
            return services;
        }

        private static IServiceCollection AddPasswordManager(this IServiceCollection services)
        {
            services.AddScoped<IPasswordManager, PasswordManager>();
            return services;
        }

        private static IServiceCollection AddEmailSender(this IServiceCollection services)
        {
            services.AddSingleton<ISendGridApiKeyProvider, AppSecretsSendGridApiKeyProvider>();
            services.AddSingleton<IEmailSender, SendGridFluentEmailSender>();
            return services;
        }
    }
}