using CLSoft.MyWallet.Models.Auth;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Application.Auth
{
    public interface IAuthControllerService
    {
        Task RegisterUserAsync(RegisterUserViewModel viewModel);
        Task LoginAsync(LoginViewModel viewModel);
        Task ForgotPasswordAsync(ForgotPasswordViewModel viewModel);
        Task ChangePasswordAsync(ChangePasswordViewModel viewModel, string token = null);
        Task LogoutAsync();
    }
}