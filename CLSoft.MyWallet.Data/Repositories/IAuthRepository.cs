using CLSoft.MyWallet.Data.Models.Auth;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Data.Repositories
{
    public interface IAuthRepository
    {
        User GetUserById(long userId);
        Task<User> GetUserByEmailAddressAsync(string emailAddress);
        User GetUserByEmailAddress(string emailAddress);
        Task AddUserAsync(AddUserRequest request);
        Task ChangeUserPasswordAsync(ChangeUserPasswordRequest request);
        Task<ForgotPasswordToken> GetForgotPasswordTokenByTokenAsync(string token);
        ForgotPasswordToken GetForgotPasswordTokenByToken(string token);
        Task AddForgotPasswordTokenAsync(ForgotPasswordToken token);
    }
}