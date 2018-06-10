using System;
using System.Threading.Tasks;
using CLSoft.MyWallet.Business.Email.Models;
using CLSoft.MyWallet.Business.Serialization;

namespace CLSoft.MyWallet.Business.Email
{
    public class ConsoleEmailSender : IEmailSender
    {
        private readonly ISerializer _serializer;

        public ConsoleEmailSender(ISerializer serializer)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public Task SendEmailAsync(SendEmailRequest request)
        {
            Console.WriteLine(_serializer.Serialize(request.Model));
            return Task.FromResult(0);
        }
    }
}