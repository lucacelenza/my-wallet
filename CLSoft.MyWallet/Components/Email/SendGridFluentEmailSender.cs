using CLSoft.MyWallet.Business.Email;
using CLSoft.MyWallet.Business.Email.Models;
using FluentEmail.Razor;
using FluentEmail.SendGrid;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Components.Email
{
    public class SendGridFluentEmailSender : IEmailSender
    {
        private readonly ISendGridApiKeyProvider _apiKeyProvider;

        public SendGridFluentEmailSender(ISendGridApiKeyProvider apiKeyProvider)
        {
            _apiKeyProvider = apiKeyProvider ?? throw new ArgumentNullException(nameof(apiKeyProvider));
        }

        public async Task SendEmailAsync(SendEmailRequest request)
        {
            var apiKey = await _apiKeyProvider.GetApiKeyAsync();
            var sender = new SendGridSender(apiKey);

            FluentEmail.Core.Email.DefaultSender = sender;

            FluentEmail.Core.Email.DefaultRenderer = new RazorRenderer();

            var email = FluentEmail.Core.Email
                .From("assistance@mywallet.com")
                .To(request.To)
                .Subject(request.Subject)
                .UsingTemplateFromEmbedded($"CLSoft.MyWallet.{request.Template}.cshtml", request.Model, GetType().GetTypeInfo().Assembly);

            await email.SendAsync();
        }
    }
}