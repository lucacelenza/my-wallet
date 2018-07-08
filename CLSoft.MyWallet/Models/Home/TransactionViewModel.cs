namespace CLSoft.MyWallet.Models.Home
{
    public class TransactionViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string WalletName { get; set; }
        public string Amount { get; set; }
        public string RegisteredOn { get; set; }
    }
}