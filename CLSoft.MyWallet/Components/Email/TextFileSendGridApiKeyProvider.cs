using System.IO;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Components.Email
{
    public class TextFileSendGridApiKeyProvider : ISendGridApiKeyProvider
    {
        public async Task<string> GetApiKeyAsync()
        {
            return await File.ReadAllTextAsync("sendgrid-apikey.txt");
        }
    }
}