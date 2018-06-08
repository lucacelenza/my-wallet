using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.User
{
    public interface IAsyncUserIdProvider
    {
        Task<long> GetUserIdAsync();
    }
}