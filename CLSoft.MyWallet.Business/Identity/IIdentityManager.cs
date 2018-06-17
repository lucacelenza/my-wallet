using CLSoft.MyWallet.Business.Identity.Models;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.Identity
{
    public interface IIdentityManager
    {
        Task SignInAsync(SignInRequest request);
        Task SignOutAsync();
    }
}