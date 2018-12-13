using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.User
{
    public interface IUserNameProvider
    {
        Task<string> GetUserNameAsync();
    }
}