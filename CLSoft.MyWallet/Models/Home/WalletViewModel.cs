﻿namespace CLSoft.MyWallet.Models.Home
{
    public class WalletViewModel : IWalletViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CurrentBalance { get; set; }
    }
}