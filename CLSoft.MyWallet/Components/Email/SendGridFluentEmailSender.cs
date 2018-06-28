using CLSoft.MyWallet.Business.Email;
using CLSoft.MyWallet.Business.Email.Models;
using FluentEmail.Razor;
using FluentEmail.SendGrid;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Components.Email
{
    public class SendGridFluentEmailSender : IEmailSender
    {
        private readonly ISendGridApiKeyProvider _apiKeyProvider;
        private readonly IEmailTemplatesPathProvider _templatesPathProvider;

        public SendGridFluentEmailSender(ISendGridApiKeyProvider apiKeyProvider, IEmailTemplatesPathProvider templatesPathProvider)
        {
            _apiKeyProvider = apiKeyProvider ?? throw new ArgumentNullException(nameof(apiKeyProvider));
            _templatesPathProvider = templatesPathProvider ?? throw new ArgumentNullException(nameof(templatesPathProvider));
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
                .UsingTemplateFromFile(
                    Path.Combine(_templatesPathProvider.GetEmailTemplatesPath(), $"{request.Template}.cshtml"), 
                    request.Model);

            await email.SendAsync();
        }
    }
}