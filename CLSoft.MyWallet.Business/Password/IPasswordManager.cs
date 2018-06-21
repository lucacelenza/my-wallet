using CLSoft.MyWallet.Business.Password.Models;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.Password
{
    public interface IPasswordManager
    {
        Task ChangePasswordAsync(ChangePasswordRequest request);
        Task IssueChangePasswordRequestAsync(IssueChangePasswordRequest request);
    }
}