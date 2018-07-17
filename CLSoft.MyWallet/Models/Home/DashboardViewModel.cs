using System.Collections.Generic;

namespace CLSoft.MyWallet.Models.Home
{
    public class DashboardViewModel
    {
        public ISelectedWalletsViewModel Wallets { get; set; }
        public CurrentBalanceViewModel CurrentBalance { get; set; }
        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}