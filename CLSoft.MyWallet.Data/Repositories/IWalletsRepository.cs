using CLSoft.MyWallet.Data.Models.Wallets;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Data.Repositories
{
    public interface IWalletsRepository
    {
        Task<Wallet> GetWalletByIdAsync(long walletId);
        Task AddWalletAsync(AddWalletRequest request);
        Task EditWalletAsync(EditWalletRequest request);
        Task DeleteWalletByIdAsync(long walletId);
        Task<Wallets> GetAllWalletsByUserIdAsync(long userId);
    }
}