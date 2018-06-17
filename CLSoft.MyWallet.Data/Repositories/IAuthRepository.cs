using CLSoft.MyWallet.Data.Models.Auth;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Data.Repositories
{
    public interface IAuthRepository
    {
        Task<User> GetUserByEmailAddressAsync(string emailAddress);
        User GetUserByEmailAddress(string emailAddress);
        Task AddUserAsync(AddUserRequest request);
        Task ChangeUserPasswordAsync(ChangeUserPasswordRequest request);
        Task<ForgotPasswordToken> GetForgotPasswordTokenByTokenAsync(string token);
        Task AddForgotPasswordTokenAsync(ForgotPasswordToken token);
    }
}