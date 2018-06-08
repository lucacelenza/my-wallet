using System;
using System.Collections.Generic;
using System.Text;

namespace CLSoft.MyWallet.Data.Models.Wallets
{
    public class Wallet
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}