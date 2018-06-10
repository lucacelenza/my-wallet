namespace CLSoft.MyWallet.Data.Models.Transactions
{
    public class GetTransactionsRequest
    {
        public long? WalletId { get; set; }
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
    }
}