namespace CLSoft.MyWallet.Models.Home
{
    public class WalletViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CurrentBalance { get; set; }
        public bool IsSelected { get; set; }
    }
}