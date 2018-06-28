using Microsoft.Extensions.Configuration;
using System;

namespace CLSoft.MyWallet.Components.Email
{
    public class ConfigurationEmailTemplatesPathProvider : IEmailTemplatesPathProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigurationEmailTemplatesPathProvider(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string GetEmailTemplatesPath()
        {
            return _configuration["emailTemplatesPath"];
        }
    }
}