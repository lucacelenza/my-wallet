using CLSoft.MyWallet.Models.Wallets;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Application.Wallets
{
    public interface IWalletsControllerService
    {
        Task<WalletsViewModel> GetAllWalletsAsync();
        Task<WalletViewModel> GetWalletAsync(long walletId);
        Task AddWalletAsync(WalletViewModel viewModel);
        Task EditWalletAsync(long walletId, WalletViewModel viewModel);
        Task DeleteWalletAsync(long walletId);
    }
}