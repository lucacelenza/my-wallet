using System;

namespace CLSoft.MyWallet.Data.Models.Wallets
{
    public class AddWalletRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}