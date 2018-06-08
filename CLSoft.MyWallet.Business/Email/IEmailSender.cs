using CLSoft.MyWallet.Business.Email.Models;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(SendEmailRequest request);
    }
}