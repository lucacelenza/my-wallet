namespace CLSoft.MyWallet.Models.Transactions
{
    public class GetTransactionsRequest
    {
        public long? WalletId { get; set; }
        public int Page { get; set; }
    }
}