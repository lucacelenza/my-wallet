using System.Collections.Generic;

namespace CLSoft.MyWallet.Models.Home
{
    public class DashboardViewModel
    {
        public OneSelectedWalletViewModel OneSelectedWallet { get; set; }
        public AllSelectedWalletsViewModel AllSelectedWallets { get; set; }
        public CurrentBalanceViewModel CurrentBalance { get; set; }
        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}