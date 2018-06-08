using System;
using System.Collections.Generic;
using System.Text;

namespace CLSoft.MyWallet.Data.Models.Wallets
{
    public class EditWalletRequest
    {
        public long WalletId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
