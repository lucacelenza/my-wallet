using CLSoft.MyWallet.Business.Transactions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.Transactions
{
    public interface ITransactionsProvider
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync(long? walletId = null);
    }
}