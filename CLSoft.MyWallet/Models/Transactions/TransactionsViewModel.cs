using System.Collections.Generic;

namespace CLSoft.MyWallet.Models.Transactions
{
    public class TransactionsViewModel : ITransactionsViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public int Page { get; set; }

        public class Transaction
        {
            public long Id { get; set; }
            public string Description { get; set; }
            public string Amount { get; set; }
        }
    }
}
