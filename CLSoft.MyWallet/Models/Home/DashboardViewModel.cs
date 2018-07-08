using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Models.Home
{
    public class DashboardViewModel
    {
        public IEnumerable<WalletViewModel> Wallets { get; set; }
        public CurrentBalanceViewModel CurrentBalance { get; set; }
        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}