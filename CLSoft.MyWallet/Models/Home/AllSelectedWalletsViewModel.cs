using System.Collections.Generic;

namespace CLSoft.MyWallet.Models.Home
{
    public class AllSelectedWalletsViewModel : ISelectedWalletsViewModel
    {
        public IEnumerable<WalletViewModel> Wallets { get; set; }
    }
}