using CLSoft.MyWallet.Models.Home;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Application.Home
{
    public interface IHomeControllerService
    {
        Task<DashboardViewModel> GetDashboardViewModelAsync(long? selectedWalletId = null);
    }
}