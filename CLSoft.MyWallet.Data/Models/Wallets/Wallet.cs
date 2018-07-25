using System;

namespace CLSoft.MyWallet.Data.Models.Wallets
{
    public class Wallet
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}