using System.Collections.Generic;

namespace CLSoft.MyWallet.Models.Home
{
    public class DashboardViewModel
    {
        public IEnumerable<IWalletViewModel> Wallets { get; set; }
        public CurrentBalanceViewModel CurrentBalance { get; set; }
        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}