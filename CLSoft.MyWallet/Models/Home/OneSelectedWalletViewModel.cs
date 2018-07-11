using System.Collections.Generic;

namespace CLSoft.MyWallet.Models.Home
{
    public class OneSelectedWalletViewModel : ISelectedWalletsViewModel
    {
        public SelectedWalletViewModel SelectedWallet { get; set; }
        public IEnumerable<WalletViewModel> OtherWallets { get; set; }
    }
}