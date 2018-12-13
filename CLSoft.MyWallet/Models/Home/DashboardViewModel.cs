using System.Collections.Generic;

namespace CLSoft.MyWallet.Models.Home
{
    public class DashboardViewModel
    {
        public string UserName { get; set; }
        public IReadOnlyList<WalletViewModel> Wallets { get; set; }
        public CurrentBalanceViewModel CurrentBalance { get; set; }
        public IEnumerable<TransactionViewModel> Transactions { get; set; }
        public TimeBalanceViewModel TimeBalance { get; set; }
    }
}