using System.Threading.Tasks;

namespace CLSoft.MyWallet.Components.Email
{
    public interface ISendGridApiKeyProvider
    {
        Task<string> GetApiKeyAsync();
    }
}