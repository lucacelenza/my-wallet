using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Components.Email
{
    public class AppSecretsSendGridApiKeyProvider : ISendGridApiKeyProvider
    {
        private readonly IConfiguration _configuration;

        public AppSecretsSendGridApiKeyProvider(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public Task<string> GetApiKeyAsync()
        {
            return Task.FromResult(_configuration["sendGridApiKey"]);
        }
    }
}