namespace CLSoft.MyWallet.Data.Models.Transactions
{
    public class Transaction
    {
        public long WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}