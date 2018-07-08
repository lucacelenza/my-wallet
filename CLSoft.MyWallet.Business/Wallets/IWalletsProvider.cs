using CLSoft.MyWallet.Business.Wallets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.Wallets
{
    public interface IWalletsProvider
    {
        Task<IEnumerable<Wallet>> GetAllWalletsAsync();
    }
}